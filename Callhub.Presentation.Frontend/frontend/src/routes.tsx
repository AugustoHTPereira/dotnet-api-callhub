import React, { Component } from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";

import Register from "./Pages/Register";

export default class Routes extends Component {
  render() {
    return (
      
      <BrowserRouter>
        <Switch>
          <Route path="/register" component={Register} />
        </Switch>
      </BrowserRouter>

    )
  }
}
