create table Library(
	LName  varchar(50) primary key,
	LCurator varchar(50) not null,
	LPhone   varchar(30) not null,
	LAdress  varchar(50) not null,
	LEmail   varchar(50) not null,
	LSite    varchar(50) not null,
	LCreateTime  datetime  not null,
	LIntroduce   varchar(max) not null
);

insert into Library(LName,LCurator,LPhone,LAdress,LEmail,LSite,LCreateTime,LIntroduce) values('����ͼ���','����','02783835937','�人�г~����','bingwenwuhen@163.com','www.bingwenLibrary.com','2014-11-9','��õ�ͼ���');

exec sp_rename 'Library.LAdress','LAddress','column';  
select * from Library;