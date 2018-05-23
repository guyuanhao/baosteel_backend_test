﻿create table maintenance_items(
	id int NOT NULL PRIMARY KEY identity(1,1),
	project_name varchar(100),
	detail varchar(100),
	period int,
	key_point varchar(100),
	indication varchar(100),
	create_date datetime,
	responsible varchar(100),
	note text
);

create table info_items(
	id int NOT NULL PRIMARY KEY identity(1,1),
	project_name varchar(100),
	detail varchar(100),
	key_point varchar(100),
	indication varchar(100),
	check_date datetime,
	responsible varchar(100),
	if_check bit,
	note text
);

insert into maintenance_items(project_name, detail, period, key_point, indication, create_date, responsible, note) 
values ('test', 'test project maintenance1', '1', 'keyPoint1', 'inidication1', GETDATE(), 'yuanhao1', 'note1');
insert into maintenance_items(project_name, detail, period, key_point, indication, create_date, responsible, note) 
values ('test2', 'test project maintenance2', '1', 'keyPoint2', 'inidication2', 
'2018-05-20 07:16:33.293', 'yuanhao2', 'note2');

insert into info_items(project_name, detail, key_point, indication, check_date, responsible,if_check, note) 
values ('test3', 'test project maintenance23', 'keyPoint2', 'inidication2', 
'2018-05-10 07:16:33.293', 'yuanhao3', 1, 'note2');
insert into info_items(project_name, detail, key_point, indication, check_date, responsible,if_check, note) 
values ('test4', 'test project maintenance23', 'keyPoint2', 'inidication2', 
GETDATE(), 'yuanhao35', 1, 'note2');
insert into info_items(project_name, detail, key_point, indication, responsible,if_check, note) 
values ('test35', 'test project maintenance23', 'keyPoint2', 'inidication2', 
 'yuanhao343', 0, 'note2');

 drop table maintenance_items;
 drop table info_items;

 SET IDENTITY_INSERT maintenance_items ON;
 SET IDENTITY_INSERT info_items ON;