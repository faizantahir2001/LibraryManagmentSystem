SELECT * FROM BookTable;

SELECT BookTitle, Author FROM BookTable;

SELECT * FROM BookTable WHERE DepartmentID = 1;

SELECT * FROM BookTable ORDER BY Price DESC;

SELECT COUNT(*) FROM BookTable;

SELECT DepartmentID, COUNT(*) FROM EmployeeTable GROUP BY DepartmentID;

SELECT DepartmentID, COUNT(*) FROM EmployeeTable GROUP BY DepartmentID HAVING COUNT(*) > 5;

SELECT * FROM BookTable INNER JOIN DepartmentTable ON BookTable.DepartmentID = DepartmentTable.DepartmentID;

SELECT BookTitle FROM BookTable WHERE DepartmentID = (SELECT DepartmentID FROM DepartmentTable WHERE Name = 'Computer Science');

DECLARE @EmployeeID INT = 15307; 
SELECT *FROM BookTable 
WHERE BookID IN (SELECT BookID FROM IssueBookTable WHERE EmployeeID = @EmployeeID);

SELECT SUM(FineAmount) AS TotalFineAmount FROM BookFineTable;

SELECT EmployeeID, COUNT(*) AS TotalBooksIssued FROM IssueBookTable GROUP BY EmployeeID HAVING COUNT(*) > 5;

SELECT DepartmentID, AVG(Price) AS AvgPrice FROM BookTable GROUP BY DepartmentID;

SELECT BookTitle, Qty, UnitPrice FROM BookTable 
INNER JOIN PurchaseDetailTable ON BookTable.BookID = PurchaseDetailTable.BookID;

SELECT EmployeeID, 
       COUNT(CASE WHEN Status = 1 THEN 1 END) AS BooksIssued, 
       COUNT(CASE WHEN Status = 0 THEN 1 END) AS BooksReturned 
FROM IssueBookTable 
GROUP BY EmployeeID;

SELECT DepartmentID, COUNT(*) AS TotalBooks FROM BookTable GROUP BY DepartmentID;

SELECT TOP 5 BookID, COUNT(*) AS TotalBorrowed 
FROM IssueBookTable 
GROUP BY BookID 
ORDER BY TotalBorrowed DESC;

SELECT SupplierID, SUM(PurchaseAmount) AS TotalPurchaseAmount 
FROM PurchaseTable 
GROUP BY SupplierID;

SELECT UserID FROM UserTable WHERE UserID NOT IN (SELECT UserID FROM BookFineTable);

