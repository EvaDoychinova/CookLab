namespace CookLab.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using CookLab.Models.InputModels.UserRecipes;
    using CookLab.Models.ViewModels.UserRecipes;
    using CookLab.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class UserRecipesController : BaseController
    {
        private IUserRecipesService userRecipesService;

        public UserRecipesController(IUserRecipesService userRecipesService)
        {
            this.userRecipesService = userRecipesService;
        }

        public IUserRecipesService UserRecipesService { get; }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UserRecipeResponseModel>> AddOrRemoveFromMyRecipesAsync(UserRecipeInputModel inputModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!inputModel.IsInList)
            {
                await this.userRecipesService.AddRecipeToUserListAsync(userId, inputModel.RecipeId);
            }
            else
            {
                await this.userRecipesService.RemoveRecipeFromUserListAsync(userId, inputModel.RecipeId);
            }

            var usersCount = await this.userRecipesService.GetUsersForRecipeAsync(inputModel.RecipeId);

            var response = new UserRecipeResponseModel
            {
                UsersCount = usersCount,
            };

            return response;
        }
    }
}
