use [SocietyManagement]

select * from [dbo].[VisitorLog]

select * from [dbo].[Society]


asdla

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