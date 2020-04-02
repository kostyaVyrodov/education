# NodeJS

NodeJS is JS runtime built on Chrome’s V8 engine. NodeJS uses an event-driven, non-blocking I/O model that makes it light weight & efficient

NodeJS is based on event driven programming. EDP is a paradigm when program flow is determined by the occurrence of events. The events are monitored by the code known as event listeners that, if it detects that its assigned event has occurred, runs an event “handler”, typically a callback function or method. Events are checked by event loop.

## Modules

All NodeJS programs have `global` variable. The `global` is similar to `window`

In NodeJS variables are not hoist to global object (`window.someFunction`)

In Node **every file is a module** and the variables and functions defined in that file are a scope of this module, they are not available outside of that module

```js
Module {
    id: '.',
    exports: {}, --everything exported from this module will appear in this property
    parent: null,
    fileName: 'full/path',
    children: [],
    paths: [
        'where to find the module1',
        'where to find the module1'
    ]
}
```

`require('moduleName' | 'pathToModule')` - is a function loading a module

NodeJS wraps all code in module into 'Module Wrapper Function':

```js
(function(exports, require, module, __filename, __dirname) {
    // code here
})
```

## Package manager

Main package managers for Node.JS are `NPM` and `Yarn`

yarn:
- faster then npm because installs packages simultaneously
- yarn more secured because doesn't allow execute js scripts on fly during installation of a package
- doesn't support Node.JS older then 5.0 

NPM uses Semantic versioning: 1.0.0 = Major.Minor.Patch

- Major - has breaking changes
- Minor - doesn't have breaking changes
- Patch - has bug fixes

`^` vs `~`: 
- `^` = 1.x
- `~` = 1.8.x

`npm list` list of all dependencies including dependencies of dependencies

`npm list --depth=0` list of all dependencies for your project

`npm view <npm-module-name>` see package.json

`npm view <npm-module-name> versions` see list of versions for the package

`npm install <npm-module-name>@<specific-version>` install specific version of package

`npm outdate` list of outdated dependencies

`npm update` updates only minor ant patch

`npm-check-updates` module allows to update dependencies of package.json up to the latest version

`npm version <major|minor|patch>` allows to increment version of package.json

## Express

Express is a lightweight web app framework

Useful libraries: 

`nodemon` is an npm package that monitors changes in js files and provides hotreload

`Joi` is a package for validating of http requests models

Pass argument to the app via ENV variables: `const port = process.env.PORT || 3000;`

An endpoint is declared as function:

```js
app.get('/', (req, res) => {
	res.send('Hello world!!!');
});
```

**Request** object:
- `req.params` - HTTP arguments like `/api/resource/:id` 
- `req.query` - query parameters like `/api/resource/:id?sortBy=name` 
TBD

**Response** object:
TBD

Whole express based on middlewares. Each `app.get`, `app.post`, `app.put`, `app.delete` creates a middleware for handling a request

Each middleware should have own file

```js
// midleware function
// if you don't call next() then next handlers won't be called
app.use((req, res, next) => {
    console.log('logging...');
    next(); 
});
```

Useful middlewares:

- `express.json()` - parses body json and maps it to an object under `req`
- `express.urlencoded()` - parse urlencoded payload and maps it to an object under `req`
- `express.static('folderNameForServing')` - allows to serve static files
- `helmet()` - provides extra headers to make sure app's security
- `morgan()` - logger middleware

Get current env:
- `process.env.NODE_ENV` - returns undefined if not set
- `expressApp.get('env')` - returns dev if not set

How to manage configuration of app: with `rc` or `config` npm package

How to write debug statements: with `debug` package. Allows not to log into console in production env

Most popular Template engines:
- `pug`
- `mustache`
- `ejs`

## Useful notes

- TemplateString: ``Hello, ${userName}``

- In NodeJS most of methods are async. Sync methods marked with `Sync` ending

- `http` module has a class `Server`. The `Server` extends EventEmitter and has same methods: `on`, `emit` etc.

- Each NodeJS package has own package.json with own dependencies

- Previous versions of NPM saved the dependencies of extra package inside folder of the extra package. Multiple extra packages could have the same dependencies. Currently this behavior was changed and all dependencies are saved under node_modules folder

## FAQ

**What is Event Loop**

Event loop provided by libuv library. It's not part V8. The event loop is an entity that handles external events and converts them into callback invocation.

**When node js process exits**

When both call stack of v8 and event queue libuv are empty. When you run nodejs app it creates both stack and eventloop

**How come top-level variables are not global**

Each file is a nodejs file gets its own IIFE (Immediately Invoked Function Expression) behind the scenes. All variables declared in a Node file are scoped to that IIFE.

**When to use *sync methods**

For example, it can be used in any initializing step while the server is still loading.

**What type of streams do exist**

Readable, Writable, Duplex, Transform. All streams are children of EventEmmiter

Duplex stream allows both reading and writing. Transform stream is used for transforming data

**spawn, fork, exec, execFile**

`spawn()` creates a new process and returns `ChildProcess` obj that extends `EventEmitter`. Events: `disconnect`, `error`, `close`, `message`. `message` is invoked when child calls `process.send()`

```js
const find = spawn('find', ['.', '-type', 'f']);
const wc = spawn('wc', ['-l']);

find.stdout.pipe(wc.stdin);

wc.stdout.on('data', (data) => {
  console.log(`Number of files ${data}`);
});
```

`exec()` creates a shell to execute the command. Main difference between spawn and exec: It buffers the command’s generated output and passes the whole output value to a callback function instead of stream

```js
exec('find . -type f | wc -l', (err, stdout, stderr) => {
  if (err) {
    console.error(`exec error: ${err}`);
    return;
  }

  console.log(`Number of files ${stdout}`);
});
```
