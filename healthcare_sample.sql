-- SQL Server script to create tables and insert sample data for CRUD operations

CREATE TABLE Patients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10),
    MedicalRecordNumber NVARCHAR(50)
);

CREATE TABLE Doctors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Specialty NVARCHAR(100),
    LicenseNumber NVARCHAR(50)
);

CREATE TABLE CareGivers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Relationship NVARCHAR(50),
    ContactNumber NVARCHAR(20)
);

CREATE TABLE Nurses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    LicenseNumber NVARCHAR(50),
    Department NVARCHAR(100)
);

-- Sample data for Patients
INSERT INTO Patients (Name, DateOfBirth, Gender, MedicalRecordNumber) VALUES
('John Doe', '1980-05-15', 'Male', 'MRN001'),
('Jane Smith', '1990-08-22', 'Female', 'MRN002');

-- Sample data for Doctors
INSERT INTO Doctors (Name, Specialty, LicenseNumber) VALUES
('Dr. Alice Brown', 'Cardiology', 'LIC1001'),
('Dr. Bob White', 'Neurology', 'LIC1002');

-- Sample data for CareGivers
INSERT INTO CareGivers (Name, Relationship, ContactNumber) VALUES
('Mary Johnson', 'Mother', '555-1234'),
('Paul Lee', 'Father', '555-5678');

-- Sample data for Nurses
INSERT INTO Nurses (Name, LicenseNumber, Department) VALUES
('Nurse Kelly Green', 'NUR2001', 'ICU'),
('Nurse Sam Black', 'NUR2002', 'ER');

-- Generate 1000 rows of sample data for each entity

-- Patients
DECLARE @i INT = 1;
WHILE @i <= 1000
BEGIN
    INSERT INTO Patients (Name, DateOfBirth, Gender, MedicalRecordNumber)
    VALUES (
        CONCAT('Patient_', @i),
        DATEADD(DAY, -1 * (ABS(CHECKSUM(NEWID())) % 15000), GETDATE()),
        CASE WHEN @i % 2 = 0 THEN 'Male' ELSE 'Female' END,
        CONCAT('MRN', RIGHT('0000' + CAST(@i AS VARCHAR(4)), 4))
    );
    SET @i = @i + 1;
END

-- Doctors
SET @i = 1;
WHILE @i <= 1000
BEGIN
    INSERT INTO Doctors (Name, Specialty, LicenseNumber)
    VALUES (
        CONCAT('Doctor_', @i),
        CASE WHEN @i % 3 = 0 THEN 'Cardiology' WHEN @i % 3 = 1 THEN 'Neurology' ELSE 'Pediatrics' END,
        CONCAT('LIC', RIGHT('1000' + CAST(@i AS VARCHAR(4)), 4))
    );
    SET @i = @i + 1;
END

-- CareGivers
SET @i = 1;
WHILE @i <= 1000
BEGIN
    INSERT INTO CareGivers (Name, Relationship, ContactNumber)
    VALUES (
        CONCAT('CareGiver_', @i),
        CASE WHEN @i % 3 = 0 THEN 'Mother' WHEN @i % 3 = 1 THEN 'Father' ELSE 'Sibling' END,
        CONCAT('555-', RIGHT('0000' + CAST(@i AS VARCHAR(4)), 4))
    );
    SET @i = @i + 1;
END

-- Nurses
SET @i = 1;
WHILE @i <= 1000
BEGIN
    INSERT INTO Nurses (Name, LicenseNumber, Department)
    VALUES (
        CONCAT('Nurse_', @i),
        CONCAT('NUR', RIGHT('2000' + CAST(@i AS VARCHAR(4)), 4)),
        CASE WHEN @i % 3 = 0 THEN 'ICU' WHEN @i % 3 = 1 THEN 'ER' ELSE 'Ward' END
    );
    SET @i = @i + 1;
END
