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
