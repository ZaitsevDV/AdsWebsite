@UserName "admin"


SELECT Users.UserName, Roles.RoleName
FROM Users
JOIN Roles ON Roles.RoleId = Users.RoleId
WHERE Users.UserName = @UserName;