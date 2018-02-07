package main

import (
	"fmt"
	"runtime"
	"sync"
	"time"
)

func main() {
	runtime.GOMAXPROCS(2)
	var waitGrp sync.WaitGroup
	waitGrp.Add(2)

	// go - transforms the function to the goroutine
	go func() {
		defer waitGrp.Done()
		time.Sleep(5 * time.Second)
		fmt.Println("Hello")
	}()

	go func() {
		defer waitGrp.Done()
		fmt.Printf("Pluralsight")
	}()

	waitGrp.Wait()
}
