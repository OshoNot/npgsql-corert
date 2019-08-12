module Dblib

open Npgsql
open System

let dbConnection =
    new NpgsqlConnection("Host=database;Username=dbuser;Password=dbpassword;Database=dbsample")

let InsertRecord (dbConn : NpgsqlConnection) =
    let command = new NpgsqlCommand()
    command.Connection <- dbConn
    command.CommandText <- "INSERT INTO map (name, value)
                                VALUES
                                    ('newUser', 'newValue')"
    command.ExecuteNonQuery()

let SelectAll (dbConn : NpgsqlConnection) =
    let command = new NpgsqlCommand()
    command.Connection <- dbConn
    command.CommandText <- "SELECT * from  map"
    let selectReader = command.ExecuteReader()
    //printing all names
    while selectReader.Read() do
        selectReader.GetString(0) |> printfn "Name: %s"
    selectReader.Close()

let DeleteRecord (recordName : String) (dbConn : NpgsqlConnection) =
    let command = new NpgsqlCommand()
    command.Connection <- dbConn
    command.CommandText <- "DELETE from map WHERE name=@p"
    command.Parameters.AddWithValue("p", recordName) |> ignore
    command.ExecuteNonQuery()

let UpdateRecord (recordName : String) (dbConn : NpgsqlConnection) =
    let command = new NpgsqlCommand()
    command.Connection <- dbConn
    command.CommandText <- "UPDATE map SET name = 'updatedUser' WHERE name = @p"
    command.Parameters.AddWithValue("p", recordName) |> ignore
    command.ExecuteNonQuery()
