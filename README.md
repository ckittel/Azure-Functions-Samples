# Azure Functions Samples

A handful of various samples of how different Triggers, Input, and Output Bindings work.  Also includes a couple sample unit tests.

## CosmosDB

Assumes a database with the name `school` and a container with the name `students` that has a partition defined as `/studentId`.  Can use local emulator.

## Storage Account

Can use local emulator.  Will reference both queues and blobs.

## Postman

Check out `postman_collection.json`.  You can import it and all of the HTTP Triggers will be in there, pointing to `http://localhost:7071` by default.
