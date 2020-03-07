import React, { useContext, lazy, Suspense } from "react";
import { Route, Switch, Redirect } from "react-router-dom";

import { AuthContext } from "./contexts/auth/auth.context";
import { useDeviceType } from "./helpers/useDeviceType";
import { routes } from "./constants";

import HomePage from "./pages/HomePage";

const NotFound = lazy(() => import("./containers/NotFound"));

function PrivateRoute({ children, ...rest }) {
  const {
    authState: { isAuthenticated }
  } = useContext<any>(AuthContext);

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
  const deviceType = useDeviceType();

  return (
    <>
      <Suspense fallback={<div>Loading...</div>}>
        <Switch>
          <Route exact path={routes.HOME_PAGE}>
            <HomePage deviceType={deviceType} />
          </Route>
          <PrivateRoute path={routes.ACCOUNT_PAGE}>
            <div>Private Page...</div>
          </PrivateRoute>
          <Route component={NotFound} />
        </Switch>
      </Suspense>
    </>
  );
};

export default Routes;
