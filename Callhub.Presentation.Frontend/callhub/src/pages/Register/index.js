import React, { useState, useEffect } from "react";
import ChooseCompany from "../../components/Register/ChooseCompany";
import ChooseDepartment from "../../components/Register/ChooseDepartment";
import RegisterComponent from "../../components/Register";
import { Provider } from "react-redux";
import store from "../../store";
import "./style.css";

const Register = () => {
  const [stage, setStage] = useState("REGISTER");

  const stages = {
    REGISTER: <RegisterComponent next={setStage} />,
    COMPANY: <ChooseCompany next={setStage} />,
    DEPARTMENT: <ChooseDepartment next={setStage} />,
  };

  const HandleStages = () => stages[stage];

  return (
    <div className="RegisterContent">
      <div className="Centered">
        <div className="Card">
          <div className="CardHeader">
            <h1>Registro</h1>
            <p>Cadastre-se agora mesmo!</p>
          </div>
          <Provider store={store}>
            <div className="CardBody">
              <HandleStages />
            </div>
          </Provider>
        </div>
      </div>
    </div>
  );
};

export default Register;
