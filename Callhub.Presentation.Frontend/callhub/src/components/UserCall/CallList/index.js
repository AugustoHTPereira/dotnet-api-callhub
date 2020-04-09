import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import * as CallActions from "../../../store/actions/Call";
import { FaPlus } from "react-icons/fa";

class CallList extends Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    try {
      // Busca os chamados na API.

      const calls = [
        {
          id: "56165-5651-65165-651651",
          title: "Ajuste em impressora",
          lastMessage: "Preciso urgentemente que me auxiliem na impressora",
          createdAt: "2020-04-08 16:00:00",
        },
        {
          id: "56165-5651-65165-651",
          title: "chamado 01",
          lastMessage: "Preciso urgentemente que me auxiliem na impressora",
          createdAt: "2020-04-08 16:00:00",
        },
        {
          id: "56165-5651-65165-651",
          title: "chamado 01",
          lastMessage: "Preciso urgentemente que me auxiliem na impressora",
          createdAt: "2020-04-08 16:00:00",
        },
        {
          id: "56165-5651-65165-651",
          title: "chamado 01",
          lastMessage: "Preciso urgentemente que me auxiliem na impressora",
          createdAt: "2020-04-08 16:00:00",
        },
        {
          id: "56165-5651-65165-651",
          title: "chamado 01",
          lastMessage: "Preciso urgentemente que me auxiliem na impressora",
          createdAt: "2020-04-08 16:00:00",
        },
        {
          id: "56165-5651-65165-651",
          title: "chamado 01",
          lastMessage: "Preciso urgentemente que me auxiliem na impressora",
          createdAt: "2020-04-08 16:00:00",
        },
        {
          id: "56165-5651-65165-651",
          title: "chamado 01",
          lastMessage: "Preciso urgentemente que me auxiliem na impressora",
          createdAt: "2020-04-08 16:00:00",
        },
      ];

      this.props.setCalls(calls);
    } catch (error) {
      console.log(error);
    } finally {
    }
  }

  checkCall(call) {
    this.props.selectCall(call.id);
  }

  render() {
    const HandleList = () => {
      if (this.props.calls.length > 0)
        return this.props.calls.map((call, index) => (
          <li
            key={index}
            onClick={(event) => {
              event.preventDefault();
              this.checkCall(call);
            }}
          >
            <div
              className={`CallListItem ${
                call.id == this.props.selectCall.id ? "Checked" : ""
              }`}
            >
              <div className="MinDetails">
                <h1>{call.title}</h1>

                <p>{call.lastMessage}</p>
              </div>

              <div className="Info">
                {/* <span className="Date">{call.createdAt.split(" ")[1]}</span> */}
                {/* <span className="IsNew">Novo</span> */}
              </div>
            </div>
          </li>
        ));
      else return <p>Nenhum chamado encontrado</p>;
    };

    return (
      <>
        <div className="List">
          <ul>
            <HandleList />
          </ul>
        </div>

        <div className="Options">
          <button>
            <FaPlus size={12} />
            Novo
          </button>
        </div>
      </>
    );
  }
}

const mapStateToProps = (state) => ({
  calls: state.call.list,
  selectedCall: state.call.selectedCall,
});
const mapDispatchToProps = (dispatch) =>
  bindActionCreators(CallActions, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(CallList);
