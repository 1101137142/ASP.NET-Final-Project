using KuasCore.Models;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Mapper
{
    class FoodMenuRowMapper : IRowMapper<FoodMenu>
    {

        public FoodMenu MapRow(IDataReader dataReader, int rowNum)
        {
            FoodMenu target = new FoodMenu();

            target.Id = dataReader.GetString(dataReader.GetOrdinal("Id"));
            target.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
            target.Ingredient = dataReader.GetString(dataReader.GetOrdinal("Ingredient"));
            target.Price = dataReader.GetString(dataReader.GetOrdinal("Price"));

            return target;
        }
    }
}
