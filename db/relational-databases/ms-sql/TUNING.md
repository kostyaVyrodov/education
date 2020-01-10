# Tuning

**Automatic tunning** is a feature that provides insight into a potential query performance problems, recommends solutions and automatically fix identified problems

**Cardinality Estimation** is a features that responsible for predicting the number of rows that new query will return

## Merge statement

Merge provide a flexible approach to manipulate data in a "target" table based on a join to a "source" table. The enable users to perform a large # of updates and/or inserts in a target table using a single T-SQL statement.

## SELECT statement optimization tips

1. Define SELECT fields instead of SELECT *
    - Bad: `SELECT * FROM Customers;`
    - Good: `SELECT FirstName, Zip, City FROM Customers;`

2. DISTINCT is an expensive operation. Try to avoid it

3. Create joins with INNER JOIN rather than WHERE
    - Bad: `SELECT Customers.CustomerID, Customers.Name, Sales.LastSaleDate FROM Customers, Sales WHERE Customers.CustomerID = Sales.CustomerId`. This expression will lead to CROSS JOIN. CROSS JOIN generate all possible combinations of the variables are created.
    - Good: `SELECT Customers.CustomerID, Customers.Name, Sales.LastSaleDate FROM Customers INNER JOIN Sales ON Customers.CustomerID = Sales.CustomerID`

4. Use WHERE instead of HAVING to define filters
    - Bad: `SELECT Customers.CustomerID, Customers.Name, Count(Sales.SalesID) FROM Customers INNER JOIN Sales ON Customers.CustomerID = Sales.CustomerID GROUP BY Customers.CustomerID, Customers.Name HAVING Sales.LastSaleDate BETWEEN #1/1/2016# AND #12/31/2016#`
    - Good: `SELECT Customers.CustomerID, Customers.Name, Count(Sales.SalesID) FROM Customers INNER JOIN Sales ON Customers.CustomerID = Sales.CustomerID WHERE Sales.LastSaleDate BETWEEN #1/1/2016# AND #12/31/2016# GROUP BY Customers.CustomerID, Customers.Name`

5. Use wildcards (%) at the end of a phrase only or avoid them at all

6. Try to minimize amount of subqueries in the main query
    - Bad: `SELECT name FROM employee WHERE salary = (SELECT MAX(salary) FROM employee_details) AND age = (SELECT MAX(age) FROM employee_details) AND emp_dept = 'Electronics';`
    - Good: `SELECT name FROM employee WHERE (salary, age ) = (SELECT MAX (salary), MAX (age) FROM employee_details) AND dept = 'Electronics';`

7. Try to avoid using functions in WHERE clause

8
