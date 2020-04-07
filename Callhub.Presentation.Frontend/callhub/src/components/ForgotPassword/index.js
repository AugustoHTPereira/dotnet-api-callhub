import React, { useState } from "react";

import { Link } from "react-router-dom";

import "./style.css";

const ForgotPassword = ({ setStage, mail = "" }) => {
  const [email, setEmail] = useState(mail);

  return (
    <div className="Card">
      <div className="CardHeader">
        <h1>Recuperação de senha</h1>
        <p>Informe seu e-mail cadastrado no sistema</p>
      </div>
      <form className="CardBody">
        <input
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          type="email"
          placeholder="Digite seu e-mail"
        />

        <input type="submit" value="Verificar" />
      </form>

      <div style={{ justifyContent: "center" }} className="CardFooter">
        <a
          href="javascript:void(0)"
          onClick={(e) => {
            e.preventDefault();
            setStage("LOGIN");
          }}
          title="Voltar ao login"
        >
          Cancelar
        </a>
      </div>
    </div>
  );
};

export default ForgotPassword;
