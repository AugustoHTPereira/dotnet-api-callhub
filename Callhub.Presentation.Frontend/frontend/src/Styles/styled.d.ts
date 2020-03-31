import "styled-components";

declare module "styled-components" {
  export interface DefaultTheme {
    title: string;

    colors: {
      red: string;
      green: string;
      yellow: string;
      blue: string;

      background: {
        primary: string;
        secondary: string;
        card: string;
      };

      text: {
        primary: string;
        secondary: string;
        terciary: string;
      };
    };
  }
}
