using Microsoft.Data.SqlClient;
using System.Text.Json;
using CustomerModel;

namespace CustomerDL{

    public class SQLCustomerRepository : IRepository<Customer>
    {   
        //=================Dependencey Injection==================
        private string _connectionString;
        public SQLCustomerRepository(string c_connectionString)
        {
            this._connectionString = c_connectionString;
        }
        public void Add(Customer c_Resource)
        {
            //@ inside the string acts as a parameter
            //Information will be dynamically changed later
            string SQLQuery = @"insert into Customer
                                    values (@customerName,@customerAddress,@customerPhone,@customerEmail)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                //Dynamically change information using AddWithValue and Parameters to avoid the risk of SQL Injection attack:
                command.Parameters.AddWithValue("@customerName", c_Resource.Name);
                command.Parameters.AddWithValue("@customerAddress", c_Resource.Address);
                command.Parameters.AddWithValue("@customerPhone", c_Resource.Phone);
                command.Parameters.AddWithValue("@customerEmail", c_Resource.Email);
                
                //Execute SQL statement that is nonquery(won't give anything back):
                command.ExecuteNonQuery();
            }

        }

        public List<Customer> GetAll()
        {
            string SQLQuery = @"select * from Customer";
            List<Customer> listOfCustomer = new List<Customer>();

            //SqlConnection object is responsible for establishing a connection to your database
            //Pass information when object is constructed
            using (SqlConnection con = new SqlConnection(_connectionString)){

                //OperatingSystem connection to the database:
                con.Open();
                
                //SqlCommand object is responsible for executing sql statements in database
                //Needs a string that is a sql statement
                //Needs a SqlConnection obj that has a connection to a database
                SqlCommand command = new SqlCommand(SQLQuery, con);

                //Designed to read a database properly and map the information to an object
                SqlDataReader reader = command.ExecuteReader();

                //Mapping information into an object:
                while(reader.Read()){//read command goes row by row
                    listOfCustomer.Add(new Customer(){
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Phone = reader.GetString(3),
                        Email = reader.GetString(4)
                    });
                }                
                return listOfCustomer;
            }
        }
        private List<Order> GetCustomerOrder(string c_username){
            string SQLQuery = @"select c.Username, o.ID, o.Location, o.TotalPrice from Customer c
                                inner join Orders o on c.Username = o.Username
                                where c.Username = @Username";

            List<Order> listOfOrders = new List<Order>();

            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();

                SqlCommand command = new  SqlCommand(SQLQuery, connect);

                command.Parameters.AddWithValue("@Username", c_username);

                SqlDataReader reader =  command.ExecuteReader();

                while (reader.Read())
                {
                        listOfOrders.Add(new Order(){
                        OrderID = reader.GetInt32(1),
                        Location = reader.GetString(2),
                        TotalPrice = (double)reader.GetDecimal(3)
                        
                    });
                }
                return listOfOrders;
            }
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer c_resource)
        {
            throw new NotImplementedException();
        }

    }
}