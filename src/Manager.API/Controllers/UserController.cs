using System;
using Microsoft.AspNetCore.Mvc;
using Manager.Core.Exceptions;
using Manager.API.ViewModels;
using System.Threading.Tasks;
using Manager.Services.Interfaces;
using AutoMapper;
using Manager.Services.DTO;
using Manager.API.Utils;
using Microsoft.AspNetCore.Authorization;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        { 
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);

                var userCreated = await _userService.Create(userDTO);

                return Ok(new ResultViewModel {
                    Message = "Usuário criado com sucesso.",
                    Success = true,
                    Data = userCreated,
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    
        [HttpPut]
        [Authorize]
        [Route("/api/v1/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);

                var userUpdated = await _userService.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso",
                    Success = true,
                    Data = userUpdated
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("/api/v1/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                var user = await _userService.Get(id);

                if(user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado",
                        Success = true,
                        Data = user
                    });
                }
                
                await _userService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = $"Usuário de id {id} removido com sucesso",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await _userService.Get(id);

                if(user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado",
                        Success = true,
                        Data = user
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allUsers = await _userService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    
        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get-by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.GetByEmail(email);

                if(user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com este email",
                        Success = true,
                        Data = user
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get-by-cpf")]
        public async Task<IActionResult> GetByCpf([FromQuery] string cpf)
        {
            try
            {
                var user = await _userService.GetByCpf(cpf);

                if(user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com este cpf",
                        Success = true,
                        Data = user
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var allUsers = await _userService.SearchByName(name);

                if (allUsers.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário com este nome foi encontrado",
                        Success = true,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/search-by-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var allUsers = await _userService.SearchByEmail(email);

                if (allUsers.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário com este email foi encontrado",
                        Success = true,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }

}