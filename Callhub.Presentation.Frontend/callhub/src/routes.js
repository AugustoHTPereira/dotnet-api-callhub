import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import Register from "./pages/Register";
import Home from "./pages/Home";

// import { Container } from './styles';

const Routes = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/" component={() => <h1>Callhub</h1>} />
      <Route path="/register" component={Register} />
      <Route path="/home" component={Home} />
      <Route path="*" component={() => <h1>Page not found</h1>} />
    </Switch>
  </BrowserRouter>
);

export default Routes;
