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

## Useful notes

- TemplateString: ``Hello, ${userName}``

- In NodeJS most of methods are async. Sync methods marked with `Sync` ending

- `http` module has a class `Server`. The `Server` extends EventEmitter and has same methods: `on`, `emit` etc.

- Each NodeJS package has own package.json with own dependencies

- Previous versions of NPM saved the dependencies of extra package inside folder of the extra package. Multiple extra packages could have the same dependencies. Currently this behavior was changed and all dependencies are saved under node_modules folder
