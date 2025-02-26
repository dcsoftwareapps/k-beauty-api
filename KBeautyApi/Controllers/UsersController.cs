using AutoMapper;
using KBeautyApi.Dtos;
using KBeautyApi.Models;
using KBeautyApi.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace KBeautyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FidelityDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(FidelityDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _context.Users.Include(x => x.Level).ToListAsync();
            var levels = await _context.Levels.ToListAsync();

            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            
            foreach (var userDto in userDtos)
            {
                var requiredPointsToNextLevel = levels.Where(x => x.RequiredPoints > userDto.Points).OrderBy(x => x.RequiredPoints).FirstOrDefault()?.RequiredPoints;
                if (requiredPointsToNextLevel != null)
                {
                    userDto.PointsToNextLevel = requiredPointsToNextLevel - userDto.Points;
                }
            }

            return Ok(userDtos);
        }


        // GET: api/Users/5
        [HttpGet("store-code/{storeCode}/email/{email}")]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string storeCode, string email)
        {
            var user = await _context.Users
                .Include(x => x.Store)
                .Include(x => x.Level)
                .FirstOrDefaultAsync(x => x.Store != null && x.Store.Code == storeCode && x.Email == email);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserDto>(user);
        }

        
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserCreateDto userCreateDto)
        {
            var store = await _context.Stores.Include(x => x.Levels).FirstOrDefaultAsync(x => x.Code == userCreateDto.StoreCode);
            if (store == null)
            {
                return ValidationProblem("Invalid Store Code");
            }

            if (userCreateDto.Email.IsNullOrEmpty() || !RegexUtilities.IsValidEmail(userCreateDto.Email))
            {
                return ValidationProblem("Invalid Email");
            }

            if (await _context.Users.Include(x => x.Store).AnyAsync(x => x.Store != null && x.Store.Code == userCreateDto.StoreCode && x.Email == userCreateDto.Email))
            {
                return ValidationProblem("Email already in use");
            }

            var user = _mapper.Map<User>(userCreateDto);
            
            user.Code = Guid.NewGuid().ToString();
            user.StoreId = store.Id;

            var level = store?.Levels?.OrderBy(x => x.RequiredPoints).FirstOrDefault();
            user.LevelId = level.Id;
            user.Points = 0;
            user.PointsToNextLevel = level.RequiredPoints;

            _context.Users.Add(user);
            
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

    }
}
