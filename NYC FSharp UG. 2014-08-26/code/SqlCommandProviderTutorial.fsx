﻿
#r @"packages\FSharp.Data.SqlClient.1.3.2\lib\net40\FSharp.Data.SqlClient.dll"

open FSharp.Data

[<Literal>] 
let connectionString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=AdventureWorks2012;Integrated Security=True"

type Get42 = SqlCommandProvider<"SELECT 42 AS Value", connectionString, SingleRow = true>
let cmdGet42 = new Get42()
cmdGet42.Execute()

type GetLocalDatadases = SqlCommandProvider<"SELECT name, create_date FROM sys.databases", connectionString> 
let cmdGetLocalDatabases = new GetLocalDatadases()
cmdGetLocalDatabases.Execute() 
|> Seq.filter (fun x -> x.create_date > System.DateTime( 2014, 1, 1))
|> Seq.toList

type GetFizzBuzzAnswer = SqlCommandProvider<"FizzBuzz.sql", connectionString, ResultType.Tuples>
let getFizzBuzzAnswer = new GetFizzBuzzAnswer()
[ for x, fizzBuzz in getFizzBuzzAnswer.Execute() do if fizzBuzz <> "" then yield x.Value ]

