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

    {() =>
      text ? (
        <>
          <h1>Aguarde</h1>
          <p>{text}</p>
        </>
      ) : null
    }
  </div>
);

export default Loading;
