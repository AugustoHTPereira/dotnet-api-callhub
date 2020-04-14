import React, { Component } from "react";
import Header from "../../../components/Header";
import Sidebar from "../../../components/Sidebar";
import Loading from "../../../components/Loading";
import "./style.css";
import { toast } from "react-toastify";
import * as Api from "../../../services/Api";
import { connect } from "react-redux";

class DetailsCall extends Component {
  constructor(props) {
    super(props);

    this.state = {
      call: null,
      isLoading: true,
    };
  }

  async getCall(id) {
    try {
      const response = await Api.get(`calls/${id}`, {
        Authorization: `Bearer ${this.props.accessToken}`,
      });

      await this.setState({
        ...this.state,
        call: response.data,
        isLoading: false,
      });

      toast.info(
        `Este chamado está aguardando uma resposta sua. Clique aqui para ir direto para a caixa de resposta.`,
        {
          autoClose: 8500,
          position: toast.POSITION.TOP_RIGHT,
        }
      );
    } catch (error) {
      toast.error("Falha! " + error.message);
    }
  }

  componentWillMount() {
    if (this.props.match.params) {
      this.getCall(this.props.match.params.id);
    }
  }

  render() {
    return (
      <div className="PageContent DetailsCallContent">
        <Header />
        <div className="Container">
          <Sidebar />
          {this.state.call && (
            <div className="Content">
              <h3 className="PageTitle">
                Detalhes do chamado
                <span className="Identity">#{this.state.call.id}</span>
              </h3>

              <div className="Details">
                {this.state.call.priority && (
                  <p>Prioridade: {this.state.call.priority}</p>
                )}

                {this.state.call.category && <p>Categoria: Suporte</p>}

                <p>Criador: Augusto Henrique Tomba Pereira</p>

                <p>Data: {this.state.call.createdAt}</p>

                <div className="Situation Warning">
                  <span className="Text">Concluído</span>
                </div>
              </div>

              <h1 className="CallTitle">{this.state.call.title}</h1>

              <p className="CallDescription">{this.state.call.description}</p>

              {this.state.call.attachs && (
                <ul className="Attachs">
                  {this.state.call.attach.map((attach) => (
                    <li className="Attach">
                      <img
                        src="https://d13es1p1rl0iq1.cloudfront.net/wp-content/uploads/2019/09/plenonews_69429078_424547198412357_2917137491588994799_n-1024x684.jpg"
                        alt=""
                      />

                      <div className="Attach-Details">
                        <p>profile.png</p>
                        <span>277 kb</span>
                      </div>
                    </li>
                  ))}

                  {/* <li className="Attach">
                    <div className="Attach-PDF">.pdf</div>

                    <div className="Attach-Details">
                      <p>profile.png</p>
                      <span>277 kb</span>
                    </div>
                  </li>

                  <li className="Attach">
                    <div className="Attach-XLS">.xls</div>

                    <div className="Attach-Details">
                      <p>profile.png</p>
                      <span>277 kb</span>
                    </div>
                  </li>

                  <li className="Attach">
                    <div className="Attach-Default">.rar</div>

                    <div className="Attach-Details">
                      <p>profile.png</p>
                      <span>277 kb</span>
                    </div>
                  </li>*/}
                </ul>
              )}

              <span className="Separator"></span>

              <div className="Response">
                <textarea placeholder="Resposta" cols="30" rows="7"></textarea>
                <div className="Actions">
                  <button className="Link">Limpar</button>
                  <button className="Btn">Enviar</button>
                </div>
              </div>

              <div>
                <ul className="TimeLine">
                  {this.state.call.timeline.map((item) => (
                    <li className="HistoricItem">
                      <i className="TextGray">
                        _ Augusto Henrique Tomba Pereira
                      </i>
                      <p>
                        Donec a mattis mi, sit amet ornare lectus. Ut libero
                        erat, lobortis a enim vel, semper molestie orci. Sed eu
                        elit et purus varius ultrices in ut ante. Donec
                        malesuada nunc est, a euismod sem sagittis ac.
                      </p>
                      <i className="TextGray Right">04/04/2020</i>

                      {item.attachs && (
                        <ul className="Attachs">
                          {item.attachs.map((attach) => (
                            <li>
                              <img
                                src="https://d13es1p1rl0iq1.cloudfront.net/wp-content/uploads/2019/09/plenonews_69429078_424547198412357_2917137491588994799_n-1024x684.jpg"
                                alt=""
                              />

                              <div className="Attach-Details">
                                <p>profile-picture-sdljflkflajs.png</p>
                                <span>277 kb</span>
                              </div>
                            </li>
                          ))}
                          {/* <li>
                            <div className="Attach-XLS">.xls</div>

                            <div className="Attach-Details">
                              <p>profile.png</p>
                              <span>277 kb</span>
                            </div>
                          </li> */}
                        </ul>
                      )}
                    </li>
                  ))}
                </ul>
              </div>
            </div>
          )}

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

const mapStateToProps = (state) => ({
  accessToken: state.user.accessToken,
});

export default connect(mapStateToProps)(DetailsCall);
