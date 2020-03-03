import React, { useContext, lazy, Suspense } from "react";
import { Route, Switch, Redirect } from "react-router-dom";

import AuthProvider, { AuthContext } from "./context/auth";
import { routes } from "./constants";

const Login = lazy(() => import("./containers/Login/Login"));
const NotFound = lazy(() => import("./containers/NotFound"));

function PrivateRoute({ children, ...rest }) {
  const { isAuthenticated } = useContext(AuthContext);

  return (
    <Route
      {...rest}
      render={({ location }) =>
        isAuthenticated ? (
          children
        ) : (
          <Redirect
            to={{
              pathname: "/login",
              state: { from: location }
            }}
          />
        )
      }
    />
  );
}

const Routes = () => {
  return (
    <AuthProvider>
      <Suspense fallback={<div>Loading...</div>}>
        <Switch>
          <PrivateRoute path={routes.ACCOUNT_PAGE}>
            <div>Private Page...</div>
          </PrivateRoute>
          <Route path={routes.LOGIN}>
            <Login />
          </Route>
          <Route component={NotFound} />
        </Switch>
      </Suspense>
    </AuthProvider>
  );
};

export default Routes;
