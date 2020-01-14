# SQL cheat sheet

## Basic database manipulating

Snippets to create\modify databases, tables

### Manipulating database

**Create DB**

```sql
CREATE DATABASE <DatabaseName>;
```

**Alter DB**

```sql
ALTER DATABASE <DatabaseName> MODIFY NAME = <NewDatabaseName>;
```

**Drop DB**

```sql
DROP DATABASE <DatabaseName>;
```

### Manipulating tables

**Create table**

```sql
-- Structure:
CREATE TABLE <TableName> (
    <ColumnName> <DataType> <ColumnConstraint>
);

-- Example:
CREATE TABLE Customers (
    ID INT NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    BirthDate DATETIME NOT NULL
);
```

**Alter table**

```sql
-- Add foreign key structure:
ALTER TABLE <TableName> ADD CONSTRAINT <ConstraintName> 
FOREIGN KEY (<ForeignKeyColumn>) REFERENCES <OtherTableName> (<PrimaryKeyOfOtherTable>);

-- Add column structure:
ALTER TABLE <TableName> ADD
<ColumnName> <DataType> <ColumnConstraint>;
```

**Drop table**

```sql
DROP TABLE <TableName>;
```

**Add 'default' constraint**

```sql
ALTER TABLE <TableName> ADD CONSTRAINT <ConstraintName> 
DEFAULT <DefaultValue> FOR <ExistingColumnName>;

ALTER TABLE <TableName> 
ADD <ColumnName> <DataType>
CONSTRAINT <ConstraintName> DEFAULT <DefaultValue>;
```

**Specifying cascading referential integrity constraint**

```sql
ALTER TABLE <TableName> ADD CONSTRAINT <ConstraintName> 
FOREIGN KEY (<ForeignKeyColumn>) REFERENCES <OtherTableName> (<PrimaryKeyOfOtherTable>)
ON DELETE CACADE ON UPDATE CACADE;
```

`NO ACTION` is default one. Rolls back transaction and rises an exception

`SET NULL` all columns of rows containing the foreign key are set NULL

`CASCADE` all rows containing the foreign key are deleted or updated

`SET DEFAULT` all columns of rows containing the foreign key are assigned with default value

**Add 'check' constraint**

```sql
ALTER TABLE <TableName> ADD CONSTRAINT <ConstraintName> 
CHECK (BOOLEAN_EXPRESSION);

ALTER TABLE Orders ADD CONSTRAINT AmountBiggerZero 
CHECK (Amount > 0);
```

**Add auto increment**

```sql
-- Add auto increment when create a table
CREATE TABLE Customers (
    Id INT IDENTITY (1, 1) PRIMARY KEY,
    Name VARCHAR(50)
);
```

**Get current IDENTITY value**

```sql
SELECT SCOPE_IDENTITY();
SELECT @@IDENTITY;
SELECT IDENT_CURRENT('Customers');
```

**Add 'unique' constraint**

```sql
ALTER TABLE <TableName>
ADD CONSTRAINT <ConstraintName> UNIQUE(ColumnName);
```

## SELECT statement

**Basic SELECT statement**

```sql
SELECT <ColumnName> FROM <TableName> WHERE <FilterCondition>;
```

**GROUP BY statement**

GROUP BY is used with aggregate functions to group a selected set of rows into a set of summary row

HAVING is used only after ORDER BY statement to filter aggregated data

Aggregate functions: `COUNT(), SUM(), AVG(), MIN(), MAX()`

```sql
SELECT Id, Name, SUM(Salary) as Salary, City FROM Staff
ORDER BY City
HAVING City = 'Kharkiv';
```

**Basic JOIN statement**

Types of JOIN: `CROSS JOIN`, `OUTER JOIN`, `INNER JOIN`. `OUTER JOIN` divided into 3 types: `LEFT OUTER JOIN`, `RIGHT OUTER JOIN`, `FULL OUTER JOIN`

`INNER JOIN` returns matching rows between both the tables. Non matching rows are eliminated

`LEFT OUTER JOIN` returns all rows from the left table. If there are not rows in the right table then it sets NULL to appropriate columns

`RIGHT OUTER JOIN` returns all rows from the right table. If there are not rows in left table then it sets NULL to appropriate columns

`CROSS JOIN` returns cartesian product of the tables involved to join

`FULL JOIN` returns all rows from both tables. If some rows don't match then it sets NULL to appropriate columns

Self JOIN is not different type of JOIN. Let's say you there's a 'Users' table. Self joining is like having two instance of the table and you just join the same table twice. 

```sql
-- General JOIN statement
SELECT <ColumnList> FROM <LeftTableName>
JOIN_TYPE <RightTableName>
ON <JoinCondition>
```

```sql
-- Retrieve only the non matching rows from the left table
SELECT <ColumnList> FROM <LeftTableName>
LEFT JOIN <RightTableName>
ON <JoinCondition>
WHERE <RightTablePK> is NULL
```

```sql
-- Retrieve only the non matching rows from the right table
SELECT <ColumnList> FROM <LeftTableName>
RIGHT JOIN <RightTableName>
ON <JoinCondition>
WHERE <LeftTablePK> is NULL
```

```sql
-- Retrieve only the non matching rows from both the left and right table
SELECT <ColumnList> FROM <LeftTableName>
FULL JOIN <RightTableName>
ON <JoinCondition>
WHERE <LeftTablePK> is NULL OR <RightTablePK> is NULL
```

