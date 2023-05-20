using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using Services.Service.IService;

namespace BolsaDeEmpleo.Controllers
{
    //Esto se utiliza para especificar la ruta base de la API.[controller] 
    //se sustituye por el nombre del controlador que se está utilizando para
    //manejar la solicitud.Por ejemplo, si el nombre del controlador es ValuesController, 
    //la ruta base sería "api/values".
    [Route("api/[controller]")]
    //Esto es una anotación que indica que el controlador 
    //está diseñado específicamente para trabajar con una API.
    //Proporciona características adicionales a la clase del controlador,
    //como el modelado automático de parámetros y la validación de datos de entrada.
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            List<User> listUsers = await _userService.GetAll(); 
            return Ok(listUsers);
        }

        //POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers(User user)
        {
            User createdUser = await _userService.Create(user);
            return Ok(createdUser);
        }

    }
}
