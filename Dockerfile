#Another stage that is all about running the application or how to run
from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

workdir /app
copy /publish ./

#Entrypoint to set that PokeApi.dll assembly will be our default entrypoint
entrypoint ["dotnet", "CustomerApi2.dll"]

#Expose to port 5000
expose 5000

#Changes the port from the runtime image to listen to 5000 (since by default it uses port 80)
env ASPNETCORE_URLS=http://+:5000
