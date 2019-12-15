using CheeseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheeseService
{
    public interface ICheeseService
    {
        Task<bool> CreateCheese(Cheese cheese);
        Task<IEnumerable<Cheese>> GetCheeses();
        Task<bool> UpdateCheese(Cheese cheese);
        Task<bool> DeleteCheese(int id);
    }
}
