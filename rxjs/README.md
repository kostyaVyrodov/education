# RxJS

A stream represents a sequence of objects which can be accessed in sequential order

RxJS elevates data flow to be a first class architectural pattern on the level of MVC

`variable$` rxjs observable should have $ in the end of name

`interval(timeOut)` returns observable

```js
const interval$ = interval(1000);

const subscription = interval$.subscribe(
    (val) => console.log('stream1 ' + val),
    // when error occurred it won't emit any values and 'onComplete' won't be called
    (err) => console.log('err1' + err),
    // when stream is completed it won't emit any values again
    () => console.log('stream completed')
);

// unsubscribe 
subscription.unsubscribe();
```

**How to create observable?**

1. `interval(interval)`
1. `Observer.create(observer => {});` observer should be encapsulated
1. `Observer.fromEvent(document, 'click')`

**Custom implementation of observable**

```js
// http$ is just definition of observable, it doesn't run it
const http$ = Observable.create(observer => {
    fetch('/api/courses')
    .then(res => res.json())
    .then(body => {
        observer.next(body)
        observer.complete();
    }).catch(
        err => observer.error(err)
    )
});

// subscribe runs execution of observable. Each time when you call subscribe,
// the callback of Observable.create will be executed
http$.subscribe(
    courses => console.log(courses),
    noop,
    () => console.log('completed')
)
```
