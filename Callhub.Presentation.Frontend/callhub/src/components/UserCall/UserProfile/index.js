import React from "react";
import { connect } from "react-redux";

// import { Container } from './styles';

const UserProfile = ({ user }) => (
  <a href="/profile" className="UserProfile">
    <img
      src="https://www.zaft.com.br/cms/upload/sigu/47388_o_que_e_uma_persona_e_qual_a_sua_importancia_no_marketing_de_conteudo.jpg"
      alt=""
    />
    <div className="UserData">
      <h1>
        {user.name.split(" ")[0] +
          " " +
          user.name.split(" ")[user.name.split(" ").length - 1]}
      </h1>

      <p>{user.department ?? "- Departamento não atribuído -"}</p>
    </div>
  </a>
);

const mapStateToProps = (state) => ({
  user: state.user,
});

export default connect(mapStateToProps)(UserProfile);
