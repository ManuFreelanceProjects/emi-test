-- Departments table
CREATE TABLE Departments (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL UNIQUE
);

-- Positions table (to normalize position names)
CREATE TABLE Positions (
    Id INT PRIMARY KEY,
    Title VARCHAR(100) NOT NULL UNIQUE
);

-- Employees table
CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    CurrentPositionId INT,
    DepartmentId INT,
    Salary DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (CurrentPositionId) REFERENCES Positions(Id),
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

-- Projects table
CREATE TABLE Projects (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description TEXT
);

-- EmployeeProjects: many-to-many relationship between Employees and Projects
CREATE TABLE EmployeeProjects (
    EmployeeId INT,
    ProjectId INT,
    AssignedDate DATE NOT NULL DEFAULT CURRENT_DATE,
    PRIMARY KEY (EmployeeId, ProjectId),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
);

-- PositionHistory table
CREATE TABLE PositionHistory (
    Id INT PRIMARY KEY,
    EmployeeId INT NOT NULL,
    PositionId INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (PositionId) REFERENCES Positions(Id)
);
