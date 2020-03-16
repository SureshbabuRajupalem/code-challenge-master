# Star Wars Galactic Directory
This is a boilerplate project for the Emerson Ecologics software engineering code challenge.

## Requirements
Create a Galactic Directory of people in the Star Wars universe using the  [Star Wars API](https://swapi.co/).
Use the starter project in this repository, or create your own separate project, to build an application that meets the following requirements:

- Displays a paginated list of people, with some brief details for each.
- There should be a backend to provide functionality such as caching, aggregation, etc.
- Tolerant of errors due to API failure, network lag/timeout, etc.
- Allows a person to be selected, and displays more detailed information about them.
- Allows the person’s details to be modified, and saved.
  - The public API is read-only, so changes will need to be persisted within the application.
  - You can choose any method for persisting the data -- memory, filesystem, database, etc.
  - Bonus points if it’s SQL Server.
- In the future we might expand to include other entities (ships, planets, etc.), so make sure your
design and implementation are extensible.