.PHONY: mvc

SLN_NAME := labs.sln

mvc:
	dotnet run --project MVC/

api:
	dotnet run --project WebApi/

restore:
	dotnet restore ${SLN_NAME}

build:
	dotnet build --no-restore ${SLN_NAME}

test:
	dotnet test --no-build --verbosity normal ${SLN_NAME}

