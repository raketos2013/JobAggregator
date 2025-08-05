using AutoMapper;
using FluentValidation;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Enum;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Services;
using JobAggregator.Core.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService,
                            IMapper mapper,
                            IValidator<UserDTO> userValidator) : ControllerBase
{
    // TODO: доступ только роли ADMIN
    // GET: api/<UserController>
    [HttpGet]
    public async Task<ActionResult<PagedList<User>>> Get([FromQuery] QueryDTO queryDTO)
    {
        var query = mapper.Map<Query>(queryDTO);
        var users = await userService.GetAllAsync(query);
        //var usersDTO = mapper.Map<List<UserDTO>>(users);
        var pagedDTO = new PagedList<User>(users, users.Count, users.CurrentPage, users.PageSize);
        return Ok(pagedDTO);
    }

    // TODO: доступ только роли ADMIN
    // GET: api/<UserController>/1
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        return await userService.GetAsync(id);
    }

    // POST api/User
    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] UserDTO user)
    {
        var validationResult = userValidator.Validate(user);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
        var newUser = mapper.Map<User>(user);
        var created = await userService.CreateAsync(newUser);
        return Ok(created);
    }

    // TODO: доступ только авторизованным пользователям и проверку изменять только свой аккаунт
    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UserDTO user)
    {
        var validationResult = userValidator.Validate(user);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
        var oldUser = await userService.GetAsync(id);
        if (oldUser != null)
        {
            oldUser = mapper.Map<UserDTO, User>(user, oldUser);
            var updated = await userService.UpdateAsync(oldUser);
            return Ok(updated);
        }
        return BadRequest();
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        // TODO: добавить проверку, удалять только самого себя, либо ADMIN
        var deleted = await userService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        else
        {
            return Ok(deleted);
        }
    }


    // PUT api/<UserController>/5
    [HttpPut("Block/{id}")]
    public async Task<ActionResult> Block(int id)
    {
        User user = await userService.GetAsync(id);
        if (user != null)
        {
            user.Status = UserStatus.Blocked;
            var updated = await userService.UpdateAsync(user);
            return Ok(updated);
        }
        return BadRequest();
    }

    [HttpGet("{userId}/SaveVacancy/{vacancyId}")]
    public async Task<ActionResult<UserDTO>> SaveVacancy(int userId, int vacancyId)
    {
        await userService.SaveVacancy(userId, vacancyId);
        var user = await userService.GetAsync(userId);
        var userDTO = mapper.Map<UserDTO>(user);
        return Ok(userDTO);
    }

    [HttpGet("{userId}/DeleteVacancy/{vacancyId}")]
    public async Task<ActionResult<UserDTO>> DeleteVacancy(int userId, int vacancyId)
    {
        await userService.DeleteVacancy(userId, vacancyId);
        return Ok(true);
    }

    [HttpGet("{id}/savedVacancies")]
    public async Task<ActionResult<List<Vacancy>>> GetSavedVacancies(int id)
    {
        var vacancies = await userService.GetSavedVacancyAsync(id);
        return vacancies;
    }

    [HttpGet("{id}/resumes")]
    public async Task<ActionResult<List<Resume>>> GetUserResumes(int id)
    {
        return await userService.GetUserResumesAsync(id);
    }

    [HttpGet("{id}/userManager")]
    public async Task<ActionResult<UserDTO>> UserManager(int id)
    {
        var user = await userService.GetAsync(id);
        if (user == null) 
            return NotFound();
        user.RoleId = 3;
        user.NeedManager = false;
        await userService.UpdateAsync(user);
        var userDTO = mapper.Map<UserDTO>(user);
        return Ok(userDTO);
    }

    [HttpGet("{id}/requestManager")]
    public async Task<ActionResult<UserDTO>> RequestManager(int id)
    {
        var user = await userService.GetAsync(id);
        if (user == null)
            return NotFound();
        user.NeedManager = true;
        await userService.UpdateAsync(user);
        var userDTO = mapper.Map<UserDTO>(user);
        return Ok(userDTO);
    }
}
