import React, { Component } from "react";
import "./style.css";

import UserProfile from "../../components/UserCall/UserProfile";
import CallList from "../../components/UserCall/CallList";
import SearchBar from "../../components/UserCall/SearchBar";
import CallDetails from "../../components/UserCall/CallDetails";

export class App extends Component {

  constructor(props) {
    super(props);

    this.state = {
      stage: "NULL"
    }
  }

  componentDidMount() {
    console.log("Caiu no APP");
  }

  Stage = () => {
    switch (this.state.stage) {
      case "DETAILS":
        return <CallDetails />
    
      default:
        return null;
    }
  }

  render() {
    return (
      <div className="ContentApp">
        <div className="App">
          <div className="CallList">
            <div className="Header">
              <UserProfile />
            </div>
            <SearchBar />
            <CallList />
          </div>

          <this.Stage />
        </div>
      </div>
    );
  }
}
