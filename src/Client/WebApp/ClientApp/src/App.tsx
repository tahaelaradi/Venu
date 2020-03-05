import * as React from "react";
import { ThemeProvider } from "styled-components";
import LanguageProvider from "./contexts/language/language.provider";
import { StickyProvider } from "./contexts/app/app.provider";

import AppLayout from "./containers/LayoutContainer/AppLayout";
import { GlobalStyle } from "./styled/global.style";
import { useDeviceType } from "./helpers/useDeviceType";
import { theme } from "./theme";

// Language translation files
import localEn from "./data/translation/en.json";
import localAr from "./data/translation/ar.json";
import localEs from "./data/translation/es.json";

// Language translation Config
const messages = {
  en: localEn,
  ar: localAr,
  es: localEs
};

export default function App(props: any) {
  const deviceType = useDeviceType();

  return (
    <ThemeProvider theme={theme}>
      <LanguageProvider messages={messages}>
        <StickyProvider>
          <AppLayout deviceType={deviceType}>{props.childern}</AppLayout>
          <GlobalStyle />
        </StickyProvider>
      </LanguageProvider>
    </ThemeProvider>
  );
}
