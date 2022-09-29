create table UserDB(userId int primary key identity(1,1),username varchar(20) unique,
password varchar(20) CONSTRAINT CK_Users_PasswordLength CHECK(LEN([password]) >= 8) , active BIT)
insert into UserDB values('user1', 123456789, 1)
select * from UserDB
drop table UserDB

--Creating the User 

alter procedure usp_AddUser @userId int out, @username varchar(20), @password varchar(20), @active BIT
as
begin
insert into UserDB values (@username, @password, @active)
set @userId=SCOPE_IDENTITY()
end

execute usp_AddUser 1,'user2','12345678',0

--Updating the User

alter procedure usp_UpdateUser @userId int, @username varchar(20), @password varchar(20),@active BIT
as 
begin
update UserDB set username=@username, password=@password,active=@active where userId=@userId
end
drop procedure usp_UpdateUser
execute usp_UpdateUser 1,'user4','12356742',1






