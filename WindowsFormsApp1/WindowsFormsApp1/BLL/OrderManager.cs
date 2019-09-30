using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.Reository;

namespace WindowsFormsApp1.BLL
{
   public class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();
        
        public bool AddOrder(string name, string quantity)
        {
           int  amount = 0;
            if (name == "Black")
            {
                amount = 120;
            }
            else if (name == "Cold")
            {
                amount = 100;
            }
            else if (name == "Hot")
            {
                amount = 90;
            }
            else if (name == "Regular")
            {
                amount = 80;
            }
            else if (name == "Cappucino")
            {
                amount = 200;
            }
            int totalprice = Convert.ToInt32(quantity) * amount;
            return _orderRepository.AddOrder(name, quantity, totalprice);
        }
        public bool ItemIsNameExists(string name)
        {
            return _orderRepository.ItemIsNameExists(name);
        }
        public bool UpdateOrder(string name, string quantity , int id)
        {
            int amount = 0;
            if (name == "Black")
            {
                amount = 120;
            }
            else if (name == "Cold")
            {
                amount = 100;
            }
            else if (name == "Hot")
            {
                amount = 90;
            }
            else if (name == "Regular")
            {
                amount = 80;
            }
            else if (name == "Cappucino")
            {
                amount = 200;
            }
            int totalprice = Convert.ToInt32(quantity) * amount;
            return _orderRepository.UpdateOrder(name, quantity, totalprice, id);
        }
        public bool DeleteOrder(int id)
        {
            return _orderRepository.DeleteOrder(id);
        }
        public DataTable SearchOrder(string name)
        {
            return _orderRepository.SearchOrder(name);
        }
        public DataTable Display()
        {
            return _orderRepository.Display();
        }
    }
}
