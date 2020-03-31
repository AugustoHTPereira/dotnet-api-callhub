import { createGlobalStyle } from "styled-components";

export default createGlobalStyle`
  @import url('https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,300;0,400;0,500;1,300;1,400&display=swap');

  * {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
  }

  body {
    background-color: ${props => props.theme.colors.background.primary};
    min-height: 100vh;
    font-size: 14px;
    /* color: #434343; */
    color: ${props => props.theme.colors.text.primary};
    font-family: 'Roboto', sans-serif;
  }

`;
