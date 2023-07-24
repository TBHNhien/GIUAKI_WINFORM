﻿CREATE DATABASE QUANLYSV
GO

DROP DATABASE QUANLYSV

CREATE TABLE LOP
(
	MALOP CHAR(3) PRIMARY KEY ,
	TENLOP NVARCHAR (30) NOT NULL
)

CREATE TABLE SINHVIEN
(
	MASV CHAR(6) PRIMARY KEY,
	HOTENSV NVARCHAR(40) , 
	NGAYSINH DATETIME ,
	MALOP CHAR(3) FOREIGN KEY REFERENCES LOP(MALOP)
)


DROP TABLE SINHVIEN
DELETE FROM SINHVIEN

INSERT INTO LOP VALUES (1 , N'CONG NGHE THONG TIN 1 ')
INSERT INTO LOP VALUES (2 , N'HE THONG THONG TIN 2 ')
INSERT INTO LOP VALUES (3 , N'KE TOAN KHOA 1 ')
INSERT INTO LOP VALUES (4 , N'LUAT KINH TE 1 ')

INSERT INTO SINHVIEN VALUES ('000001' , N'THAI BAO HAO NHIEN','1995-8-21', '1')
INSERT INTO SINHVIEN VALUES('000002' , N'NGUYEN HOANG PHONG ','2000-3-20' , '1')
INSERT INTO SINHVIEN VALUES('000003' , N'NGUYỄN QUỐC AN','2003-3-20' , '2')
INSERT INTO SINHVIEN VALUES('000004',N'LE GIA HAN','5-4-2002' , '3')


SELECT * FROM SINHVIEN







