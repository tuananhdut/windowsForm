create database Quan_ly_dao_tao
go 

use Quan_ly_dao_tao
go 

CREATE TABLE GiangVien (
    MaGiangVien int IDENTITY(1,1) PRIMARY KEY,
    TenGiangVien nvarchar(50),
    NgaySinh datetime,
    Khoa nvarchar(50),
    HocHam nvarchar(20),
    HocVi nvarchar(20),
    GioiTinh bit
);

CREATE TABLE HocPhan (
    MaHocPhan int IDENTITY(1,1) PRIMARY KEY,
    TenHocPhan nvarchar(50)
);

CREATE TABLE PhanCong (
    MaGiangVien int,
    MaHocPhan int,
    PRIMARY KEY (MaGiangVien, MaHocPhan),
    FOREIGN KEY (MaGiangVien) REFERENCES GiangVien(MaGiangVien),
    FOREIGN KEY (MaHocPhan) REFERENCES HocPhan(MaHocPhan)
);


-- tạo dữ liệu giảng vien
INSERT INTO GiangVien (TenGiangVien, NgaySinh, Khoa, HocHam, HocVi, GioiTinh)
VALUES ('Nguyen Van A', '1980-01-01', N'Khoa A', N'Giáo sư', N'Tiến sỹ khoa học', 1)

INSERT INTO GiangVien (TenGiangVien, NgaySinh, Khoa, HocHam, HocVi, GioiTinh)
VALUES ('Tran Thi B', '1985-02-15', N'Khoa B', N'Phó Giáo sư', N'Tiến sỹ', 0)

INSERT INTO GiangVien (TenGiangVien, NgaySinh, Khoa, HocHam, HocVi, GioiTinh)
VALUES ('Pham Van C', '1990-03-31', N'Khoa C', N'Phó Giáo sư' , N'Thạc sỹ', 1)



-- tạo dữ liệu học phần
INSERT INTO HocPhan (TenHocPhan)
VALUES (N'Toan')

INSERT INTO HocPhan (TenHocPhan)
VALUES (N'Ly')

INSERT INTO HocPhan (TenHocPhan)
VALUES (N'Hoa')

-- phan cong
INSERT INTO PhanCong (MaGiangVien, MaHocPhan)
VALUES (1, 1)

INSERT INTO PhanCong (MaGiangVien, MaHocPhan)
VALUES (1, 2)

INSERT INTO PhanCong (MaGiangVien, MaHocPhan)
VALUES (2, 2)

INSERT INTO PhanCong (MaGiangVien, MaHocPhan)
VALUES (3, 3)


--select * from GiangVien,HocPhan,PhanCong  
select * from GiangVien
select * from PhanCong
select *from HocPhan