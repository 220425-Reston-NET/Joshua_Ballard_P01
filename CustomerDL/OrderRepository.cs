using System.Text.Json;
using CustomerModel;

namespace CustomerDL
{
    public class OrderRepository : IRepository<Order>
    {
        private string _filepath = "../StoreAppDL/Data/Order.json";
        public void Add(Order p_resource)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            string jsonString = File.ReadAllText(_filepath);
            List<Order> listOfOrder = JsonSerializer.Deserialize<List<Order>>(jsonString);

            return listOfOrder;
        }
        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public void Update(Order p_resource)
        {
            throw new NotImplementedException();
        }

        Task<List<Order>> IRepository<Order>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}