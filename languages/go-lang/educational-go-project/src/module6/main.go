package main

import (
	"fmt"
)

func main() {
	// capacity vs length: capacity is max size of slice;
	// go creates a hidden arrays for storing data of a slice;
	// if you don't specify a capcity then it will be same as length

	// myCourse := make([]string, 5, 10)
	// myCourse := []string{"Docker", "Puppet", "Python"}
	// fmt.Printf("Legnth is: %d. \nCapacity is: %d", len(myCourse), cap(myCourse))

	// It's not array. It's a slice;
	mySlice := []int{1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
	fmt.Println(mySlice[1])

	mySlice[1] = 0
	fmt.Println(mySlice)

	// It creates a new slice
	// [:5] = [0:5]
	// [5:] = [5: length]
	sliceOfSlice := mySlice[2:5] // -> 3, 4 ,5
	fmt.Println(sliceOfSlice)

	// slices are passed by reference. When you change something in slice you change your original array

	myArray := [2]int{2, 3}
	// It copies array
	newMyArray := myArray
	newMyArray[0] = 1
	fmt.Println(myArray)

	appendSlice()
}

func appendSlice() {
	mySlice := []int{1, 2, 3, 4, 5}
	fmt.Println(mySlice)

	for _, i := range mySlice {
		fmt.Println("for range loop: ", i)
	}

	newSlice := []int{10, 20, 30}
	// this is appending of items
	// ... - this is spread operator
	mySlice = append(mySlice, newSlice...)
	fmt.Println(mySlice)

}
