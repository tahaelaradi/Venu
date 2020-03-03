import * as React from "react";
import Routes from "./routes";
import { ThemeProvider } from 'styled-components';
import { theme } from './theme';
import ApolloClient from "apollo-client";
import { ApolloProvider } from "@apollo/react-hooks";
import {HttpLink} from "apollo-link-http";
import {InMemoryCache} from "apollo-cache-inmemory";

const BASE_URL = "https://localhost:8001/api/events/gql";

function createApolloClient(initialState = {}) {
  return new ApolloClient({
    link: new HttpLink({
      uri: BASE_URL,
      credentials: 'same-origin',
    }),
    cache: new InMemoryCache().restore(initialState),
  });
}

const client = createApolloClient();

export default () => (
  <ThemeProvider theme={theme}>
    <ApolloProvider client={client as any}>
      <Routes />
    </ApolloProvider>
  </ThemeProvider>
);
