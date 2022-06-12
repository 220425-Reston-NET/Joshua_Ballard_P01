using System.ComponentModel.DataAnnotations;

namespace CustomerModel{
    public class Customer{
            public string Name{get;set;}
            public string Address{get;set;}
            public string Phone{get;set;}
            public string Email{get;set;}
  
        public List<Order> Orders { get; set; }
        public Customer(){
            Name = this.Name;
            Address = this.Address;
            Phone = this.Phone;
            Email = this.Email;
        }


    public override string ToString(){
      return $"Customer Info \n===============\nName: {Name}\nAddress: {Address}\nPhone Number:  {Phone} \nE-mail: {Email}";
    }
  }//end of class
}//end of namespace
