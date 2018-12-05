--Please run migration first under PM console
--PM> enable-migrations
--PM> Update-Database

GO
CREATE TABLE Friends(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	userId NVARCHAR(450) REFERENCES AspNetUsers(Id) NOT NULL,
	friendId NVARCHAR(450) REFERENCES AspNetUsers(Id) NOT NULL 
);
CREATE TABLE Posts(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	userId NVARCHAR(450) REFERENCES AspNetUsers(Id) NOT NULL,
	content NVARCHAR(500) NULL,
	created DATE NOT NULL
);
GO

GO
CREATE PROCEDURE GetRestrict
	@uid NVARCHAR(450)
AS
	SELECT Restricted
	FROM AspNetUsers
	WHERE Id=@uid;
GO

GO
CREATE PROCEDURE AddPost
	@uid NVARCHAR(450),
	@content NVARCHAR(500) 
AS
	INSERT INTO Posts(userId, content, created)
	VALUES(@uid, @content, CURRENT_TIMESTAMP);
GO
GO
CREATE PROCEDURE RemovePost
	@pid INT
AS
	DELETE FROM Posts
	WHERE Id=@pid;
GO
GO
CREATE PROCEDURE GetPosts
	@uid NVARCHAR(450)
AS
	SELECT TOP 10 *
	FROM Posts
	WHERE userId=@uid
	ORDER BY created;
GO
GO
CREATE PROCEDURE AddFriend
	@uid NVARCHAR(450),
	@fid NVARCHAR(450)
AS
	INSERT INTO Friends(userId, friendId)
	VALUES(@uid, @fid);
	INSERT INTO Friends(userId, friendId)
	VALUES(@fid, @uid);
GO
GO
CREATE PROCEDURE RemoveFriend
	@uid NVARCHAR(450),
	@fid NVARCHAR(450)
AS 
	DELETE FROM Friends
	WHERE userId=@uid and friendId=@fid;
	DELETE FROM Friends
	WHERE userId=@fid and friendId=@uid;
GO
GO
CREATE PROCEDURE GetFriends
	@uid NVARCHAR(450)
AS
	SELECT AspNetUsers.Id, Name, Email FROM AspNetUsers
	JOIN Friends ON AspNetUsers.Id = Friends.friendId and Friends.userId = @uid;
GO
GO
CREATE PROCEDURE SetName
	@uid NVARCHAR(450),
	@name NVARCHAR(300)
AS
	UPDATE AspNetUsers
	SET Name=@name
	WHERE Id=@uid;
GO

GO
CREATE PROCEDURE RestrictUser
	@uid NVARCHAR(450),
	@restrict BIT
AS
	UPDATE AspNetUsers
	SET Restricted=@restrict
	WHERE Id=@uid;
GO