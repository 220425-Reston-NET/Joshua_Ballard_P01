# Dockerfile is an instructional manual for the computer to follow to create the image
#from instruction will tell docker engine that this image will depend on this SDK to run
#Dockerhub is equivalent to github and we are just pulling an image version of our SDK to put in this image
from mcr.microsoft.com/dotnet/sdk:6.0 as build

#workdir docker instruction let us create what our worker dir will be for this image
workdir /app

#copy docker instruction will copy files from this computer to inside of the docker image
copy *.sln ./
copy CustomerApi/*.csproj CustomerApi/
copy CustomerBL/*.csproj CustomerBL/
copy CustomerDL/*.csproj CustomerDL/
copy CustomerModel/*.csproj CustomerModel/
copy CustomerTest/*.csproj CustomerTest/

#Copy the rest after setting up our project structure
copy . ./

#Restoring our bin and obj files
run dotnet build

#Creates published folder that holds all info to run the app
run dotnet publish -c Release -o publish

# Multi-stage build in Docker
# It allows us to have multiple ways to create our application
# First stage is about building the application
# Used to run dotnet
from mcr.microsoft.com/dotnet/sdk:6.0 as runtime

workdir /app
copy --from=build /app/publish ./

#CMD docker instructions tells the engine how/where to run this app
cmd ["dotnet", "CustomerApi.dll"]

#Expose to port 80
expose 80