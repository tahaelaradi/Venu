import React from "react";
import { userService } from "../services/user.service";

type AuthProps = {
  isAuthenticated: boolean;
  authenticate: Function;
  signout: Function;
};

export const AuthContext = React.createContext({} as AuthProps);

const isValidToken = () => {
  const token = localStorage.getItem("venu_token");
  // JWT decode & check token validity & expiration.
  if (token) return true;
  return false;
};

const AuthProvider = (props: any) => {
  const [isAuthenticated, makeAuthenticated] = React.useState(isValidToken());

  function authenticate(email, password, cb) {
    userService
      .login(email, password)
      .then(result => {
        localStorage.setItem("venu_token", `${result.token}`);
        makeAuthenticated(true);
      })
      .catch(e => console.log(e));
  }

  function signout(cb) {
    makeAuthenticated(false);
    localStorage.removeItem("venu_token");
  }

  return (
    <AuthContext.Provider
      value={{
        isAuthenticated,
        authenticate,
        signout
      }}
    >
      <>{props.children}</>
    </AuthContext.Provider>
  );
};

export default AuthProvider;
