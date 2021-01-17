using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            string message = string.Empty;

            if (Restaurant.Id > 0)
            {
                message = "Updated successfully!";
                restaurantData.Update(Restaurant);
            }
            else
            {
                message = "Saved successfully!";
                restaurantData.Create(Restaurant);
            }

            restaurantData.Commit();
            TempData["Message"] = message;

            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}
