import React, { Component } from "react";
import Result from "./result";
import XHR from "../logic/XHR.js";

class Judge extends Component {
  constructor(props) {
    super(props);

    this.state = {
      count: 10,
      ran: "",
      id: "",
      UserPoints: 0,
      AIPoints: 0,
      roundLimit: 10,
      roundWinner: "",
      history: []
    };

    this.lottery = this.lottery.bind(this);
  }
  
  // перспектива: загрузить историю с сеервера (TODO: реализовать ответ на бэке)
  /*
  componentDidMount(){
    XHR.sendXHRPostJSON(XHR.backendURI+'api/Game', {
      action: "judgeLoadHistory"
    }, (data)=>{
      let history = JSON.parse(data);
      if (!history) history = [];
      this.setState({
        history: history
      });
    }, (status)=>{
      if (!status) alert('Не удалось установить соединение с сервером');
      else alert(`Не удалось получить историю раундов (код статуса HTTP: $(status))`);
    });
  }
  */

  lottery(event) {

    let UserChoice = event.target.id;
    XHR.sendXHRPostJSON(XHR.backendURI+'api/games/', {
      actionString: UserChoice
    }, (response) => {
      this.setState((state) => {
        let newHistory = state.history.slice();
        newHistory.push([UserChoice,null,null]);
        return {
          id: UserChoice,
          history: newHistory
        }
      });
    }, (status) => {
      if (!status)
        alert('Не удалось установить соединение с сервером');
      else
        alert(`Не удалось произвести обмен данными с сервером (код статуса HTTP: ${status})`);
    });
  };
  render(props) {
    return (
      <>
        <button onClick={this.lottery} id="Paper" className={"paper"}></button>
        <button onClick={this.lottery} id="Stone" className={"stone"}></button>
        <button
          onClick={this.lottery}
          id="Scissors"
          className={"scissors"}
        ></button>
        <Result
          id={this.state.id}
          ran={this.state.ran}
          roundWinner={this.state.roundWinner}
          UserPoints={this.state.UserPoints}
          AIPoints={this.state.AIPoints}
          history={this.state.history}
        />
      </>
    );
  }
}

export default Judge;
