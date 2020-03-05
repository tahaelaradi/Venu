import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import registerServiceWorker from "./registerServiceWorker";

import { Client as Styletron } from "styletron-engine-atomic";
import { Provider as StyletronProvider } from "styletron-react";
import ApolloClient from "apollo-boost";
import { BaseProvider } from "baseui";
import { ApolloProvider } from "@apollo/react-hooks";
import { theme } from "./theme";
import App from "./App";
import Routes from "./routes";

const client = new ApolloClient({
  uri: process.env.VENU_API_URL
});

function Index() {
  const engine = new Styletron();

  return (
    <ApolloProvider client={client as any}>
      <StyletronProvider value={engine}>
        <BaseProvider theme={theme}>
          <BrowserRouter>
            <App>
              <Routes />
            </App>
          </BrowserRouter>
        </BaseProvider>
      </StyletronProvider>
    </ApolloProvider>
  );
}

ReactDOM.render(<Index />, document.getElementById("root"));
registerServiceWorker();
