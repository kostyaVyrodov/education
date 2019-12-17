# Collections in C#

## Collections

Collections are data structures allowing to store sequence of data

### List<T>

[Official documentation](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)

List is a resizable array

Adding/Removing:
- to the beginning or middle is O(N). It's necessary to shift tail;
- to the end is O(1);

SearchOfItem is O(N). It performs linear search;

Accessing by index is O(1);

### Dictionary<T>

[Official documentation](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)

A "key-value" data structure implemented as a hash table

Adding duplicate 'key' is ```ArgumentException```;
Indexing to not existing key is ```KeyNotFoundException```;

Useful methods:
- ```bool TryGetValue(TKey key, out TValue value)```
- ```bool Contains(TKey key)```

Adding/Removing:
- to the beginning or middle is O(N). It's necessary to shift tail;
- to the end is O(1);

Accessing by key is O(1);

### HashSet<T>

Only "value" unordered data structure. All elements are unique in the HashSet and

Access to a value is O(1);

### Queue<T>

FIFO collection

### SortedDictionary<T>

[Official documentation](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2)

A key-value collection implemented as binary search tree 

Accessing an element is O(lg(n))

Adding duplicate 'key' is ```ArgumentException```;
Indexing to not existing key is ```KeyNotFoundException```;

Useful methods:
- ```bool TryGetValue(TKey key, out TValue value)```
- ```bool Contains(TKey key)```

## LINQ

LINQ can be used on IEnumerable<T> or IQueryable<T>.

Children of IEnumerable<T>:

- List;
- Dictionary;
- HashSet;
- Queue;
- SortedDictionary;
- SortedList;
- SortedSet;
- LinkedList;
- Stack;

### Functions

#### Aggregate

Applies an accumulator function over a sequence. Same as reduce

```
var list = new List<int> { 1, 2, 3 };
var result = list.Aggregate((acc, next) => acc + next);
Console.WriteLine($"Output: {result}");
```
**Result: "Output: 6"**

#### All

Determines whether all elements of a sequence satisfy a condition

```
var list = new List<int> { 1, 2, 3 };
var result = list.All((item) => item < 5);
Console.WriteLine($"Output: {result}");
```
**Result: "Output: true"**

#### Any

Determines whether any element of a sequence exists or satisfies a condition

```
var list = new List<int> { 1, 2, 3 };
var result = list.Any((item) => item == 1);
Console.WriteLine($"Output: {result}");
```
**Result: "Output: true"**

#### Append

Determines whether any element of a sequence exists or satisfies a condition

```
var list = new List<int> { 1, 2, 3 };
list.Append(4);
```

**Result: [1, 2, 3, 4]**

#### Concat

Concatenates two sequences

```
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 4, 5, 6 };

var result = list1.Concat(list2);
```

**Result: [1, 2, 3, 4, 5, 6]**

#### Contains

Determines whether a sequence contains a specified element

```
var list1 = new List<int> { 1, 2, 3 };
var result = list1.Contains(1);
```

**Result: True**

#### DefaultIfEmpty

Returns the elements of an IEnumerable<T>, or a default valued singleton collection if the sequence is empty.

```
var list1 = new List<int>();
var result = list1.DefaultIfEmpty(1);
```

**Result: [1]**

#### Distinct

Returns distinct elements from a sequence by using the default equality comparer to compare values

```
var list = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };
var distinctNumbers = ages.Distinct();
```

**Result: [21, 46, 55, 17]**

#### ElementAt

Returns the element at a specified index in a sequence. If index out of range then IndexOutRangeException

```
var list = new List<int> { 1, 2, 3, 4 };
var number = ages.ElementAt(1);
```

**Result: 2**

#### ElementAtOrDefault

Returns the element at a specified index in a sequence. If index out of range then return default value

```
var list = new List<int> { 1, 2, 3, 4 };
var number = ages.ElementAtOrDefault(4, 5);
```

**Result: 5**

#### Empty

Returns an empty IEnumerable<T> that has the specified type argument

```
IEnumerable<decimal> empty = Enumerable.Empty<decimal>();
```

**Result: []**

#### Except

Produces the set difference of two sequences by using the default equality comparer to compare values

```
double[] numbers1 = { 2.0, 2.0, 2.1, 2.2, 2.3, 2.3, 2.4, 2.5 };
double[] numbers2 = { 2.2 };

IEnumerable<double> onlyInFirstSet = numbers1.Except(numbers2);
```

**Result: [2, 2.1, 2.3, 2.4, 2.5]**

#### GroupBy

Groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key. The elements of each group are projected by using a specified function

```
class Pet
{
    public string Name { get; set; }
    public double Age { get; set; }
}

List<Pet> petsList = new List<Pet>{
    new Pet { Name="Barley", Age=8.3 },
    new Pet { Name="Boots", Age=4.9 },
    new Pet { Name="Whiskers", Age=1.5 },
    new Pet { Name="Daisy", Age=4.3 }
};

var query = petsList.GroupBy(
    pet => Math.Floor(pet.Age),
    pet => pet.Age,
    (key, groupedItems) => new
    {
        Key = key,
        Count = groupedItems.Count(),
        Min = groupedItems.Min(),
        Max = groupedItems.Max()
    });
```

```
Result: 
    Age group: 8
    Number of pets in this age group: 1
    Minimum age: 8.3
    Maximum age: 8.3

    Age group: 4
    Number of pets in this age group: 2
    Minimum age: 4.3
    Maximum age: 4.9

    Age group: 1
    Number of pets in this age group: 1
    Minimum age: 1.5
    Maximum age: 1.5
```

#### Intersect

Returns items that belongs to both sources

```
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 3, 4, 5 };

var result = list1.Intersect(list2);
```

**Result: [3]**

### OrderBy

Sorts the elements of a sequence in ascending order (From lower to bigger)

```
class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
}

Pet[] pets = { new Pet { Name="Barley", Age=8 },
                new Pet { Name="Boots", Age=4 },
                new Pet { Name="Whiskers", Age=1 } };

var result = pets.OrderBy(pet => pet.Age).Select((item) => item.Age);
```

**Result: [1, 4, 8]**

### OrderByDescending 

Sorts the elements of a sequence in descending  order (bigger to lower)

```
class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
}

Pet[] pets = { new Pet { Name="Barley", Age=8 },
                new Pet { Name="Boots", Age=4 },
                new Pet { Name="Whiskers", Age=1 } };

var result = pets.OrderBy(pet => pet.Age).Select((item) => item.Age);
```

**Result: [8, 4, 1]**

### Prepend 

Adds a value to the beginning of the sequence

var list = new List<int>()
