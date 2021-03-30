PROJECT_NAME := DataAccess
SLN_NAME := labs.sln

run:
	dotnet run --project ${PROJECT_NAME}

restore:
	dotnet restore ${SLN_NAME}

build:
	dotnet build --no-restore ${SLN_NAME}

test:
	dotnet test --no-build --verbosity normal ${SLN_NAME}

