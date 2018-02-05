package main

// Variables:
// - are static typed
// - must start with '_' or a letter
// - Go will initialize variables with a zero value

import (
	"fmt"
	"os"
	"reflect"
)

// This is global vars for package
// Can be declared using const
var (
	name   = "Nigel"
	course = "Docker Deep Dive"
	module = 3.2
)

func main() {
	// fmt.Println("Name is set to ", name, "and is of type", reflect.TypeOf(name))
	// fmt.Println("Module is set to", module, "and is of type", reflect.TypeOf(module))
	// fmt.Println("Memory address of *module* variables is ", &module)

	// ptr := &module
	// fmt.Println("Memory address of *module* is ", ptr, " and the value of *module* is ", *ptr)

	// calc()
	// workingWithPointers()
	settingEnvironmentVariable()
}

func calc() {
	// Such initialization works only under function and we init values immediately
	// It's more idiomatic way
	// Variables are declared under function must be used
	a := 10.00000000
	b := 3

	fmt.Println("\nA is type", reflect.TypeOf(a), "and B is of type", reflect.TypeOf(b))

	// a was not changed. It's converted only for calculation
	c := int(a) + b

	fmt.Println("\nC has value type", c, "and is of type", reflect.TypeOf(c))

	// Sample of delcation of consts
	const speedOfLightMph = 186000
}

func workingWithPointers() {
	name := "Nigel"
	course := "Docker Deep Dive"

	fmt.Println("\nHi", name, "you're currently watching", course)

	changeCourse(&course)

	fmt.Println("\nTrying to change your course to", course)

}

func changeCourse(course *string) string {
	// It's assigning =
	*course = "First Look: Native Docker Clustering"
	fmt.Println("\nTrying to change your course to", *course)
	return *course
}

func settingEnvironmentVariable() {
	name := os.Getenv("USERNAME")
	fmt.Println("Name is set to ", name, "and is of type", reflect.TypeOf(name))
}
