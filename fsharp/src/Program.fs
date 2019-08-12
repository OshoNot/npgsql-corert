open Dblib

[<EntryPoint>]
let main argv =
    dbConnection.Open()
    dbConnection
    |> SelectAll
    |> ignore
    match dbConnection |> InsertRecord with
    | -1 -> ()
    | _ -> printfn "New record inserted."
    dbConnection
    |> SelectAll
    |> ignore
    match dbConnection |> DeleteRecord "foo" with
    | -1 -> ()
    | _ -> printfn "Record name 'foo' deleted."
    dbConnection
    |> SelectAll
    |> ignore
    match dbConnection |> UpdateRecord "wo" with
    | -1 -> ()
    | _ -> printfn "Record name 'wo' updated to 'updatedUser'."
    dbConnection
    |> SelectAll
    |> ignore
    0
