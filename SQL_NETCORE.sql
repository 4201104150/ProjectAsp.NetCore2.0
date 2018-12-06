create database QLSinhvien_NETCORE
go

use QLSinhvien_NETCORE
go

create table Khoa
(
	MaKhoa varchar(10) constraint pk_khoa primary key,
	TenKhoa nvarchar(100) not null unique,
	Nam INT null,
	HinhKhoa varchar(max) null,
)
go

create table Sinhvien
(
	MaSv varchar(10),
	TenSv nvarchar(100) not null,
	Nam int check (nam>=1 and nam<=8),
	MaKhoa varchar(10),
	HinhSV varchar(max) null,
	constraint pk_sinhvien primary key (MaSv),
	constraint fk_sinhvien_k foreign key (MaKhoa) references Khoa(MaKhoa)
)
go

create table Monhoc
(
	MaMh varchar(10) constraint pk_Monhoc primary key, 
	TenMh nvarchar(100) not null,
	Tinchi int null,
	MaKhoa varchar(10),
	constraint fk_Monhoc foreign key (MaKhoa) references Khoa(Makhoa), 
)
go
create table Hocphan
(
	MaHp varchar(10) constraint pk_Hocphan primary key,
	MaMh varchar(10),
	Hocky int check(Hocky<=3 and Hocky>=0),
	Nam int, 
	Giangvien nvarchar(100),
	constraint fk_Hocphan_k foreign key(MaMh) references Monhoc (MaMh)
)
go
create table Ketqua
(
	MaSv varchar(10),
	MaHp varchar(10),
	Diem int check (Diem >=0 and Diem <=10),
	constraint pk_Ketqua primary key(MaSv,MaHp),
	constraint fk_Ketqua_SV foreign key (MaSv) references Sinhvien(MaSv),
	constraint fk_Ketqua_HP foreign key (MaHp) references HocPhan (MaHp),
)
go

create table Dieukien
(
	MaMh varchar(10),
	MaMh_truoc varchar(10),
	constraint pk_Dieukien primary key (MaMh,MaMh_truoc),
	constraint pk_Dieukien_Mh  foreign key (MaMh) references  Monhoc(MaMh),
	constraint pk_Dieukien_Mh_truoc  foreign key (MaMh_truoc) references  Monhoc(MaMh),
)
go

/*insert into Khoa values
 ('VLy',N'VậtLý',1982),
 ('Toan',N'Toán',1976),
 ('Sinh',N'Sinh',1981),
 ('Hoa',N'Hoá',1980)
go 

insert into Sinhvien values
 ('K25.0005',N'Lý Thành',3,'Hoa'),
 ('K26.0008',N'Phan Anh Khanh',2,'Toan'),
 ('K27.0017',N'Nguyễn Công Phú',1,'Toan'),
 ('K27.0018',N'Hán Quốc Việt',2,'VLy')
go

insert into Monhoc values
 ('HH0001',N'Hóa Đại Cương A1',5,'Hoa'),
 ('HH0002',N'Hóa Đại Cương A2',5,'Hoa'),
 ('TH0001',N'Tin Học Cương A1',4,'Toan'),
 ('TH0002',N'Cấu Trúc Dữ Liệu',4,'Toan'),
 ('TO0001',N'Toán Rơi Rạc',3,'Toan'),
 ('TH0003',N'Cơ Sở Dữ Liệu',5,'Toan'),
 ('VL0001',N'Vật Lý Cương A1',5,'VLy'),
 ('VL0002',N'Vật Lý Cương A2',4,'VLy')
go

insert into Hocphan values
 ('1','TH0001','1',1996,N'N.D.Lâm'),
 ('2','VL0001','1',1994,N'T.N.Dung'),
 ('3','TH0002','1',1997,N'H.Tuân'),
 ('4','TH0001','1',1997,N'N.D.Lâm'),
 ('5','TH0003','2',1997,N'N.C.Phú'),
 ('6','HH0001','1',1996,N'N.T.Phúc'),
 ('7','TH0002','1',1998,N'P.T.Nhu'),
 ('8','TO0001','1',1996,'N.C.Phú')
go

insert into Dieukien values 
('HH0002','HH0001'),
('TH0002','TH0001'),
('TH0003','TH0002'),
('TH0003','TO0001'),
('VL0002','VL0001')
go

insert into Ketqua values
('K25.0005','6',6),
('K26.0008','1',10),
('K26.0008','3',9),
('K27.0017','4',9.5),
('K27.0018','2',8)*/
