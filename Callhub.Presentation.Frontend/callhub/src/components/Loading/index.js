import React from "react";
import "./style.css";

const Loading = ({ text = "Carregando..." }) => (
  <div className="LoadingContent">
    <div class="lds-roller">
      <div></div>
      <div></div>
      <div></div>
      <div></div>
      <div></div>
      <div></div>
      <div></div>
      <div></div>
    </div>

    <h1>Aguarde</h1>
    <p>{text}</p>
  </div>
);

export default Loading;
