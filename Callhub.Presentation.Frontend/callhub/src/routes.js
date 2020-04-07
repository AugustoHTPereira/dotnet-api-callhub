import React from "react";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
import Register from "./pages/Register";
import Home from "./pages/Home";
import Login from "./pages/Login";
import { connect } from "react-redux";

const Routes = ({ token }) => {
  const isAuthenticated = () => {
    console.log(token);
    if (token !== null) return true;

    return false;
  };

  const PrivateRoute = ({ component: Component, ...rest }) => {
    console.log("Private route", Component, rest);

    if (!isAuthenticated()) return <Route component={Component} {...rest} />;
    else
      return (
        <Redirect
          to={`/login?redirect=${window.location.pathname}`}
          {...rest}
        />
      );
  };

  console.log("User token", token);

  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={() => <h1>Callhub</h1>} />
        <Route exact path="/register" component={Register} />
        <Route exact path="/login" component={Login} />
        <Route exact path="/home" component={Home} />

        <PrivateRoute
          exact
          path="/app"
          component={() => <h1>Private route</h1>}
        />
      </Switch>
    </BrowserRouter>
  );
};

const mapStateToProps = (state) => ({
  token: state.user.token,
});

export default connect(mapStateToProps)(Routes);
