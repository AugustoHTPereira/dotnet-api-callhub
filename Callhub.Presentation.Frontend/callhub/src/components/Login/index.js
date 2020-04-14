import React, { useState, Component } from "react";

import { Link, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import * as UserActions from "../../store/actions/User";
import { bindActionCreators } from "redux";
import { post } from "../../services/Api";
import { useHistory } from "react-router-dom";

import "./style.css";

class Login extends Component {
  constructor(props) {
    super(props);

    this.state = {
      password: "",
      email: "",
      stayLogged: false,
    };
  }

  componentDidMount() {}

  doLogin = async (event) => {
    event.preventDefault();
    this.props.clearStorageUser();
    try {
      const response = await post("/accounts/login", {
        email: this.state.email,
        password: this.state.password,
      });

      const data = {
        accessToken: response.data.accessToken,
        expiressAt: response.data.expiressAt,
        ...response.data.user,
        stayLogged: this.state.stayLogged,
        role: response.data.user.role.name || "INTERN",
      };

      console.log(data);

      this.props.setUser(data);
      window.location.href = "/app";
    } catch (error) {
      console.error(error);
      if (error.response.status == 401) alert("Acesso negado");
    }
  };

  render() {
    return (
      <div className="Card">
        <div className="CardHeader">
          <h1>Login</h1>
          <p>Acesso ao sistema</p>
        </div>
        <form onSubmit={(event) => this.doLogin(event)} className="CardBody">
          <input
            value={this.state.email}
            onChange={(e) =>
              this.setState({ ...this.state, email: e.target.value })
            }
            type="email"
            placeholder="Digite seu e-mail"
          />
          <input
            value={this.state.password}
            onChange={(e) =>
              this.setState({ ...this.state, password: e.target.value })
            }
            type="password"
            placeholder="Digite sua senha"
          />

          <input type="submit" value="Entrar" />
        </form>

        <div className="CardFooter">
          <a
            href="javascript:void(0)"
            onClick={(e) => {
              e.preventDefault();
              this.props.setStage("FORGOTPASSWORD");
            }}
            title="Recuperar acesso"
          >
            Esqueci minha senha
          </a>

          <span className="Pipe"></span>

          <Link to="/register" title="Registrar no sistema">
            Não possuo uma conta
          </Link>
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => ({
  user: state.user,
  token: state.user.token,
});

const mapDispatchToProps = (dispatch) =>
  bindActionCreators(UserActions, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(Login);
