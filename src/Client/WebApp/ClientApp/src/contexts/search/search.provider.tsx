import React, { useReducer } from 'react';
import { SearchContext } from './search.context';
type ActionType = { type: 'UPDATE' | 'RESET'; payload: object };

function reducer(state: any, action: ActionType): any {
  switch (action.type) {
    case 'UPDATE':
      return { ...state, ...action.payload };
    case 'RESET':
      return { page: 1 };
    default:
      return state;
  }
}

type SearchProviderProps = {
  query: any;
};

export const SearchProvider: React.FunctionComponent<SearchProviderProps> = ({
  children,
  query,
}) => {
  const [state, dispatch] = useReducer(reducer, { ...query, page: 1 });
  return (
    <SearchContext.Provider value={{ state, dispatch }}>
      {children}
    </SearchContext.Provider>
  );
};
