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

insert into Library(LName,LCurator,LPhone,LAdress,LEmail,LSite,LCreateTime,LIntroduce) values('夏轩图书馆','冰纹','02783835937','武汉市硚口区','bingwenwuhen@163.com','www.bingwenLibrary.com','2014-11-9','最好的图书馆');

exec sp_rename 'Library.LAdress','LAddress','column';  
select * from Library;