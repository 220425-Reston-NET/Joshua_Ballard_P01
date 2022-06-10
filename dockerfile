# from mcr.microsoft.com/dotnet/sdk:6.0 as build

# # workdir docker instruction let use create what our working directory will be for this image
# workdir /app

# # copy docker instruction will let us copy files from this computer to put iubnside of the docker image
# copy *.sln ./
# copy StoreApi/*.csproj StoreApi/
# copy StoreBL/*.csproj StoreBL/
# copy StoreDL/*.csproj StoreDL/
# copy StoreModel/*.csproj StoreModel/
# copy StoreTest/*.csproj StoreTest/

# copy . ./

# run dotnet build

# # Published the project in Azure and makes exe file
# run dotnet publish -c Release -o publish

# # Then commment out everything above and run the below

# # Multi-stage build  in Docker

# from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

# workdir /app
# copy --from=build /app/publish ./

# cmd ["dotnet", "StoreApi.dll"]

# expose 80
# Change 80 to 5000

# Look below


from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

workdir /app

copy /publish ./

entrypoint ["dotnet", "CustomerApp.dll"]

expose 5000

env ASPNETCORE_URLS=http://+:5000

# Run this in console
# docker build -t [YourName]/[Your App Name]:[Current version] .
# example below
# docker build -t arjunnair/StoreApi:1.0 .

# Run this in console
# docker run -d -p 5000:80 -t [PUT Image name here]