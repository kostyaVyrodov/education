# Normalization

Normalization is the process of organizing the data in the database. Normal forms makes a table free from insert/update/delete anomalies and saves space by removing duplicate data

### 1NF

A relation is in 1NF if it contains an atomic value. If 1 cell contains several values first NF is violated.

**Violation of 1NF.** EMP_PHONE contains more then 1 value.

| EMP_ID  | EMP_NAME |        EMP_PHONE       | EMP_STATE |
| --------| -------- | ---------------------- | --------- |
|    14   |   John   | 7272826385, 9064738238 | UP        |
|    20   |   Hary   | 8574783832             | Bihar     |
|    12   |   Samy   | 7390372389, 8589830302 | Punjab    |

**Correct 1NF.** EMP_PHONE contains atomic value.

| EMP_ID  | EMP_NAME | EMP_PHONE  | EMP_STATE |
| --------| -------- | ---------- | --------- |
|    14   |   John   | 9064738238 | UP        |
|    14   |   John   | 7272826385 | UP        |
|    20   |   Hary   | 8574783832 | Bihar     |
|    12   |   Samy   | 7390372389 | Punjab    |
|    12   |   Samy   | 8589830302 | Punjab    |

### 2NF

A relation will be in 2NF if:

- it is in 1NF and
- all non-key attributes are fully functional dependent on the primary key, so there is no partial dependency

**Violation of 2NF.** Non-prime attribute TEACHER_AGE is dependent on TEACHER_ID which is a proper subset of a candidate key.

| TEACHER_ID  |  SUBJECT  | TEACHER_AGE |
| ------------| --------- | ----------- |
|      25     | Chemistry | 30          |
|      25     | Biology   | 30          |
|      47     | English   | 35          |
|      83     | Math      | 38          |
|      83     | Computer  | 38          |

**Correct 2NF.** TEACHER_AGE depends only on the primary key.

| TEACHER_ID  | TEACHER_AGE |
| ------------| ----------- |
|      25     | 30          |
|      47     | 35          |
|      83     | 38          |

| TEACHER_ID  |  SUBJECT  |
| ------------| --------- |
|      25     | Chemistry |
|      25     | Biology   |
|      47     | English   |
|      83     | Math      |
|      83     | Computer  |

### 3NF

Relation will be in 3NF if it is in 2NF and no transition dependency exists.

3NF is used to reduce the data duplication. It is also used to achieve the data integrity. If there is no transitive dependency for non-prime attributes, then the relation must be in third normal form. For example you have table called: 'Reviews'. Columns: ReviewId, ReviewText, Star, Star_Meaning, User_Id. If start is changed then Star_Meaning should be changed too. Star_Meaning depends on Star and Star depends on Id

### 4NF

A relation will be in 4NF if it is in Boyce Codd normal form and has no multi-valued dependency.

### 5NF

A relation is in 5NF if it is in 4NF and not contains any join dependency and joining should be lossless
