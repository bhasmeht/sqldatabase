---- Equipment Database   -------

create table EquipmentDB(EquipmentId int primary key identity(1,1), EquipmentName varchar(20), PartId varchar(20),
EquipmentGroupId int foreign key references EquipmentGroup
 ON DELETE CASCADE
 ON UPDATE CASCADE
 )

 

 -- Adding the EquipmentDB
create procedure usp_AddEquipment @EquipmentId int out, @EquipmentName varchar(20), @PartId varchar(20),
@EquipmentGroupId int
as 
begin
insert into EquipmentDB values (@EquipmentName, @PartId, @EquipmentGroupId)
set @EquipmentId=SCOPE_IDENTITY()
end

execute usp_AddEquipment 1,'E1', '001',1

--Updating the EquipmentDB
create procedure usp_UpdateEquipment @EquipmentId int, @EquipmentName varchar(20), @PartId varchar(20),
@EquipmentGroupId int
as
begin
update EquipmentDB set EquipmentName=@EquipmentName, PartId=@PartId, EquipmentGroupId=@EquipmentGroupId where EquipmentId=@EquipmentId
end

execute usp_UpdateEquipment 1, 'E2','001',1

--Delete the EquipmentDB

create procedure usp_DeleteEquipment @EquipmentId int
as 
begin
delete from EquipmentDB where EquipmentId=@EquipmentId
end

execute usp_DeleteEquipment 2



insert into EquipmentDB values ('E3','E001',1)
select * from EquipmentDB


-----EquipmentGroup Database------

create table EquipmentGroup(EquipmentGroupId int primary key identity(1,1), EquipmentGroupName varchar(20), EquipmentCategoryId int foreign key references EquipmentCategory
ON DELETE CASCADE
ON UPDATE CASCADE
)



--- Adding EquipmentGroup

create procedure usp_AddEquipmentGroup @EquipmentGroupId int out, @EquipmentGroupName varchar(20), @EquipmentCategoryId int
as 
begin
insert into EquipmentGroup values (@EquipmentGroupName, @EquipmentCategoryId)
set @EquipmentGroupId=SCOPE_IDENTITY()
end 

execute usp_AddEquipmentGroup 1,'EG1',1

--- Updating EquipmentGroup

create procedure usp_UpdateEquipmentGroup @EquipmentGroupId int , @EquipmentGroupName varchar(20), @EquipmentCategoryId int
as 
begin
update EquipmentGroup set EquipmentGroupName=@EquipmentGroupName, EquipmentCategoryId=@EquipmentCategoryId where EquipmentGroupId=@EquipmentGroupId 
end

execute usp_UpdateEquipmentGroup 2, 'EG2',1

--- Deleting EquipmentGroup

create procedure usp_DeleteEquipmentGroup @EquipmentGroupId int  
as 
begin
delete from EquipmentGroup  where EquipmentGroupId=@EquipmentGroupId 
end

execute usp_DeleteEquipmentGroup 2




insert into EquipmentGroup values ('Mobile',1)
select * from EquipmentGroup


------EquipmentCategory Database----------

create table EquipmentCategory(EquipmentCategoryId int primary key identity(1,1), EquipmentCategoryName varchar(20))



---- Adding EquipmentCategory
create procedure usp_AddEquipmentCategory @EquipmentCategoryId int out, @EquipmentCategoryName varchar(20)
as
begin
insert into EquipmentCategory values (@EquipmentCategoryName)
set @EquipmentCategoryId=SCOPE_IDENTITY()
end

execute usp_AddEquipmentCategory 1,'EC2'


---- Update EquipmentCategory
create procedure usp_UpdateEquipmentCategory @EquipmentCategoryId int, @EquipmentCategoryName varchar(20)
as
begin
update EquipmentCategory set EquipmentCategoryName=@EquipmentCategoryName where EquipmentCategoryId=@EquipmentCategoryId
end

execute usp_UpdateEquipmentCategory 1,'EC1'


---- Delete EquipmentCategory
create procedure usp_DeleteEquipmentCategory @EquipmentCategoryId int
as
begin
delete from EquipmentCategory  where EquipmentCategoryId=@EquipmentCategoryId
end

execute usp_DeleteEquipmentCategory 1

insert into EquipmentCategory values ('Smart Phone')
select * from EquipmentCategory 



drop table EquipmentDB

drop table EquipmentGroup

drop table EquipmentCategory
