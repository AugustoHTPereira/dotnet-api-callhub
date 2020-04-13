import React, { Component } from "react";
import Header from "../../../components/Header";
import Sidebar from "../../../components/Sidebar";
import Loading from "../../../components/Loading";
import "./style.css";

export default class DetailsCall extends Component {
  constructor(props) {
    super(props);

    this.state = {
      callId: null,
      isLoading: true,
    };
  }

  componentWillMount() {
    if (this.props.match.params) {
      this.setState({ ...this.state, callId: this.props.match.params.id, isLoading: false });
    }
  }

  render() {
    return (
      <div className="PageContent DetailsCallContent">
        <Header />
        <div className="Container">
          <Sidebar />
          <h3 className="PageTitle">
            Detalhes do chamado<span className="Identity">#{this.state.callId}</span>
          </h3>

          {this.state.isLoading && (
            <div
              style={{
                position: "absolute",
                top: 0,
                right: 0,
                left: 0,
                bottom: 0,
                backgroundColor: "#43434344",
              }}
            >
              <Loading text="Buscando informações..." />
            </div>
          )}
        </div>
      </div>
    );
  }
}
