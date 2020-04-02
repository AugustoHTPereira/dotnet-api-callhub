import React from "react";
import ChooseCompany from "../../components/Register/ChooseCompany";
import ChooseDepartment from "../../components/Register/ChooseDepartment";
import { Provider } from "react-redux";
import store from "../../store";

// import { Container } from './styles';

const Register = () => (
  <div>
    <Provider store={store}>
      <ChooseCompany />
      <ChooseDepartment />
    </Provider>
  </div>
);

export default Register;
