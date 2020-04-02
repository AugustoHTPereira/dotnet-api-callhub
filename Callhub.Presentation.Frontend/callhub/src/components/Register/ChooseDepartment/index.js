import React from "react";
import { connect } from "react-redux";


const ChooseDepartment = ({ company }) => {
  const ShowDepartments = () => {
    if (company.departments) {
      return company.departments.map(department => (
        <li key={department.id}>{department.name}</li>
      ));
    }

    return null;
  };

  return (
    <div>
      <h1>
        Choose a department in company <strong>{company.name}</strong>
      </h1>

      <ul>
        <ShowDepartments />
      </ul>
    </div>
  );
};

export default connect(state => ({ company: state.company.selected }))(
  ChooseDepartment
);
