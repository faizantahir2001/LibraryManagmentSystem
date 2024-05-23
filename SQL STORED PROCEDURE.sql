--SQL Stored Procedure:
CREATE PROCEDURE GetBookFineDetails
AS
BEGIN
    SELECT * FROM BookFineTable;
END

-- Stored procedure to insert a new record into the BookTable
CREATE PROCEDURE InsertBook
    @UserID INT,
    @DepartmentID INT,
    @BookTypeID INT,
    @BookTitle NVARCHAR(200),
    @ShortDescription NVARCHAR(500),
    @Author NVARCHAR(150),
    @BookName NVARCHAR(200),
    @Edition FLOAT,
    @TotalCopies INT,
    @RegDate DATE,
    @Price FLOAT,
    @Description NVARCHAR(500)
AS
BEGIN
    INSERT INTO BookTable (UserID, DepartmentID, BookTypeID, BookTitle, ShortDescription, Author, BookName, Edition, TotalCopies, RegDate, Price, Description)
    VALUES (@UserID, @DepartmentID, @BookTypeID, @BookTitle, @ShortDescription, @Author, @BookName, @Edition, @TotalCopies, @RegDate, @Price, @Description)
END

--CRUD Operations for One Master One Details:

-- Create
INSERT INTO DepartmentTable (Name, UserID) VALUES ('Marketing', 1);

-- Read
SELECT * FROM DepartmentTable;

-- Update
UPDATE DepartmentTable SET Name = 'Sales' WHERE DepartmentID = 1;

-- Delete
DELETE FROM DepartmentTable WHERE DepartmentID = 1003;


--CRUD Operations for One Master Many Details:

-- Create
INSERT INTO PurchaseTable (PurchaseDate, UserID, PurchaseAmount, SupplierID) VALUES ('2024-05-22', 1, 100.50, 1);
INSERT INTO PurchaseDetailTable (BookID, PurchaseID, Qty, UnitPrice) VALUES (1, 1, 2, 10.99);

-- Read
SELECT * FROM PurchaseTable;
SELECT * FROM PurchaseDetailTable;

-- Update
UPDATE PurchaseDetailTable SET Qty = 3 WHERE PurchaseDetailID = 1;

-- Delete
DELETE FROM PurchaseDetailTable WHERE PurchaseDetailID = 1;
DELETE FROM PurchaseTable WHERE PurchaseID = 1;

BEGIN TRY
    DECLARE @x INT = 1 / 0;
END TRY
BEGIN CATCH
    PRINT 'An error occurred: ' + ERROR_MESSAGE();
END CATCH



