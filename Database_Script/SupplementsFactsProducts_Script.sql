CREATE DATABASE FORMSUPPLEMENTPRODUCT
USE FORMSUPPLEMENTPRODUCT
CREATE TABLE CUSTOMER (
	id_Customer nvarchar(50)NOT NULL PRIMARY KEY,
	name_Customer nvarchar(50)NOT NULL,
	address_Customer    NVARCHAR (50) NOT NULL,
    phoneNumber_Customer NVARCHAR (50) NOT NULL,
);
CREATE TABLE DETAILS_IMPORT (
	id_InvoiceImport NVARCHAR (50) NOT NULL PRIMARY KEY,
    id_Product       NVARCHAR (50) NOT NULL,
    numberOf_Product  FLOAT (53)    NOT NULL,
    unitSelling_Price FLOAT (53)    NOT NULL,
    intomoney         FLOAT (53)    NOT NULL,
);

CREATE TABLE INVOICE(
	id_Invoice  NVARCHAR (50) NOT NULL PRIMARY KEY,
    dateOfSale  DATETIME      NOT NULL,
    id_Customer NVARCHAR (50) NOT NULL,
    total       FLOAT (53)    NOT NULL,
);
CREATE TABLE Invoice_Import (
    id_InvoiceImport NVARCHAR (50) NOT NULL PRIMARY KEY,
    id_vendor       NVARCHAR (50) NOT NULL,
    dateofImport    DATETIME      NOT NULL,
    total            FLOAT (53)    NULL,
);
CREATE TABLE Invoice_Sale (
    id_Invoice  NVARCHAR (50) NOT NULL PRIMARY KEY,
    dateOfSale  DATETIME      NOT NULL,
    id_Customer NVARCHAR (50) NOT NULL,
    total       FLOAT (53)    NOT NULL,
);

CREATE TABLE Product (
    id_Product        NVARCHAR (50)  NOT NULL PRIMARY KEY,
    name_Product      NVARCHAR (50)  NOT NULL,
    numberOf_Product  FLOAT (53)     NOT NULL,
    importUnit_Price FLOAT (53)     NOT NULL,
    unitSelling_Price FLOAT (53)     NOT NULL,
    Image             NVARCHAR (200) NOT NULL,
    Note              NVARCHAR (300) NULL,
);
CREATE TABLE vendor (
    id_vendor      NVARCHAR (50) NOT NULL PRIMARY KEY,
    name_vendor   NVARCHAR (50) NOT NULL,
    address_vendor NVARCHAR (50) NOT NULL,
    phone_vendor   NVARCHAR (50) NOT NULL,
);

CREATE TABLE Invoice_Delivery (
    id_InvoiceDelivery      NVARCHAR (50) NOT NULL PRIMARY KEY,
    DateOfInvoiceDelivery   NVARCHAR (50) NOT NULL,
    id_Customer NVARCHAR (50) NOT NULL,
    name_Customer   NVARCHAR (50) NOT NULL,
);


