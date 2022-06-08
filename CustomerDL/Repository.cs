using System.Text.Json;
using CustomerModel;

namespace CustomerDL
{
    public class Repository : IRepository<Customer>{
        //Designate the filepath:
        private string _filepath = "../CustomerDL/Data/Customer.json";

        //Method adds customer information to our data:
        public void Add(Customer c_customer){
            List<Customer> listOfCustomer = GetAll();
            listOfCustomer.Add(c_customer);

            string jsonString = JsonSerializer.Serialize(listOfCustomer, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath, jsonString);
        }

        public List<Customer>GetAll(){
            string jsonString = File.ReadAllText(_filepath);
            List<Customer> listOfCustomer = JsonSerializer.Deserialize<List<Customer>>(jsonString);

            return listOfCustomer;                      
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }

}
