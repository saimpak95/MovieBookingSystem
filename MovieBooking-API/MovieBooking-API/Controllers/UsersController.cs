using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBooking_DomainModels;
using MovieBooking_DTO;
using MovieBooking_Repository;
using MovieBooking_Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBooking_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> genericRepository;
        private readonly IMapper mapper;

        public UsersController(IGenericRepository<User> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> GetUsersList()
        {
            var specification = new UserWithRoleSpecification();
            var users = await genericRepository.GetListAsync(specification);
            return Ok(mapper.Map<IReadOnlyList<User>,IReadOnlyList<UserDTO>>(users));
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetUser(int Id)
        {
            var specification = new UserWithRoleSpecification(Id);
            var user = await genericRepository.GetByIDAsync(specification);
            return Ok(mapper.Map<User, UserDTO>(user));
        }
    }
}
