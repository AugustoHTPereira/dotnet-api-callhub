import React from "react";
import { connect } from "react-redux";
import Api from "../../../../services/Api";
import FileList from "../../../Upload/FileList";
import "./style.css";

const StepConfirmation = ({ call, setStep, accessToken }) => {
  const handleConfirmation = async () => {

    const data = {
      title: call.title,
      description: call.description,
      priority: call.priority.id,
      sectorDestinId: "30f6593e-ed42-4a4d-8588-b74bfaa61a62",
    };

    console.log("Upping request with data", data);

    try {
      const response = await Api.post("/calls", data, {
        headers: {
          Authorization: `Bearer ${accessToken}`
        }
      });

      console.warn("Api response", response);
    } catch (error) {
      console.error(error.message);
    }
  };

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
          onClick={handleConfirmation}
        >
          Confirmar
        </button>
      </div>
    </div>
  );
};

const mapStateToProps = (state) => ({
  call: state.call.newCall,
  accessToken: state.user.accessToken
});

export default connect(mapStateToProps)(StepConfirmation);
