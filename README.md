# Venu
Event management and ticketing app for creating, discovering and booking events built in a microservice architecture using:
* .Net Core 3.1
* API Gateway with [Ocelot](https://github.com/ThreeMammals/Ocelot).
* [gRPC](https://grpc.io) 
* Event Bus using [RabbitMQ](https://www.rabbitmq.com/) as a light message broker based on [Masstransit](http://masstransit-project.com/). 
* [MediatR](https://github.com/jbogard/MediatR) for dispatching requests, commands and queries.
* [AutoMapper](https://github.com/AutoMapper/AutoMapper) for object-object mapping.
* GraphQL Server using [GraphQL for .NET](https://github.com/graphql-dotnet/graphql-dotnet).
* SQL database with [Postgresql](https://www.postgresql.org/).
* NoSQL database with [MongoDB](https://www.mongodb.com/).
* [Redis](https://redis.io/) as a cache
* Authorization with JWT tokens.
* [Serilog](https://github.com/serilog/serilog) for logging.
* SPA with [React](https://github.com/facebook/react) and [TypeScript](https://github.com/microsoft/TypeScript).
* [Apollo Client](https://github.com/apollographql/apollo-client).
* CSS-in-JS with Base Web React Components ([Baseui](https://github.com/uber/baseweb)) and [Styled-Components](https://github.com/styled-components/styled-components).
* [Docker Compose](https://docs.docker.com/compose/)

## High Level Architecture
![Architecture](assets/architecture-diagram.png?)