# NodeJS

NodeJS is JS runtime built on Chrome’s V8 engine. NodeJS uses an event-driven, non-blocking I/O model that makes it light weight & efficient

NodeJS is based on event driven programming. EDP is a paradigm when program flow is determined by the occurrence of events. The events are monitored by the code known as event listeners that, if it detects that its assigned event has occurred, runs an event “handler”, typically a callback function or method. Events are checked by event loop.

## Modules

All NodeJS programs have `global` variable. The `global` is similar to `window`

In NodeJS variables are not hoist to global object (`window.someFunction`)

In Node every file is a module and the variable and functions defined in that file are a scope of this module, they are not available outside of that module
