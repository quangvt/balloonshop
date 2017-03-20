Create Procedure SelectDepartment
@Id int
As
	Select * From Departments
	Where DepartmentId = @Id
Go

Create Proc SelectAllDepartments
As
	Select * From Departments
Go

Create Proc UpdateDepartment
@Id int,
@Name nvarchar(30),
@Description nvarchar(500)
As
	Update Departments
	Set Name = @Name,
		Description = @Description
	Where DepartmentId = @Id
Go

Create Proc DeleteDepartment
@Id int
As
	Delete From Departments
	Where DepartmentId = @Id
Go
		