INSERT INTO Product
VALUES 
('P01', 'Awaken', 5000, 30000,35000, '/Image/Image1.jpg', 'Awaken - Organic Energy Supplement - 2 oz Liquid in a Glass Bottle - by Khroma Herbs'),
('P02', 'Neuriva', 3000, 55000,60000, '/Image/Image2.jpg', 'NEURIVA Plus Brain Supplement For Memory, Focus & Concentration + Cognative Function with Vitamins B6'),
('P03', 'Goli Apple Cider', 4000, 25000,30000, '/Image/Image3.jpg', 'Goli Apple Cider Vinegar Gummy Vitamins - 60 Count - Vitamins B9 & B12, Gelatin-Free, Gluten-Free'),
('P04', 'Natura Health', 5000, 15000,22000, '/Image/Image4.jpg', 'Natura Health Products - Zinc - 25 mg. Highly Bioavailable Food-Grown Zinc - 60 Capsules'),
('P05', 'OLLY Ultra ', 1000, 20000,35000, '/Image/Image5.jpg', 'OLLY Ultra Strength Hair Softgels, Supports Hair Strength, Health and Growth, Biotin, Keratin, Vitamin D'),
('P06', 'NaturalSlim', 2000, 100000,150000, '/Image/Image6.jpg', 'NaturalSlim Magicmag Pure Magnesium Citrate Powder – Stress, Constipation, Muscle, Heart Health,'),
('P07', 'Garden of Life Dr. Formulated', 1500, 25000,27000, '/Image/Image7.jpg', 'Nature’s Way Sambucus Elderberry Gummies, Immune Support Gummies*, Black Elderberry with'),
('P08', 'Liquid Biotin & Collagen Hair Growth', 1100, 20000,23000, '/Image/Image8.jpg', 'Liquid Biotin & Collagen Hair Growth Drops 50,000mcg – Biotin and Liquid Collagen Supplements for Women '),
('P09', 'Liver Cleanse Detox', 1200, 22000,24000, '/Image/Image9.jpg', 'Liver Cleanse Detox & Repair Formula - Herbal Liver Support Supplement with Milk Thistle Dandelion Root'),
('P010', 'Jarrow Formulas', 3500, 11000,15000, '/Image/Image10.jpg', 'Jarrow Formulas MK-7 90 mcg - Superior Vitamin K Product for Building Strong Bones - Dietary')

INSERT INTO Customer
VALUES 
('C01','William Griffiths','TPHCM','0123456789'),
('C02','Taylor Campbell','KienGiang','038434127'),
('C03','David Reid','QuangNam','054072550'),
('C04','Harvey Murphy','DaNang','02691709'),
('C05','Aiden Shaw','HaNoi','038244855'),
('C06','Junior Anthony','TienGiang','038487235'),
('C07','Emery Jensen','BinhThuan','038331706'),
('C08','Joshua Combs','NhaTrang','0550608'),
('C09','Jovanni Peterson','VungTau','038435021')

INSERT INTO vendor
VALUES 
('V01','Lucas Sharp','TPHCM','0123456789'),
('V02','Evan Thompson','KienGiang','038434127'),
('V03','Ashton Matthews','QuangNam','054072550'),
('V04','Robert Lowe','DaNang','02691709'),
('V05','Leo Lawrence','HaNoi','038244855'),
('V06','Bradyn Guerra','TienGiang','038487235'),
('V07','Maddox Burke','BinhThuan','038331706'),
('V08','Kareem Norman','NhaTrang','0550608'),
('V09','Kylen Oneal','VungTau','038435021')

INSERT INTO Invoice_Import(id_InvoiceImport, id_vendor, dateofImport)
VALUES 
('II01','V01',2022-12-03),
('II02','V02',2022-11-03),
('II03','V03',2022-10-03),
('II04','V04',2022-09-03),
('II05','V05',2022-08-03),
('II06','V06',2022-07-03),
('II07','V07',2022-06-03),
('II08','V08',2022-05-03),
('II09','V09',2022-04-03)


INSERT INTO DETAILS_IMPORT(id_InvoiceImport, id_Product, numberOf_Product, importUnit_Price)
VALUES
('II01','P01',4000,3000),
('II02','P02',2000,3000),
('II03','P03',3000,3000),
('II04','P04',4000,3000),
('II05','P05',500,3000),
('II06','P06',1000,3000),
('II07','P07',1000,3000),
('II08','P08',500,3000),
('II09','P09',1100,3000)


SELECT a.id_Product, b.name_Product, a.numberOf_Product, b.importUnit_Price,a.intomoney FROM Details_Import AS a, Product AS b WHERE a.id_InvoiceImport = N'II05' AND a.id_Product = b.id_Product
SELECT * From DETAILS_IMPORT
Select * From Vendor

CREATE TABLE DETAILS_Delivery (
	id_InvoiceDelivery NVARCHAR (50) NOT NULL PRIMARY KEY,
    id_Product       NVARCHAR (50) NOT NULL,
    numberOf_Product  FLOAT (53)    NOT NULL,
    unitSelling_Price FLOAT (53)    NOT NULL,
    intomoney         FLOAT (53)    NOT NULL,
);

ALTER TABLE Details_Delivery
ADD id_Customer varchar(255);