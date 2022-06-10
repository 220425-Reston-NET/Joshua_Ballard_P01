# Dockerfile is an instructional manual for the computer to follow to create the image
#from instruction will tell docker engine that this image will depend on this SDK to run
#Dockerhub is equivalent to github and we are just pulling an image version of our SDK to put in this image
from mcr.microsoft.com/dotnet/sdk:6.0 as runtime

#workdir docker instruction let us create what our worker dir will be for this image
workdir /app

copy /publish ./

#Changed CMD to entrypoint
entrypoint ["dotnet", "CustomerApi.dll"]

#Expose to port 80
expose 5000

#We need to change our ASP.NET app to also start listening in 5000
env ASPNETCORE_URLS=http://+:5000
