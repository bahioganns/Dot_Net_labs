# Create User
curl "http://localhost:5000/api/user" -X POST -H "Content-Type: application/json" --data '{"Email":"qwe@rty.ru","PasswordHash":"qwerty"}'

# Create Bad User
curl "http://localhost:5000/api/user" -X POST -H "Content-Type: application/json" --data '{"Email":"@r.u","PasswordHash":"qwerty"}'

# Get User by id
curl "http://localhost:5000/api/user/2"

# Update User Data
curl "http://localhost:5000/api/user/1" -X PUT -H "Content-Type: application/json" --data '{"Email":"asd@aww.ru","PasswordHash":"123456"}'

# Delete User
curl -X DELETE "http://localhost:5000/api/user/1"
