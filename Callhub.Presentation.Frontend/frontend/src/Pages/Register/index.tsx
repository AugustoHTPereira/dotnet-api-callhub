import React, { Component } from "react";
import { Register as RegisterComponent } from "../../Components/Register";

import { Container } from "./style";

export default class Register extends Component {
  render() {
    return (
      <Container>
        <RegisterComponent />
      </Container>
    );
  }
}