![Joins visualization](./joins.png)

**Replace NULL with a value in SELECT statement**

```sql
SELECT Id, ISNULL(Name, 'No Name') as Name
FROM Customers;
-- Or
SELECT Id, CASE WHEN Name IS NULL THEN 'No Name' ELSE Name END
FROM Customers;
-- Or
SELECT Id, COALESCE(Name, 'No Name') as Name
FROM Customers;
```

> Note: COALESCE returns first non null value. Instead of string it's possible to pass there 


**UNION and UNION ALL operators**

These operators allow to combine the result-set of two or more SELECT queries.

```sql
SELECT Id, Name FROM UkraineCustomers;
UNION
SELECT Id, Name FROM BritishCustomers;
```

## Stored procedures

A stored procedure is a group of T-SQL statements. It allows to avoid duplications of the same query

Benefits of stored procedures:
1. Stored Procedures are compiled and their execution plan is cached and used again when the same procedure is executed again
1. Reducing network traffic
1. Code reusability and better maintainability. A procedure can be reused between different applications
1. Better security. Allows to restrict users who can execute the procedure
1. Avoid SQL injection attack

**Create stored procedure**

```sql
-- Procedure without parameters
CREATE PROCEDURE <ProcedureName>
AS
BEGIN
    SELECT * FROM <TableName>
END

-- Procedure with parameters
CREATE PROCEDURE <ProcedureName>
@Name NVARCHAR(50)
AS
BEGIN
    SELECT * FROM Customers WHERE Name = @Name;
END

-- Procedure with output
CREATE PROCEDURE <ProcedureName>
@City NVARCHAR(50),
@CustomersCount INT OUTPUT
AS
BEGIN
    SELECT @CustomersCount = COUNT(Id) FROM Customers
    WHERE City = @City
END

-- Procedure returning value
CREATE PROCEDURE <ProcedureName>
AS
BEGIN
    return (SELECT COUNT(ID) FROM Customers)
END
```

**View procedure code**

```sql
SP_HELPTEXT '<ProcedureName>';
```

**Execute procedure**

```sql
-- Execute procedure
EXECUTE <ProcedureName> <Value1>

-- Execute with output parameter
DECLARE @<VariableName123> INT;
EXECUTE <ProcedureName> <Value1>, @<VariableName123> OUTPUT
```

**Modify procedure**

```sql
ALTER PROCEDURE <ProcedureName>
@Name NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Customers WHERE Name = @Name;
END
```

**Delete procedure**

```sql
DROP PROCEDURE <ProcedureName>;
```

## Built-in functions

**String functions**

`ASCII(char)` - returns code of the character

`CHAR(int)` - returns ASCI character for the number

`LOWER(chars)` - converts a string to lower case

`LTRIM(chars)` - eliminates all white spaces from the left side

`RTRIM(chars)` - eliminates all white spaces from the right side

`UPPER(chars)` - converts all characters to uppercase chars

`REVERSE(chars)` - reverses all characters in the expression

`LEN(chars)` - returns amount of strings

`LEFT(chars, amount)` - returns specified amount of chars from the left side of specified string

`RIGHT(chars, amount)` - returns specified amount of chars from the right side of specified string

`CHARINDEX(chars, charsToSearch, startIndex)` - returns starting position of the specified expression in a string

`SUBSTRING(chars, start, length)` - returns substring of the given string

`REPLICATE(chars, numberOfTimesToReplicate)` - repeats the given string, for the specified number of time

`SPACE(NumberOfSpaces)` - returns number of spaces

`PATINDEX(pattern, chars)` - returns start index of specified pattern in string

`REPLACE(originalString, patternToReplace, replacementValue)` - replaces all occurrences of a specified string with another string

**DateTime functions**

`GETDATE()` - returns current date and time. Sample: 2020-01-14 16:31:06.340

`SYSDATETIME()` - returns more accurate current date and time. Sample: 2020-01-14 16:33:42.9781117

`SYSDATETIMEOFFSET()` - returns date time with offset Sample: 2020-01-14 16:35:48.9711393 +02:00

`GETUTCDATE()` - UTC Date and Time. Sample: 2020-01-14 14:44:03.110

`SYSUTCDATETIME()` - accurate UTC date and time with. Sample: 2020-01-14 14:43:46.9767251

`ISDATE(value)` - checks if the given value is a valid date

`DAY(dateTime)` - returns day of the give date time

`MONTH(dateTime)` - returns month of the given date time

`YEAR(dateTime)` - returns number of year of the given date time

`DATENAME(DAY\WEEKDAY\MONTH, dateTime)` - returns a string that represents a part of the given date

`DATEPART(datePart, dateTime)` - returns an integer representing the specified [datePart](https://www.w3schools.com/sql/func_sqlserver_datepart.asp)

`DATEADD(datePart, numberToAdd, originalDate)` - adds specified numberToAdd and returns updated dateTime

`DATEDIFF(datePart, numberToAdd, originalDate)` - diffs specified numberToAdd and returns updated dateTime

**Math functions**

`CEILING` - returns the smallest integer value greater than or equal to the parameter

`FLOOR` - returns the largest integer less than or equal to the parameter

`RAND()`
