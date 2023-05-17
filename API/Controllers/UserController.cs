using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // /api/users
    public class UserController : Controller
    {
        public UserController(DataContext context)
        {
        
        }
    }
}
