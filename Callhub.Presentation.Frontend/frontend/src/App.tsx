import React from "react";
import Routes from "./routes";

import { ThemeProvider } from "styled-components";
import GlobalStyle from "./Styles/global";
import Light from "./Styles/Themes/Light";

export default function App() {
  return (
    <ThemeProvider theme={Light}>
      <GlobalStyle />
      <Routes />
    </ThemeProvider>
  );
}
