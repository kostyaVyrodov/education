package main

import (
	"fmt"
	"math/rand"
	"os"
	"time"
)

func main() {
	firstRank := "39"
	secondRank := "614"

	if firstRank < secondRank {
		fmt.Println("\nFirst course is doing better then second course")
	} else if firstRank < secondRank {
		fmt.Println("\nOh dear... your first course must be doing abysmally!")
	} else {
		fmt.Println("\nBoth courses are either the same or something weird is going on")
	}
	testConn()
}

func simpleStatementSample() {
	if firstRank, secondRank := 39, 614; firstRank < secondRank {
		fmt.Println("\nFirst course is doing better then second course")
	} else if firstRank < secondRank {
		fmt.Println("\nOh dear... your first course must be doing abysmally!")
	} else {
		fmt.Println("\nBoth courses are either the same or something weird is going on")
	}
}

func switchStatementSample() {
	switch "docker" {
	case "linux":
		fmt.Println("Linux")
	case "docker":
		fmt.Println("Docker")
		// Try to not use
		// It's necessary to match several values
		fallthrough
	case "windows":
		fmt.Println("Window")
	default:
		fmt.Println("nothing")
	}
}

func switchNumber() {
	switch tmpNum := random(); tmpNum {
	case 0, 2, 4, 6, 8:
		fmt.Println("Even")
	case 1, 3, 5, 7, 9:
		fmt.Println("Odd")

	}
}

func random() int {
	rand.Seed(time.Now().Unix())
	return rand.Intn(10)
}

func testConn() {
	_, err := os.Open("c:\\temp.txt")
	if err != nil {
		fmt.Println("Error returned was: ", err)
	}
}
