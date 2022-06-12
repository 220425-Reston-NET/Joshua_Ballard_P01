
namespace CustomerDL{
    public interface IRepository<T>{
        //CRUD Operations:
        //Create, Read, Update, Delete

        /// <summary>
        /// Creates resource to the database
        /// </summary>
        /// <param name="c_resource">This is the resource being saved to the database</param>
        void Add(T c_Resource);

        List<T> GetAll();

        /// <summary>
        /// This gives all the resource asynchronous 
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();

        void Update(T p_resource);
    }

}