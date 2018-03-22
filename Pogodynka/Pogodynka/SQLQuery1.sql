select * from AspNetRoles;
insert into AspNetRoles values('1','Administrator');
--insert into AspNetRoles values('1','');
delete from AspNetUsers;
update AspNetRoles set Name = 'Administrator' where AspNetRoles.Id = 1;
select * from AspNetUsers;