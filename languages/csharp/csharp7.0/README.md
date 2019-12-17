# C# 7.0 features

## 'out' variables

Allows to assign an 'out' variable during invoking a function

```c#
if (int.TryParse(input, out int result))
    Console.WriteLine(result);
else
    Console.WriteLine("Could not parse input");
```

## Tuples

```c#
(string Alpha, string Beta) namedLetters = ("a", "b");
Console.WriteLine($"{namedLetters.Alpha}, {namedLetters.Beta}");
```

## Discards

Allows to skip unused variables during unpacking a tuple

```c#
var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);
```

## Pattern matching

Pattern matching in C# extends default switch case construction

```c#
public static int SumPositiveNumbers(IEnumerable<object> sequence)
{
    int sum = 0;
    foreach (var i in sequence)
    {
        switch (i)
        {
            case 0:
                break;
            case IEnumerable<int> childSequence:
            {
                foreach(var item in childSequence)
                    sum += (item > 0) ? item : 0;
                break;
            }
            case int n when n > 0:
                sum += n;
                break;
            case null:
                throw new NullReferenceException("Null found in sequence");
            default:
                throw new InvalidOperationException("Unrecognized type");
        }
    }
    return sum;
}
```

## Ref locals and returns

TBD
