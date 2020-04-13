import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import Api from "../../../services/Api";
import { connect } from "react-redux";

class MyCalls extends Component {
  constructor(props) {
    super(props);

    this.state = {
      calls: [],
    };
  }

  async componentDidMount() {
    const response = await Api.get("/users/calls", {
      headers: {
        Authorization: `Bearer ${this.props.accessToken}`,
      },
    });

    this.setState({ ...this.state, calls: response.data });
  }

  render() {
    return (
      <ul className="CallList">
        {this.state.calls.map((call, index) => (
          <li
            key={index}
            onClick={() => {
              console.log(call);
              window.location.href = `calls/${call.id}`;
            }}
            className="Call"
          >
            <div className="CallData">
              <div className="Situation">
                <span title="Finalizado" className="Badge Success"></span>
              </div>
              <div className="Details">
                <h2 className="Title">{call.title}</h2>
                <p className="Description">{call.description}</p>
              </div>
            </div>
          </li>
        ))}
      </ul>
    );
  }
}

const mapStateToProps = (state) => ({
  accessToken: state.user.accessToken,
});

export default connect(mapStateToProps)(MyCalls);
