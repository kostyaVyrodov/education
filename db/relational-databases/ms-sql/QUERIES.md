# Query data

## Cursor

A database cursor can be thought of as a pointer to a specific row within a query result. Cursor is a Temporary Memory. It's allocated by DB server at the time of performing DML on table by a user. Cursor are quite slow so it's better to avoid them. Cursor can be used to work on each raw in db

### Types of Cursor

**Forward-only** is default type of cursor. It is identical to the static except that you can only scroll forward.

**Static** populates the result set during cursor creation and the query result is cached for the lifetime of the cursor. A static cursor can move forward and backward.

**Dynamic**. In a dynamic cursor, additions and deletions are visible for others in the data source while the cursor is open.

**Keyset**. This is similar to a dynamic cursor except we can't see records others add. If another user deletes a record, it is inaccessible from our record set.
