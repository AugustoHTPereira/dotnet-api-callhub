import React, { Component } from "react";

// import { Container } from './styles';

export default class CallHeader extends Component {
  render() {
    return (
      <div className="Header">
        <div className="CallTitle">
          <h1>Ajuste impressora</h1>
          <span>Há 26 min atrás</span>
        </div>
        <div className="CallData">
          <p className="Badge">Software</p>
          <p className="Badge">Aprimoramento de sistemas</p>
        </div>
      </div>
    );
  }
}
