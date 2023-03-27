create database QLSV_thre_layer
go 

use QLSV_thre_layer
go 

CREATE TABLE Lop (
  MaLop INT PRIMARY KEY,
  TenLop VARCHAR(255) not null
);
go


CREATE TABLE SinhVien (
  MaSV VARChar(39) PRIMARY KEY,
  TenSV VARCHAR(255),
  GioiTinh bit not null , --1 nam 0 nu
  DiemTB FLOAT,
  MaLop INT not null,
	anh bit default 1,
	hoso bit default 1,
	cccd bit default 1,

  FOREIGN KEY (MaLop) REFERENCES Lop(MaLop)
);
go 



INSERT INTO Lop(MaLop, TenLop) VALUES (1, 'Lop A');
INSERT INTO Lop(MaLop, TenLop) VALUES (2, 'Lop B');
go

INSERT INTO SinhVien(MaSV, TenSV, GioiTinh, DiemTB, MaLop) VALUES (1, 'Nguyen Van A', 1, 8.5, 1);
INSERT INTO SinhVien(MaSV, TenSV, GioiTinh, DiemTB, MaLop) VALUES (2, 'Tran Thi B', 1, 7.5, 1);
INSERT INTO SinhVien(MaSV, TenSV, GioiTinh, DiemTB, MaLop) VALUES (3, 'Le Van C', 0, 6.0, 2);
INSERT INTO SinhVien(MaSV, TenSV, GioiTinh, DiemTB, MaLop) VALUES (4, 'Pham Thi D', 1, 9.0, 2);
go


select * from SinhVien,lop where lop.MaLop=SinhVien.MaLop and TenLop='lop A';
select * from SinhVien
select * from lop
update SinhVien set GioiTinh='nu',anh = 0 where MaSV=1

select * from SinhVien order by MaSV asc

select * from sinhvien where tenSV Like '%van%' and MaLop=1;


select * from SinhVien order by DiemTB asc