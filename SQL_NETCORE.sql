create database QLSinhvien_NET
go

use QLSinhvien_NET
go

create table Khoa
(
	MaKhoa varchar(10) constraint pk_khoa primary key,
	TenKhoa nvarchar(100) not null unique,
	Nam INT null,
	ThongTinKhoa nvarchar(max)
)
go

create table Sinhvien
(
	id int identity(1,1),
	MaSv varchar(10) unique not null,
	Pass nvarchar(max) not null,
	TenSv nvarchar(100) not null,
	Nam int check (nam>=1 and nam<=8),
	MaKhoa varchar(10),
	HinhSV varchar(max) null,
	Gioitinh nvarchar(4) check(Gioitinh = N'Nam' or Gioitinh = N'Nữ'),
	CMND nvarchar(20),
	Diachi nvarchar(255),
	constraint pk_sinhvien primary key (id),
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
	MaSvc varchar(10),
	MaHp varchar(10),
	Diem int check (Diem >=0 and Diem <=10),
	constraint pk_Ketqua primary key(MaSvc,MaHp),
	constraint fk_Ketqua_SV foreign key (MaSvc) references Sinhvien(MaSv),
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
create table NhanVien 
(
	id int identity(1,1),
	MaNv varchar(10) unique not null,
	Pass varchar(max) not null,
	TenNv nvarchar(100) not null,
	Ngayvaolam datetime,
	MaKhoa varchar(10),
	HinhNV varchar(max) null,
	Gioitinh nvarchar(4) check(Gioitinh = N'Nam' or Gioitinh = N'Nữ'),
	CMND nvarchar(20),
	Diachi nvarchar(255),
	constraint pk_nhanvien primary key (id),
	constraint fk_nhanvien_k foreign key (MaKhoa) references Khoa(MaKhoa)
)
