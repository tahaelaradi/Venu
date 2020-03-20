import gql from "graphql-tag";

export const GET_EVENTS = gql`
  query getEvents {
    events {
      id
      name
    }
  }
`;

export const SEARCH_EVENTS = gql`
  query searchEvents($name: String, $category: String) {
    events(name: $name, category: $category){
      id
      name
    }
  }
`;
