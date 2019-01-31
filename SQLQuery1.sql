Create Table bloodBank
(
	id int identity(1,1) primary key not null,
	FirstName varchar(255) not null,
	LastName  varchar(255),
	UserName varchar(255) not null,
	Address varchar(255),
	Gender varchar(255) not null,
	BloodGroup varchar(255) not null,
	E_mail varchar(255) not null,
	ContactNumber int not null,
	Password varchar(255) not null,
	RetypedPassword varchar(255) not null
)

delete from bloodBank where id=8

select * from bloodBank

create procedure spInsertUserById
@firstName varchar(255),
@lastName varchar(255),
@userName varchar(255),
@address varchar(255),
@gender varchar(255),
@bloodGroup varchar(255),
@e_mail varchar(255),
@contactNumber int,
@password varchar(255),
@retypedPassword varchar(255),
@id int out
as
Begin
Declare @Count int
Declare @ReturnValue int
select @Count = COUNT(UserName) from bloodBank where UserName = @userName
if (@Count > 0)
Begin
 Set @ReturnValue = -1
End
else
Begin
set @ReturnValue = 1	
insert into bloodBank values(@firstName, @lastName, @userName, @address, @gender, @bloodGroup, @e_mail, @contactNumber, @password, @retypedPassword)
select @id = SCOPE_IDENTITY()
End

create procedure spUserAuthentication
@userName varchar(255),
@password varchar(255)
as
Begin
Declare @Count int
select @Count = COUNT(UserName) from bloodBank where UserName = @userName and Password = @password
if (@Count = 1)
Begin
	select  1 as ReturnValue
ENd
else
Begin
	select -1 as ReturnValue
End
End

create procedure spResetPassword
@email varchar(255)
as
Begin
Declare @Check int
Declare @CheckedValue int
select @Check = COUNT(E_mail) from bloodBank where E_mail = @email
if (@Check = 1)
begin
 set @CheckedValue = 1
 select * from bloodBank where E_mail = @email
end
else
begin
 set @CheckedValue = -1
end
End



truncate table bloodBank







create procedure spSearchBy
@bloodGroupSearch varchar(255)
as
Begin
select FirstName,LastName,Address,Gender,BloodGroup,E_mail,ContactNumber from bloodBank where BloodGroup like @bloodGroupSearch
End


Create procedure spUpdateCustomer
@Email varchar(255),
@Username varchar(255),
@Password varchar(255),
@Id int
as
Begin
update customers set Email = @Email, UserName = @Username, Password = @Password where Id = @Id
End

Create Procedure spDeleteCustomerById
@id int
as
Begin
Delete From Customers where id = @id
End




sp_helptext spResetPassword
truncate table bloodBank