namespace LinkedLists

// List operators:
// 100 :: [1; 2; 3; 4] -> [100; 1; 2; 3; 4]
// [1; 2; 3] @ [4; 5; 6] -> [1; 2; 3; 4; 5; 6]
// List ToDos:
//     - Insert to specified index
//     + Add item to head
//     + Add item to tail
//     + Print element
//     - Delete element
//     - Get value by index

module SingleLinkedList =
    type Node =
        { Value: int
          Next: Node option }

    type SingleLinkedList =
        { Head: Node option
          Tail: Node option }

    // Creating a list
    let createAnEmpty() =
        { Head = None
          Tail = None }

    let createWithValue initValue =
        let node =
            { Value = initValue
              Next = None }
            |> Some
        { Head = node
          Tail = node }

    // Adding items
    let addToHead value list =
        match list.Head with
        | Some h ->
            let newNode =
                { Value = value
                  Next = Some h }
            { list with Head = Some newNode }
        | None -> value |> createWithValue

    let rec private addValueToTail value node =
        match node.Next with
        | Some nextNode ->
            let updatedTail = addValueToTail value nextNode
            { node with Next = Some updatedTail }
        | None ->
            let tailNode =
                { Value = value
                  Next = None }
            { node with Next = Some tailNode }

    let addToTail value list =
        match list.Head with
        | Some h ->
            let updatedHead = addValueToTail value h

            let tail =
                { Value = value
                  Next = None }

            { list with
                  Head = Some updatedHead
                  Tail = Some tail }
        | None -> createWithValue value

    // Searching for elemnt
    let rec private indexOfSpecifiedValue index value node =
        match node with
        | Some n ->
            if value = n.Value then index
            else indexOfSpecifiedValue (index + 1) value n.Next
        | None -> -1

    let indexOf value list = 
        indexOfSpecifiedValue 0 value list.Head

    let valueExists value list = -1 <> indexOf value list 

    // Traversing nodes
    let rec private printNodes (node: Node) =
        match node.Next with
        | Some nextNode ->
            printf "%i " node.Value
            printNodes nextNode
        | None -> printf "%i " node.Value

    let printList (list: SingleLinkedList) =
        printf "Printing list: "
        match list.Head with
        | Some h -> printNodes h
        | None -> ()
