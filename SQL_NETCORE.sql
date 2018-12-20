create database QLSinhvien_NET
go

use QLSinhvien_NET
go

create table Dangnhap
(
	username varchar(10) primary key,
	matkhau varchar(20) not null,
	loai int not null,
	constraint fk_sinhvien_dangnhap foreign key  (username) references Sinhvien(MaSv),
	constraint fk_nhanvien_dangnhap foreign key (username) references NhanVien(MaNv)
)
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
	MaSv varchar(10),
	TenSv nvarchar(100) not null,
	Nam int check (nam>=1 and nam<=8),
	MaKhoa varchar(10),
	HinhSV varchar(max) null,
	Gioitinh nvarchar(4) check(Gioitinh = N'Nam' or Gioitinh = N'Nữ'),
	CMND nvarchar(20),
	Diachi nvarchar(255),
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
create table NhanVien 
(
	MaNv varchar(10),
	TenNv nvarchar(100) not null,
	Ngayvaolam datetime,
	MaKhoa varchar(10),
	HinhNV varchar(max) null,
	Gioitinh nvarchar(4) check(Gioitinh = N'Nam' or Gioitinh = N'Nữ'),
	CMND nvarchar(20),
	Diachi nvarchar(255),
	constraint pk_nhanvien primary key (MaNv),
	constraint fk_nhanvien_k foreign key (MaKhoa) references Khoa(MaKhoa)
)
