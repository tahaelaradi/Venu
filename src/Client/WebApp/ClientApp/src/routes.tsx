import React, { useContext, lazy, Suspense } from "react";
import { Route, Switch, Redirect } from "react-router-dom";

import AppLayout from "./containers/LayoutContainer/AppLayout";
import AuthProvider, { AuthContext } from "./contexts/auth";
import { useDeviceType } from "./helpers/useDeviceType";
import { routes } from "./constants";

import HomePage from "./pages/HomePage";

const Login = lazy(() => import("./containers/Login/Login"));
const NotFound = lazy(() => import("./containers/NotFound"));

function PrivateRoute({ children, ...rest }) {
  const { isAuthenticated } = useContext(AuthContext);
  console.log("isAuth?", isAuthenticated);

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
    <AppLayout deviceType={deviceType}>
      <AuthProvider>
        <Suspense fallback={<div>Loading...</div>}>
          <Switch>
            <Route exact path={routes.HOME_PAGE}>
              <HomePage deviceType={deviceType} />
            </Route>
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
    </AppLayout>
  );
};

export default Routes;
