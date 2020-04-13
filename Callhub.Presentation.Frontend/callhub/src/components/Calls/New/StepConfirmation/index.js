import React from "react";
import { connect } from "react-redux";
import FileList from "../../../Upload/FileList";
import "./style.css";

const StepConfirmation = ({ call, setStep }) => {
  return (
    <div className="ContentConfirmation">
      <h3 className="PageTitle">Confirmação</h3>

      <div>
        <h2 className="CallTitle">{call.title}</h2>
      </div>

      <div>
        <p className="CallDescription">{call.description}</p>
      </div>

      <div>
        <p className="CallPriority">Prioridade {call.priority.name}</p>
      </div>

      <div className="CallFileList">
        <FileList files={call.attachs} />
      </div>

      <div className="Options">
        <a href="#" onClick={() => setStep("ATTACH")}>
          Voltar
        </a>

        <button
          onClick={() => {
            /* STORE CALL */
          }}
        >
          Confirmar
        </button>
      </div>
    </div>
  );
};

const mapStateToProps = (state) => ({
  call: state.call.newCall,
});

export default connect(mapStateToProps)(StepConfirmation);
