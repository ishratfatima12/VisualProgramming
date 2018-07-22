create database C_M_S;
create table Items1 (I_ID int identity(1,1),I_name varchar (50),I_QTY int,ITP numeric,IRT numeric,primary key(I_ID));
insert into Items1(I_name,I_QTY,ITP,IRT)values('Black Coffee','10','500','600');
insert into Items1(I_name,I_QTY,ITP,IRT)values('Cold Coffee','10','500','600');
insert into Items1(I_name,I_QTY,ITP,IRT)values('Coffee','09','550','600');
insert into Items1(I_name,I_QTY,ITP,IRT)values('Nuggets','15','600','650');
insert into Items1(I_name,I_QTY,ITP,IRT)values('Samosa','10','400','500');
select * from Items1;


create table vendors(VID int identity (1,1),VName varchar(50),VPNO int,VCMP varchar(50),VAdd varchar (50),VEmail varchar(50),primary key(VID));
insert into vendors (VName,VPNO,VCMP,VAdd,VEmail)values ('Ali','051643876','Alis Coffee System','Islamabad','Ali@gmail.com');
insert into vendors (VName,VPNO,VCMP,VAdd,VEmail)values ('Usman','042875454','Usmans Coffee System','Lahore','Usman@gmail.com');
insert into vendors (VName,VPNO,VCMP,VAdd,VEmail)values ('Zain','021357640','Zains Coffee System','Karachi','Zain@gmail.com');
insert into vendors (VName,VPNO,VCMP,VAdd,VEmail)values ('Waleed','032615288','Waleed Coffee System','Multan','Waleed@gmail.com');
insert into vendors (VName,VPNO,VCMP,VAdd,VEmail)values ('Hassan','030287352','Hassans Coffee System','Chakwal','Hassan@gmail.com');
select * from vendors;

create table Cutomer(CID int identity (1,1),CName varchar(50),CPNO int,CAdd varchar (50),CEmail varchar(50),primary key(CID));
insert into Cutomer(CName,CPNO,CAdd,CEmail)values ('Asad','051643876','Islamabad','Asad@gmail.com');
insert into Cutomer(CName,CPNO,CAdd,CEmail)values ('Qasim','042875454','Rawalpindi','Qasim@gmail.com');
insert into Cutomer(CName,CPNO,CAdd,CEmail)values ('Asma','021357640','Karachi','Asma@gmail.com');
insert into Cutomer(CName,CPNO,CAdd,CEmail)values ('Ishrat','032615288','Multan','Ishrat@gmail.com');
insert into Cutomer(CName,CPNO,CAdd,CEmail)values ('Naila','030287352','Hunza','Naila@gmail.com');
select * from Cutomer;




