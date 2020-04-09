import React, { Component } from "react";

// import { Container } from './styles';

export default class SearchBar extends Component {
  render() {
    return (
      <div className="SearchBar">
        <input type="text" placeholder="Pesquisar" />
      </div>
    );
  }
}
