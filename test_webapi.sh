# Create User
curl "http://localhost:5000/api/user" -X POST -H "Content-Type: application/json" --data '{"Email":"q1we@rty.ru","PasswordHash":"qwerty"}'

# Create Bad User
curl "http://localhost:5000/api/user" -X POST -H "Content-Type: application/json" --data '{"Email":"@r.u","PasswordHash":"qwerty"}'

# Get User by id
curl "http://localhost:5000/api/user/2"

# Get all Users
curl "http://localhost:5000/api/user"

# Update User Data
curl "http://localhost:5000/api/user/1" -X PUT -H "Content-Type: application/json" --data '{"Email":"asd@aww.ru","PasswordHash":"123456"}'

# Delete User
curl -X DELETE "http://localhost:5000/api/user/1"

# Create User Note
curl "http://localhost:5000/api/user/2/notes" -X POST -H "Content-Type: application/json" --data '{"Title":"title2","Content":"content2"}'

# Get User Notes IDs
curl "http://localhost:5000/api/user/2/notes"

# Get Note
curl "http://localhost:5000/api/note/3"

# Update Note
curl "http://localhost:5000/api/note/3" -X PUT -H "Content-Type: application/json" --data '{"Title":"test","Content":"123456","UserId":2}'

# Delete Note
curl -X DELETE "http://localhost:5000/api/note/1"
