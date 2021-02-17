PROJECT_NAME := lab1

run:
	dotnet run --project ${PROJECT_NAME}

test:
	dotnet test ${PROJECT_NAME}.Test
