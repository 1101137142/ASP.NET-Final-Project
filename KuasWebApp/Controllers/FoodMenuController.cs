using KuasCore.Models;
using KuasCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class FoodMenuController : ApiController
    {
        public IFoodMenuService FoodMenuService { get; set; }

        [HttpPost]
        public FoodMenu AddFoodMenu(FoodMenu FoodMenu)
        {
            CheckFoodMenuIsNotNullThrowException(FoodMenu);

            try
            {
                return FoodMenuService.AddFoodMenu(FoodMenu);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public FoodMenu UpdateFoodMenu(FoodMenu FoodMenu)
        {
            CheckFoodMenuIsNullThrowException(FoodMenu);

            try
            {
                FoodMenuService.UpdateFoodMenu(FoodMenu);
                return FoodMenuService.GetFoodMenuByName(FoodMenu.Name);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteFoodMenu(FoodMenu FoodMenu)
        {
            try
            {
                FoodMenuService.DeleteFoodMenu(FoodMenu);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<FoodMenu> GetAllFoodMenu()
        {
            return FoodMenuService.GetAllFoodMenu();
        }

        [HttpGet]
        public FoodMenu GetFoodMenuById(string id)
        {
            var FoodMenu = FoodMenuService.GetFoodMenuById(id);

            if (FoodMenu == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return FoodMenu;
        }

        [HttpGet]
        [ActionName("Name")]
        public FoodMenu GetFoodMenuByName(string input)
        {
            var FoodMenu = FoodMenuService.GetFoodMenuByName(input);

            if (FoodMenu == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return FoodMenu;
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="course">
        ///     課程資料.
        /// </param>
        private void CheckFoodMenuIsNullThrowException(FoodMenu FoodMenu)
        {
            FoodMenu dbFoodMenu = FoodMenuService.GetFoodMenuById(FoodMenu.Id);

            if (dbFoodMenu == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="course">
        ///     課程資料.
        /// </param>
        private void CheckFoodMenuIsNotNullThrowException(FoodMenu FoodMenu)
        {
            FoodMenu dbFoodMenu = FoodMenuService.GetFoodMenuById(FoodMenu.Id);

            if (dbFoodMenu != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }







    }
}
