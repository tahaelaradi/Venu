import React from 'react';
import { ApolloProvider } from '@apollo/react-hooks';
import { ApolloClient } from 'apollo-client';
import { InMemoryCache } from 'apollo-cache-inmemory';
import { HttpLink } from 'apollo-link-http';

let apolloClient = null;

const BASE_URL = 'https://localhost:8001/api/events/gql';

/**
 * Creates and provides the apolloContext
 * to a component by wrapping it via HOC pattern
 * @param {Function|Class} PageComponent
 */
export function withApollo(PageComponent) {
  const WithApollo = ({ apolloClient, apolloState, ...pageProps }) => {
    const client = apolloClient || createApolloClient(apolloState);
    return (
      <ApolloProvider client={client}>
        <PageComponent {...pageProps} />
      </ApolloProvider>
    );
  };

  return WithApollo;
}

function createApolloClient(initialState = {}) {
  return new ApolloClient({
    link: new HttpLink({
      uri: BASE_URL,
      credentials: 'same-origin',
    }),
    cache: new InMemoryCache().restore(initialState),
  });
}