import React, { useState, useEffect } from "react";
import ChooseCompany from "../../components/Register/ChooseCompany";
import ChooseDepartment from "../../components/Register/ChooseDepartment";
import RegisterComponent from "../../components/Register";
import { Provider } from "react-redux";
import store from "../../store";
import { useParams } from "react-router-dom";

const Register = () => {
  const [stage, setStage] = useState("REGISTER");

  const stages = {
    REGISTER: <RegisterComponent next={setStage} />,
    COMPANY: <ChooseCompany next={setStage} />,
    DEPARTMENT: <ChooseDepartment next={setStage} />,
  };

  const HandleStages = () => stages[stage];

  return (
    <div>
      <Provider store={store}>
        <HandleStages />
      </Provider>
    </div>
  );
};

export default Register;
