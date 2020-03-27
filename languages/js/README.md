# JS notes

Notes about [JS internals](./JS_INTERNALS.md)

`use strict` - statement that specifies that could should be run in strict mode. For example, strict mode doesn't allow to use undeclared variables

## Global process module

`process` doesn't need to be required it's global module. Most of methods are wrappers around calls into core C library

### Events

Most useful events are `exit` and `uncaughtException`

```js
process.on('exit', function () {
  fs.writeFileSync('/tmp/myfile', 'This MUST be saved on exit.');
});

process.on('uncaughtException', function (err) {
  console.error('An uncaught error occurred!');
  console.error(err.stack);
});
```

### Streams

Process object provides wrapping for the `STDIN`, `STDOUT`, `STDERR`

- `STDIN` - readable stream
- `STDOUT` - writable no blocking stream
- `STDERR` - writable blocking stream

### Useful properties and methods

Properties:

- `process.pid` process id in OS
- `process.version` version of nodejs
- `process.platform` type of os
- `process.title` name of process. This name is displayed in the list of processes
- `process.execPath` absolute path of file
- `process.env` environment variables

Methods:
- `process.cwd()` - current working directory
- `process.chdir()` - changes working directory
- `process.exit()` - exits the process

## Recipes

**Hot to check if an object has a key**

```js
const obj = { apples: 2 };
const someRandomKey = 'apples';

if(someRandomKey in obj) {
  console.log('The key exists');
}
```
