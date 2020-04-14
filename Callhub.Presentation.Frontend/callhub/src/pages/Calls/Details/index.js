import React, { Component } from "react";
import Header from "../../../components/Header";
import Sidebar from "../../../components/Sidebar";
import Loading from "../../../components/Loading";
import "./style.css";
import { toast } from "react-toastify";

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
      this.setState({
        ...this.state,
        callId: this.props.match.params.id,
        isLoading: false,
      });

      toast.info(
        `Este chamado está aguardando uma resposta sua. Clique aqui para ir direto para a caixa de resposta.`,
        {
          autoClose: 8500,
          position: toast.POSITION.TOP_RIGHT
        }
      );
    }
  }

  render() {
    return (
      <div className="PageContent DetailsCallContent">
        <Header />
        <div className="Container">
          <Sidebar />
          <div className="Content">
            <h3 className="PageTitle">
              Detalhes do chamado
              <span className="Identity">#{this.state.callId}</span>
            </h3>

            <div className="Details">
              <p>Prioridade: Média</p>

              <p>Categoria: Suporte</p>

              <p>Criador: Augusto Henrique Tomba Pereira</p>

              <p>Data: 04/04/2020 14:33:55 - 06/04/2020 14:33:55</p>

              <div className="Situation Warning">
                <span className="Text">Concluído</span>
              </div>
            </div>

            <h1 className="CallTitle">
              Neque porro quisquam est qui dolorem ipsum quia dolor sit amet,
              consectetur, adipisci velit
            </h1>

            <p className="CallDescription">
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer
              justo neque, congue vel efficitur id, finibus ut ex. Fusce erat
              eros, mollis ut consectetur non, efficitur in orci. Maecenas sed
              posuere elit. Integer sed rhoncus mi, et dapibus sem. Donec ac
              ornare dui, ut auctor nunc. Duis id ligula id nunc accumsan
              tristique quis vel ex. Ut quis erat laoreet, rutrum justo vitae,
              aliquet odio. Sed scelerisque mi nisi, nec maximus metus aliquam
              ut. Proin auctor enim risus, sed posuere massa gravida nec.
              Vestibulum porta hendrerit quam, ac vehicula sapien sodales nec.
              Donec a mattis mi, sit amet ornare lectus. Ut libero erat,
              lobortis a enim vel, semper molestie orci. Sed eu elit et purus
              varius ultrices in ut ante. Donec malesuada nunc est, a euismod
              sem sagittis ac.
            </p>

            <ul className="Attachs">
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

              <li className="Attach">
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
              </li>
            </ul>

            <span className="Separator"></span>

            <div className="Response">
              <textarea placeholder="Resposta" cols="30" rows="7"></textarea>
              <div className="Actions">
                <a href="#">Limpar</a>
                <button>Enviar</button>
              </div>
            </div>

            <div>
              <ul className="TimeLine">
                <li className="HistoricItem">
                  <i className="TextGray">_ Augusto Henrique Tomba Pereira</i>
                  <p>
                    Donec a mattis mi, sit amet ornare lectus. Ut libero erat,
                    lobortis a enim vel, semper molestie orci. Sed eu elit et
                    purus varius ultrices in ut ante. Donec malesuada nunc est,
                    a euismod sem sagittis ac.
                  </p>
                  <i className="TextGray Right">04/04/2020</i>
                </li>
                <li className="HistoricItem">
                  <i className="TextGray">_ Augusto Henrique Tomba Pereira</i>
                  <p>
                    Donec a mattis mi, sit amet ornare lectus. Ut libero erat,
                    lobortis a enim vel, semper molestie orci. Sed eu elit et
                    purus varius ultrices in ut ante. Donec malesuada nunc est,
                    a euismod sem sagittis ac.
                  </p>
                  <i className="TextGray Right">04/04/2020</i>
                </li>
                <li className="HistoricItem">
                  <i className="TextGray">_ Augusto Henrique Tomba Pereira</i>
                  <p>
                    Donec a mattis mi, sit amet ornare lectus. Ut libero erat,
                    lobortis a enim vel, semper molestie orci. Sed eu elit et
                    purus varius ultrices in ut ante. Donec malesuada nunc est,
                    a euismod sem sagittis ac.
                  </p>
                  <i className="TextGray Right">04/04/2020</i>

                  <ul className="Attachs">
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
                    <li>
                      <div className="Attach-XLS">.xls</div>

                      <div className="Attach-Details">
                        <p>profile.png</p>
                        <span>277 kb</span>
                      </div>
                    </li>
                  </ul>
                </li>
              </ul>
            </div>
          </div>

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
