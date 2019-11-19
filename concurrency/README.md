# Seven concurrency models

## Concurrent or Parallel?

**Concurrent Multitasking**. This is when we have a number of concurrent tasks (e.g. processes or threads) within our direct control, and we want them to communicate with each other and share data safely.

**Asynchronous** programming. This is when we initiate a conversation with a separate system outside our direct control, and then wait for it to get back to us. Common cases of this are when talking to the filesystem, a database, or the network. These situations are typically I/O bound, so you want to do something else useful while you are waiting. These types of tasks are often non-deterministic as well, meaning that running the same program twice might give a different result.

**Parallel** programming. This is when we have a single task that we want to split into independent subtasks, and then run the subtasks in parallel, ideally using all the cores or CPUs that are available. These situations are typically CPU bound. Unlike the async tasks, parallelism is typically deterministic, so running the same program twice will give the same result.

**Reactive** programming. This is when we do not initiate tasks ourselves, but are focused on listening for events which we then process as fast as possible. This situation occurs when designing servers, and when working with a user interface.

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

(Explanation)[https://www.youtube.com/watch?v=ELwEdb_pD0k]

Conceptual model of concurrent computation. Actor is fundamental unit of computation.

Operations of actors:
1. Create another actor;
2. Send a message;
3. Designate how to handle internal state and next message;

Actors are lightweight so we can produce thousands of actors. This is because they require fewer resources.

Actors are isolated from each other and they don't share memory. Actors are waiting for new messages and receive them in their mailbox.
The only one way to communicate with each other is only messages. Actor can handle only one message at once and they don't wait for response to each other.

If a child actor finishes something, then it sends another message to notify a parent. 

An actor has address only of child actors and the actors that sent messages to him. 

Actors can be distributed between several machines (remote, local)

Pros:
- Easy to scale;
- Fault tolerance;
- Geographical distribution;
- No shared state;

Cons:
- Deadlocks;
- Mailbox overflow;

Implementation:
- Akka;
- Elixir;

## Communicating Sequential Processes

## Data parallelism

## The Lambda Architecture
