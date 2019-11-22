open System
open LinkedLists.SingleLinkedList

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let list = createWithValue 1
    let newList = addToTail 2 list
    let newList = addToTail 3 newList

    newList |> printList

    printf "\nValue: %i" (indexOf 3 newList)
    printf "\nValue: %b" (valueExists 3 newList)
    printf "\nValue: %b" (valueExists 4 newList)
    Console.ReadLine() |> ignore
    0 // return an integer exit code
