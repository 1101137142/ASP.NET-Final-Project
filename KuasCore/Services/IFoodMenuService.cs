using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Services
{
    public interface IFoodMenuService
    {
        FoodMenu AddFoodMenu(FoodMenu FoodMenu);

        void UpdateFoodMenu(FoodMenu FoodMenu);

        void DeleteFoodMenu(FoodMenu FoodMenu);

        IList<FoodMenu> GetAllFoodMenu();

        FoodMenu GetFoodMenuByName(string name);

        FoodMenu GetFoodMenuById(string id);

    }
}
