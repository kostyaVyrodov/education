# Data access in .NET

## ADO.NET

ADO.NET is a library that allows to interact with data sources such as databases and xml files. ADO is the acronym for ActiveX Data Objects

There are 2 types of connection architectures: **connected** and **disconnected** architecture.

**Connected** architecture remains connection with db throughout the processing of a request; 

**Disconnected** automatically connects/disconnects during the processing. The application uses temp data on the app side called a DataSet

### ADO.NET classes

**Connection**

It's a class used to connect to a db. Examples: `SqlConnection`, `OledDBConnection`, `OdbcConnaction`, `OracleConnaction`

**Command**

- ExecuteReader. Returns data to the client as rows;
- ExecuteNonQuery. Executes a command that changes the data in the database such as insert statement or a Stored. Returns a number of affected rows;
- ExecuteScalar. This kind of query returns a count of rows or a calculated value. Returns a single value.
- ExecuteXMLReader. (SqlClient classes only) Obtains data from an SQL Server 2000 database using an XML stream. Returns an XML Reader object.

**DataReader**

A class that used for accessing data from the data store. Examples: `SqlDataReader`, `OleDbDataReader`, `OdbcDataReader`

**DataAdapter**

DataAdapter is used to connect DataSets to databases. It's most useful when using data-bound controls in Windows Forms

**DataSet**

## FAQ

**Is it safe to keep database connections open for long time?**

Open and close your connection per business operation. Also there is no need to create a connection for each query. A connection should be wrapped into a unit of work
