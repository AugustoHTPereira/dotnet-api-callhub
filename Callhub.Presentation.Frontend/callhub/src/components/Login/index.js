import React, { useState } from "react";

import { Link, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import * as UserActions from "../../store/actions/User";
import { bindActionCreators } from "redux";
import { post } from "../../services/Api";
import Popover from "../Popover";
import { FaExclamationCircle } from "react-icons/fa";

import "./style.css";

const Login = ({ setUser, setStage, setMail }) => {
  const [password, setPassword] = useState();
  const [email, setEmail] = useState();
  const [responseCode, setResponseCode] = useState(1);

  const doLogin = async (event) => {
    event.preventDefault();
    try {
      console.log("Setup request");
      const response = await post("/accounts/login", {
        email: email,
        password: password,
      });

      if (response.status === 200) {
        setUser(response.data);
        window.location.href = "/app";
      }
    } catch (error) {
      console.error(error);
      setResponseCode(error.response.status);
    }
  };

  const HandleResponseRequest = () => {
    if (responseCode !== 1) {
      switch (responseCode) {
        case 401:
          return (
            <Popover
              theme="Warning"
              message="Tem certeza de que estão corretos?"
              title="Dados inválidos"
              position="TopRight"
              timeout={7000}
              ico={<FaExclamationCircle size={36} />}
            />
          );
        case 200:
          return <Redirect to="/app" />;

        default:
          return (
            <Popover
              theme="Danger"
              message={`Algum erro não esperado ocorreu.\nTente novamente!`}
              title="Erro"
              position="TopRight"
              timeout={7000}
              ico={<FaExclamationCircle size={36} />}
            />
          );
      }
    }

    return null;
  };

  return (
    <div className="Card">
      <div className="CardHeader">
        <h1>Login</h1>
        <p>Acesso ao sistema</p>
      </div>
      <form onSubmit={(event) => doLogin(event)} className="CardBody">
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

      <HandleResponseRequest />
    </div>
  );
};

const mapStateToProps = (state) => ({});

const mapDispatchToProps = (dispatch) =>
  bindActionCreators(UserActions, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(Login);
