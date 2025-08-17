-- Table: Ambulances
CREATE TABLE IF NOT EXISTS Ambulances (
    Id INT PRIMARY KEY,
    PlateNumber VARCHAR(50) NOT NULL,
    Status VARCHAR(50),
    Location VARCHAR(100),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Appointments
CREATE TABLE IF NOT EXISTS Appointments (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    PatientId UNIQUEIDENTIFIER,
    DoctorId UNIQUEIDENTIFIER,
    AppointmentDate DATETIME,
    Status VARCHAR(50),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Beds
CREATE TABLE IF NOT EXISTS Beds (
    Id INT PRIMARY KEY,
    RoomId INT,
    BedNumber VARCHAR(50),
    IsOccupied BIT,
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: CareGivers
CREATE TABLE IF NOT EXISTS CareGivers (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Relationship VARCHAR(50),
    ContactNumber VARCHAR(20),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Departments
CREATE TABLE IF NOT EXISTS Departments (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: DischargeSummaries
CREATE TABLE IF NOT EXISTS DischargeSummaries (
    Id INT PRIMARY KEY,
    PatientId INT,
    Summary TEXT,
    Date DATETIME,
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Doctors
CREATE TABLE IF NOT EXISTS Doctors (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Specialty VARCHAR(100),
    LicenseNumber VARCHAR(50),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Equipment
CREATE TABLE IF NOT EXISTS Equipment (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Type VARCHAR(50),
    Status VARCHAR(50),
    LastMaintenance VARCHAR(50),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: InsuranceProviders
CREATE TABLE IF NOT EXISTS InsuranceProviders (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    ContactNumber VARCHAR(20),
    Address VARCHAR(255),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Invoices
CREATE TABLE IF NOT EXISTS Invoices (
    Id INT PRIMARY KEY,
    PatientId INT,
    Amount DECIMAL(18,2),
    DateIssued DATETIME,
    Status VARCHAR(50),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: LabTests
CREATE TABLE IF NOT EXISTS LabTests (
    Id INT PRIMARY KEY,
    PatientId INT,
    TestName VARCHAR(100),
    Result VARCHAR(255),
    Date DATETIME,
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: MedicalRecords
CREATE TABLE IF NOT EXISTS MedicalRecords (
    Id INT PRIMARY KEY,
    PatientId INT,
    Diagnosis VARCHAR(255),
    Treatment VARCHAR(255),
    RecordDate DATETIME,
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Medications
CREATE TABLE IF NOT EXISTS Medications (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    Quantity INT,
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Notifications
CREATE TABLE IF NOT EXISTS Notifications (
    Id INT PRIMARY KEY,
    UserId INT,
    Message VARCHAR(255),
    CreatedAt DATETIME,
    IsRead BIT,
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Nurses
CREATE TABLE IF NOT EXISTS Nurses (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    LicenseNumber VARCHAR(50),
    Department VARCHAR(100),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Patients
CREATE TABLE IF NOT EXISTS Patients (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    DOB DATETIME,
    Gender VARCHAR(10),
    MedicalRecordNumber VARCHAR(50),
    DoctorId UNIQUEIDENTIFIER,
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Prescriptions
CREATE TABLE IF NOT EXISTS Prescriptions (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    PatientId UNIQUEIDENTIFIER,
    DoctorId UNIQUEIDENTIFIER,
    MedicationId UNIQUEIDENTIFIER,
    DatePrescribed DATETIME,
    Dosage VARCHAR(100),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Referrals
CREATE TABLE IF NOT EXISTS Referrals (
    Id INT PRIMARY KEY,
    PatientId INT,
    FromDoctorId INT,
    ToDoctorId INT,
    Reason VARCHAR(255),
    Date VARCHAR(50),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Rooms
CREATE TABLE IF NOT EXISTS Rooms (
    Id INT PRIMARY KEY,
    RoomNumber VARCHAR(50) NOT NULL,
    Type VARCHAR(50),
    DepartmentId INT,
    IsOccupied BIT,
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Shifts
CREATE TABLE IF NOT EXISTS Shifts (
    Id INT PRIMARY KEY,
    StaffId INT,
    StartTime DATETIME,
    EndTime DATETIME,
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Staff
CREATE TABLE IF NOT EXISTS Staff (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Role VARCHAR(50),
    ContactNumber VARCHAR(20),
    DepartmentId INT,
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Supplies
CREATE TABLE IF NOT EXISTS Supplies (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Quantity INT,
    Unit VARCHAR(20),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Surgeries
CREATE TABLE IF NOT EXISTS Surgeries (
    Id INT PRIMARY KEY,
    PatientId INT,
    DoctorId INT,
    SurgeryType VARCHAR(100),
    Date DATETIME,
    Notes VARCHAR(255),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Transactions
CREATE TABLE IF NOT EXISTS Transactions (
    Id INT PRIMARY KEY,
    InvoiceId INT,
    Amount DECIMAL(18,2),
    TransactionDate DATETIME,
    PaymentMethod VARCHAR(50),
    BankName VARCHAR(100),
    AccountNumber VARCHAR(50),
    TransactionReference VARCHAR(100),
    Status VARCHAR(50),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Users
CREATE TABLE IF NOT EXISTS Users (
    Id INT PRIMARY KEY,
    Email VARCHAR(100) NOT NULL,
    PasswordHash VARCHAR(255),
    Role VARCHAR(50),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: UserAccounts
CREATE TABLE IF NOT EXISTS UserAccounts (
    Id INT PRIMARY KEY,
    Username VARCHAR(100) NOT NULL,
    PasswordHash VARCHAR(255),
    Role VARCHAR(50),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);

-- Table: Visits
CREATE TABLE IF NOT EXISTS Visits (
    Id INT PRIMARY KEY,
    PatientId INT,
    VisitDate DATETIME,
    Reason VARCHAR(255),
    Notes VARCHAR(255),
    CreatedBy VARCHAR(50),
    CreatedDateTime DATETIME,
    LastModifiedBy VARCHAR(50),
    LastModifiedDateTime DATETIME,
    IsDeleted BIT DEFAULT 0
);
