using Microsoft.Data.SqlClient;
using CustomerModel;
using CustomerDL;

namespace StoreAppDL
{
    public class SQLOrderRepositoryRepo : IRepository<Order>{
        //=================== Dependency Injection ==========================
        private string _connectionString;

        public SQLOrderRepositoryRepo(string p_connectionString){
            this._connectionString = p_connectionString;
        }

        //=====================Dependency Injection ========================
        public void Add(Order p_resource){
            throw new NotImplementedException();
        }

        public List<Order> GetAll(){
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllAsync(){
            throw new NotImplementedException();
        }

        public void Update(Order c_resource){
            string SQLquery = @"update Orders
                                set Totalprice = @TotalPrice
                                set Location = @Location
                                where Username = @Username and ID = @OrderID";

            using (SqlConnection con = new SqlConnection(_connectionString)){
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@ID", c_resource.OrderID);
                command.Parameters.AddWithValue("@Location", c_resource.Location);
                command.Parameters.AddWithValue("@TotalPrice", c_resource.TotalPrice);

                command.ExecuteNonQuery();
            }
        }
    }
}