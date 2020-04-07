import React, { useState } from "react";

import { Link } from "react-router-dom";
import { connect } from "react-redux";
import * as UserActions from "../../store/actions/User";
import { bindActionCreators } from "redux";

import "./style.css";

const Login = ({ setUser, setStage, setMail }) => {
  const [password, setPassword] = useState();
  const [email, setEmail] = useState();

  return (
    <div className="Card">
      <div className="CardHeader">
        <h1>Login</h1>
        <p>Acesso ao sistema</p>
      </div>
      <form className="CardBody">
        <input
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          type="email"
          placeholder="Digite seu e-mail"
        />
        <input
          value={password}
          onChange={(e) => setPassword(e.target.value)}
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
            setMail(email);
            setStage("FORGOTPASSWORD");
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
};

const mapStateToProps = (state) => ({});

const mapDispatchToProps = (dispatch) =>
  bindActionCreators(UserActions, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(Login);
