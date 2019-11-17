# Algorithms and data structures

Data structure is a way for organizing data in a way that enables it to be processed in an efficient time.
Algorithm is a set of rules to solve a problem.

Why to ask algorithms in interview?
- Check 'Problem solving skills';
- Check 'Coding/Testing skills';

Types of data structures: primitives and non-primitives;

Primitives DS:
- integer;
- float;
- character;
- boolean;

Non-primitives:
- array;
- linked list;
- stack;
- tree;
- graph;

List of data structures is [here](https://en.wikipedia.org/wiki/List_of_data_structures)

## Recursion

Properties of recursion:
- same operations is performed multiple times with different inputs;
- in every step we try to make the problem smaller;
- we mandatorily need to have a base condition which tells system when to stop the recursion;

Types of recursion:
- tail recursion if the recursive call is the last thing done by the function and there is no need to keep record of the previous state;
- non-tail recursion is the recursive call is not the last thing done by the function. It's necessary to keep previous state;
- direct recursion when fun1 calls fun1;
- indirect recursion when fun1 calls fun2 and after that fun2 calls fun1;

Practical use of 'Recursion':
- Stack;
- Tree (Traversal/Searching/Insertion/Deletion);
- Sorting (Quick Sort / Merge sort);
- Divide and Conquer;
- Dynamic Programming;

### Recursion vs Iteration

| Particulars                           | Recursion     | Iteration |
| ------------------------------------- |:-------------:| ---------:|
| Space efficient?                      | No            | Yes       |
| Time efficient?                       | No            | Yes       |
| Ease to code (to solve sub-problems)? | Yes           | No        |


### When to use/avoid recursion?

When to use:
- we can easily breakdown a problem into similar subproblem;
- we are ok with extra overhead (both time and space) that comes with it;
- we need a quick working solution instead of efficient one;

When not to use:
- if the response to any of the above statements is NO, we should not go with recursion;
