using CustomerUI;
using CustomerDL;
using CustomerBL;
using Serilog;
using Microsoft.Extensions.Configuration;

//Initializing Logger:
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")
    .CreateLogger();

//initializing my configuration object
var configuration = new ConfigurationBuilder() //Builder class used for configuration object
    .SetBasePath(Directory.GetCurrentDirectory()) //Sets the base path to the current directory
    .AddJsonFile("appsetting.json")//Grabs the specific json file on where the information is from
    .Build();//Creates the object

//Creates MainMenu object:
//Variance and that is letting a reference variable have multiple forms/obects hold by having it define as an interface
IMenu menu = new MainMenu();
    bool repeat = true;

    while (repeat){
        Console.Clear();
        menu.Display();
        string ans = menu.YourChoice();

        if (ans == "MainMenu"){
            menu = new MainMenu();
        }
        else if(ans == "AddCustomer"){
            Log.Information("User going to AddCustomer Menu");
            //Need to add customerBL object inside of the parameter:
            menu = new AddCustomer(new CustomersBL(new SQLCustomerRepository(configuration.GetConnectionString("Joshua_Ballard_Demo"))));
        }
        else if(ans == "SearchCustomer"){
            Log.Information("User going to SearchCustomer Menu");
            menu = new SearchCustomer(new CustomersBL(new SQLCustomerRepository(configuration.GetConnectionString("Joshua_Ballard_Demo"))));
        }
        else if (ans =="Exit"){
            repeat = false;
        }
    }
