export const initialState = {
  isSticky: false,
  isSidebarSticky: true
};

type Action =
  | { type: "SET_STICKY" }
  | { type: "REMOVE_STICKY" };

type State = typeof initialState;

export function reducer(state: State, { type }: Action): State {
  switch (type) {
    case "SET_STICKY":
      return {
        ...state,
        isSticky: true
      };
    case "REMOVE_STICKY":
      return {
        ...state,
        isSticky: false
      };
  }
}
