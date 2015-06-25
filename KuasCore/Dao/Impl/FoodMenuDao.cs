using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Impl
{
    public class FoodMenuDao : GenericDao<FoodMenu>,IFoodMenuDao
    {
        override protected IRowMapper<FoodMenu> GetRowMapper()
        {
            return new FoodMenuRowMapper();
        }
        public void AddFoodMenu(FoodMenu FoodMenu)
        {
            string command = @"INSERT INTO FoodMenu (Id, Name, Ingredient,Price) VALUES (@Id, @Name, @Ingredient,@Price);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = FoodMenu.Id;
            parameters.Add("Name", DbType.String).Value = FoodMenu.Name;
            parameters.Add("Ingredient", DbType.String).Value = FoodMenu.Ingredient;
            parameters.Add("Price", DbType.String).Value = FoodMenu.Price;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateFoodMenu(FoodMenu FoodMenu)
        {
            string command = @"UPDATE FoodMenu SET Name = @Name, Ingredient = @Ingredient,Price=@Price WHERE Id = @Id;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = FoodMenu.Id;
            parameters.Add("Name", DbType.String).Value = FoodMenu.Name;
            parameters.Add("Ingredient", DbType.String).Value = FoodMenu.Ingredient;
            parameters.Add("Price", DbType.String).Value = FoodMenu.Price;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteFoodMenu(FoodMenu FoodMenu)
        {
            string command = @"DELETE FROM FoodMenu WHERE Id = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = FoodMenu.Id;

            ExecuteNonQuery(command, parameters);
        }

        public IList<FoodMenu> GetAllFoodMenu()
        {
            string command = @"SELECT * FROM FoodMenu ORDER BY Id ASC";
            IList<FoodMenu> FoodMenu = ExecuteQueryWithRowMapper(command);
            return FoodMenu;
        }

        public FoodMenu GetFoodMenuByName(string name)
        {
            string command = @"SELECT * FROM FoodMenu WHERE Name = @Name";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Name", DbType.String).Value = name;

            IList<FoodMenu> FoodMenu = ExecuteQueryWithRowMapper(command, parameters);
            if (FoodMenu.Count > 0)
            {
                return FoodMenu[0];
            }

            return null;
        }

        public FoodMenu GetFoodMenuById(string id)
        {
            string command = @"SELECT * FROM FoodMenu WHERE Id = @id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("id", DbType.String).Value = id;

            IList<FoodMenu> FoodMenu = ExecuteQueryWithRowMapper(command, parameters);
            if (FoodMenu.Count > 0)
            {
                return FoodMenu[0];
            }

            return null;
        }
    }
}
