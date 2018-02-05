// tells compiler how to compile this project
// the project can be compiled as executable program or share library
// package main tells that it's entry point to our app
package main

import "runtime"

// main executable entry point
// it's only necessary for executable project. Shared library project can contain just a set of functions.
// the main takes no arguments and returns nothing
// Exported functions should be capitalized
func main() {
	println("Hello from", runtime.GOOS)
}
