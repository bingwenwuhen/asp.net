create table Purview(
Id varchar(50) primary key,
Sysset	bit null,
Readset bit null,
Bookset bit null,
Borrowback bit null,
Sysquery bit  null
);

alter table Purview add  LoginName varchar(50);
alter table Purview alter column Id  int;
insert into Purview(id,LoginName,Sysset,Readset,Bookset,Borrowback,Sysquery) values(1,'bingwen',1,1,1,1,1);
exec sp_rename 'Purview.Sysset','SysSet','column';
exec sp_rename 'Purview.Readset','ReadSet','column';
exec sp_rename 'Purview.Bookset','BookSet','column';
exec sp_rename 'Purview.Sysquery','SysQuery','column';
exec sp_rename 'Purview.Borrowback','BorrowBack','column';
select * from Purview;
--…Ë÷√LoginNameŒ™∑«ø’
alter table Purview alter column LoginName varchar(50) not null;