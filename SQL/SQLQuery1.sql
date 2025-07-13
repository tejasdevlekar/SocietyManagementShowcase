
use [SocietyManagement]

select * from [dbo].[VisitorLog]

select * from [dbo].[Gym]
select *  from [dbo].[SwimmingPool]
select * from [dbo].[CommonAmenities]


select * from [dbo].[MaintenanceLog] order by id desc

insert into [dbo].[MaintenanceLog]
select MaintenaceDoneByName, MaintenaceCheckedByName, DateAndTime, Reason, Remarks, EngineId, WaterTankId, CommonAmenitiesId, GymId, SwimmingPoolId, WaterFiltrationSystemId
from [dbo].[MaintenanceLog]

select * from [dbo].[Society]

Id, Name, NoOfWings, FireSystemId, WaterFilterId, IndoorGymId, Health, TotalFlatAreaSociety, TotalMaintenanceChargeSociety

select * from [dbo].[Flat]

select * 
into #tempUsers
from [dbo].[Users]

select * into #temp
from 

select * from [dbo].[Users]
select * from [dbo].[MaintenanceLog]

delete from [dbo].[MaintenanceLog] where id =1
select * from #temp

insert into [dbo].[MaintenanceLog]
select MaintenaceDoneByName, MaintenaceCheckedByName, DateAndTime, Reason, Remarks, EngineId, WaterTankId, CommonAmenitiesId, GymId, SwimmingPoolId, WaterFiltrationSystemId
from #temp

select * from [dbo].[MaintenanceLog]

select * 
into [dbo].[Users]
from #tempUsers
select * from #tempUsers

select * from [dbo].[Users]
update [dbo].[Users] set Username ='Member', RoleType =4 where id=6

insert into [dbo].[Users]
(Username, Password, PersonId)
select Username, Password, PersonId
from #tempUsers