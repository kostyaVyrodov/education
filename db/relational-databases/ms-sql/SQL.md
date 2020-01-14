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

