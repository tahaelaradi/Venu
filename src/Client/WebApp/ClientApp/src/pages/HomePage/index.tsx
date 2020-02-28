import React from 'react';
import { withApollo } from "../../util/apollo";
import { useQuery } from '@apollo/react-hooks';
import { GET_EVENTS } from "../../graphql/query/event.query";

const PAGE_TYPE = 'HomePage';

function HomePage() {
  const { data, error, loading } = useQuery(GET_EVENTS);

  if (!loading) {
    console.log(data);
  }

  return (
    <>
    </>
  );
}

export default withApollo(HomePage);

