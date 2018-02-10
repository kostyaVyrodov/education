# Seven concurrency models

## Concurrent or Parallel?

**Concurrency** is about dealing with lots of things at once.

A concurrent program has multiple logical threads of control. These threads may or may not run in parallel.

**Parallelism** is about doing lots of things at once.

A parallel program potentially runs more quickly than a sequential program by executing different parts of the computation simultaneously (in parallel).

## Types of parallelism

- Bit-level parallelism - increasing of processor word size, that reduces the number of instructions required a processor to execute operation;8bit processor requires 4 operations to process 32bit number.
- Instruction level parallelism - CPUs techniques like pipelining, out-of-order execution, speculative execution;
- Data parallelism - SIMD instructions;
- Task level parallelism - threads, process and tasks.

## Threads and locks

Concurrency model based on threads and locks that has imperative behavior.

Primary perils: 
- race conditions - when several threads try to get access to some resources;
- deadlock - when threads are blocked and can't continue work;
- memory visibility - both threads can process same variable and return a wrong result.

Rules to avoid perils: 
- Synchronize all access to shared variables;
- Both the writing and the reading threads need to use synchronization;
- Acquire multiple locks in a fixed, global order;
- Don't call alien methods while holding a lock;
- Hold locks for the shortest possible amount of time;
- Use timeout.

Strengths:
- Close to the metal so can applied almost everywhere;
- Can be easily integrated into most programming languages.

Weaknesses:
- Difficult to maintain;
- Deadlock, livelocks, race conditions.

## Functional programming

## The Clojure Way—separating identity and state

## Actors

## Communicating Sequential Processes

## Data parallelism

## The Lambda Architecture