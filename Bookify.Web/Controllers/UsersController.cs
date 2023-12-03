using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Web.Controllers
{
    [Authorize(Roles = AppRoles.Admin)]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UsersController(UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var viewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);
            return View(viewModel);
        }

        [HttpGet]
        [AjaxOnly]
        public async Task<IActionResult> Create()
        {
            var viewModel = new UserFormViewModel
            {
                Roles = await _roleManager
                        .Roles
                        .Select(r => new SelectListItem
                        {
                            Text = r.Name,
                            Value = r.Name
                        })
                        .ToListAsync(),
            };
            return PartialView("_Form" , viewModel);
        }

        //private async Task<UserFormViewModel> PopulateViewModel(UserFormViewModel? model = null)
        //{
        //    UserFormViewModel viewModel = model is null ? new UserFormViewModel() : model;

        //    var roles =await _roleManager.Roles.ToListAsync();

        //    viewModel.Roles = _mapper.Map<IEnumerable<SelectListItem>>(roles);

        //    return viewModel;
        //}
    }
}
