use [SocietyManagement]

select * from [dbo].[VisitorLog]

select * from [dbo].[Gym]
select * from[dbo].[SwimmingPool]
select * from [dbo].[CommonAmenities]

select * from [dbo].[MaintenanceLog]

insert into [dbo].[MaintenanceLog]
select MaintenaceDoneByName, MaintenaceCheckedByName, DateAndTime, Reason, Remarks, EngineId, WaterTankId, CommonAmenitiesId, GymId, SwimmingPoolId, WaterFiltrationSystemId
from [dbo].[MaintenanceLog]

[dbo].[Society]

Id, Name, NoOfWings, FireSystemId, WaterFilterId, IndoorGymId, Health, TotalFlatAreaSociety, TotalMaintenanceChargeSociety

select * from [dbo].[Flat]

select * 
into #tempUsers
from [dbo].[Users]

select * 
into [dbo].[Users]
from #tempUsers
select * from #tempUsers

select * from [dbo].[Users]
--update [dbo].[Users] set RoleType =1 where id=2

insert into [dbo].[Users]
(Username, Password, PersonId)
select Username, Password, PersonId
from #tempUsers