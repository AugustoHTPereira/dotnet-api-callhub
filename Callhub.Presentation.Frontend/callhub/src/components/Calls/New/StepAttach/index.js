import React, { useState } from "react";
import { connect } from "react-redux";
import { setNewCallAttachs } from "../../../../store/actions/Call";
import { FaPlus } from "react-icons/fa";
import filesize from "filesize";

import "./style.css";
import Upload from "../../../Upload";
import FileList from "../../../Upload/FileList";

class StepAttach extends React.Component {
  constructor(props) {
    super(props);
  }

  handleUpload = (files) => {


    const uploadedFiles = files.map((file, index) => ({
      file,
      id: index,
      name: file.name,
      size: filesize(file.size),
      preview: URL.createObjectURL(file),
      uploaded: true,
      error: false,
    }))

    this.props.setAttachs(uploadedFiles);
    console.log("Files", files);
    console.log("CALLS", this.props.call);
  };

  render() {
    return (
      <div className="ContentAttach">
        <h3 className="PageTitle">Arquivos</h3>

        <Upload onUpload={this.handleUpload} />

        <FileList files={this.props.attachs} />

        <div className="Options">
          <a href="#" onClick={() => this.props.setStep("PRIORITY")}>
            Voltar
          </a>

          <button onClick={() => this.props.setStep("CONFIRMATION")}>próximo</button>
        </div>
      </div>
    );
  }
}

const mapDispatchToProps = (dispatch) => ({
  setAttachs: (Attachs) => dispatch(setNewCallAttachs(Attachs)),
});

const mapStateToProps = (state) => ({
  call: state,
  attachs: state.call.newCall.attachs
});

export default connect(mapStateToProps, mapDispatchToProps)(StepAttach);
