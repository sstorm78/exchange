## London Exchange API

This project demonstrates a simple Rest API with endpoints to log stock transactions and then return current stock values, queried by ticker symbol.
It has swagger UI, so can be tested via a browser. There are three stocks prepopulated A, B, C. They can be queried with the /stocks endpoints.

Like: https://localhost:44339/Stocks?symbols=A,C

## Structure

**LondonExchange.Api**: The main API project with two controllers

 - **StocksController** has two endpoints, /stocks/{SYMBOL} to retrieve a single stock value and /stocks?symbols=A,B to retrieve a specific range and if no range provided, it will return all stocks.
 - **TransactionsController** has single endpoint to accept and store a transaction model

**LondonExchange.Models** is a library with shared models across the solution

**LondonExchange.Data** a repository level with basic emulation of a database using DbContext

**LondonExchange.Service** is the business logic layer with relevant services to store/update transactions and stocks, and to retrieve the value.

**LondonExchange.Api.Tests** is a set of tests for the API controllers
**LondonExchange.Services.Tests** is a set of tests for the business logic.

## Assumptions

 - No Exchange or Broker data prepopulated but available to see how it
 - could be structured No input validation to save time 
 - No  authentication

## Potential Enhancements

 - It should be async all the way (not done due to the db mock) SQL and
 - Code Transaction blocks are needed for stock price updates 
 - This  service could see a large number of transactions, so for transaction
   records a no-sql might be better, due to horizontal scalability
 - High traffic can be mitigated with a load balancer setup across multiple API instances.