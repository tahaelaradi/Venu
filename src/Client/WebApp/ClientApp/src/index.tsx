import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import { Client as Styletron } from "styletron-engine-atomic";
import { Provider as StyletronProvider } from "styletron-react";
import { BaseProvider } from "baseui";
import { ApolloProvider } from "@apollo/react-hooks";
import { theme } from "./theme";
import Routes from "./routes";
import ApolloClient from "apollo-boost";
import registerServiceWorker from "./registerServiceWorker";
import { GlobalStyle } from "./styled/global.style";

const client = new ApolloClient({
  uri: process.env.VENU_API_URL
});

function App() {
  const engine = new Styletron();

  return (
    <ApolloProvider client={client as any}>
      <StyletronProvider value={engine}>
        <BaseProvider theme={theme}>
          <BrowserRouter>
            <GlobalStyle />
            <Routes />
          </BrowserRouter>
        </BaseProvider>
      </StyletronProvider>
    </ApolloProvider>
  );
}

ReactDOM.render(<App />, document.getElementById("root"));
registerServiceWorker();
