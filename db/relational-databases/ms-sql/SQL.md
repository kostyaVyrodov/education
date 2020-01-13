# SQL cheat sheet

## Basic database manipulating

Snippets to create\modify databases, tables

### Manipulating database

**Create DB:** `CREATE DATABASE <DatabaseName>`;

**Alter DB:** `ALTER DATABASE <Database Name> MODIFY NAME = <NewDatabaseName>`;

**Drop DB:** `DROP DATABASE <Database Name>`;

### Manipulating tables

**Create table:**

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

**Alter table:**

```sql
-- Add foreign key structure:
ALTER TABLE <TableName> ADD CONSTRAINT <ConstraintName> 
FOREIGN KEY (<ForeignKeyColumn>) REFERENCES <OtherTableName> (<PrimaryKeyOfOtherTable>);

-- Add column structure:
ALTER TABLE <TableName> ADD
<ColumnName> <DataType> <ColumnConstraint>
```
