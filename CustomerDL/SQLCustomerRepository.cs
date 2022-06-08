using Microsoft.Data.SqlClient;
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

        public async Task<List<Customer>> GetAll()
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
                SqlDataReader reader = await command.ExecuteReaderAsync();

                //Mapping information into an object:
                while(await reader.ReadAsync()){//read command goes row by row
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

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        List<Customer> IRepository<Customer>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}