﻿
#r @"..\packages\FSharp.Data.SqlClient.1.6.2\lib\net40\FSharp.Data.SqlClient.dll"

open FSharp.Data

[<Literal>] 
let connectionString = @"Data Source=.;Initial Catalog=AdventureWorks2014;Integrated Security=True"

type Get42Query = SqlCommandProvider<"SELECT 42 AS Value", connectionString, SingleRow = true>
let cmdGet42 = new Get42Query()
cmdGet42.Execute()

