FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /home/app

COPY ./*.sln ./
COPY ./src/BookingService/*/*.csproj ./BookingService/
COPY ./src/Shared/*/*.csproj ./Shared/
COPY ./NuGet.config ./


RUN for file in $(ls BookingService/*.csproj); do mkdir -p ./src/${file%.*}/ && mv $file ./src/${file%.*}/; done
RUN for file in $(ls Shared/*.csproj); do mkdir -p ./src/${file%.*}/ && mv $file ./src/${file%.*}/; done

RUN dotnet restore --configfile NuGet.config /home/app/src/BookingService/Booking.Api/Booking.Api.csproj
 
COPY . .	

RUN dotnet build -c Release /home/app/src/BookingService/Booking.Api/Booking.Api.csproj && \
	dotnet publish -c Debug -o /publish /home/app/src/BookingService/Booking.Api/Booking.Api.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /publish

COPY --from=build /publish .

ENTRYPOINT ["dotnet", "Booking.Api.dll"]