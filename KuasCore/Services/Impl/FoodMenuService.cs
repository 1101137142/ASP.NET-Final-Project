using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Services.Impl
{
    public class FoodMenuService:IFoodMenuService
    {
        public IFoodMenuDao FoodMenuDao { get; set; }
        
        public Models.FoodMenu AddFoodMenu(Models.FoodMenu FoodMenu)
        {
            FoodMenuDao.AddFoodMenu(FoodMenu);
            return GetFoodMenuByName(FoodMenu.Name);
        }

        public void UpdateFoodMenu(Models.FoodMenu FoodMenu)
        {
            FoodMenuDao.UpdateFoodMenu(FoodMenu);
        }

        public void DeleteFoodMenu(Models.FoodMenu FoodMenu)
        {
            FoodMenu = FoodMenuDao.GetFoodMenuByName(FoodMenu.Name);

            if (FoodMenu != null)
            {
                FoodMenuDao.DeleteFoodMenu(FoodMenu);
            }
        }

        public IList<Models.FoodMenu> GetAllFoodMenu()
        {
            return FoodMenuDao.GetAllFoodMenu();
        }

        public Models.FoodMenu GetFoodMenuByName(string name)
        {

            return FoodMenuDao.GetFoodMenuByName(name);
        }

        public Models.FoodMenu GetFoodMenuById(string id)
        {
            return FoodMenuDao.GetFoodMenuById(id);
        }
    }
}
