import React from "react";
import { connect } from "react-redux";
import * as CompanyActions from "../../../store/actions/Company";
import { bindActionCreators } from "redux";

const ChooseCompany = ({ companies, chooseCompany }) => {
  return (
    <div>
      <h1>Choose a company</h1>

      <ul>
        {companies.map(company => (
          <li key={company.id}>
            {company.name}
            <button onClick={() => chooseCompany(company)}>
              Select
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
};

const mapStateToProps = state => ({
  companies: state.company.list
});

const mapDispatchToProps = dispatch => bindActionCreators(CompanyActions, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(
  ChooseCompany
);
