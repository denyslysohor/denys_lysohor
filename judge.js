import React, { Component } from "react";
import Result from "./result";

class Judge extends Component {
  constructor(props) {
    super(props);

    this.state = {
      count: 10,
      ran: "",
      id: "",
      temp: Math.floor(Math.random() * 3 + 1),
      UserPoints: 0,
      AIPoints: 0,
      roundLimit: 10,
      roundWinner: "",
      history: []
    };

    this.lottery = this.lottery.bind(this);
  }

  lottery = (event, temp) => {
    const UserChoice = event.target.id;
    this.setState({ id: UserChoice });
    const AIchoice = ["Paper", "Stone", "Scissors"][
      Math.floor(Math.random() * 3)
    ];
    this.setState({ ran: AIchoice });
    console.log("ai; state =", this.state.ran, "but variable =", AIchoice);
    console.log("user: state =", this.state.id, "but variable =", UserChoice);
    if (
      (UserChoice === "Paper" && AIchoice === "Stone") ||
      (UserChoice === "Stone" && AIchoice === "Scissors") ||
      (UserChoice === "Scissors" && AIchoice === "Paper")
    ) {
      this.setState(({ UserPoints, roundWinner }) => ({
        UserPoints: UserPoints + 1,
        roundWinner: "User"
      }));
    } else if (UserChoice === AIchoice) {
      this.setState(({ roundWinner }) => ({
        roundWinner: "Draw"
      }));
    } else {
      this.setState(({ AIPoints, roundWinner }) => ({
        AIPoints: AIPoints + 1,
        roundWinner: "AI"
      }));
    }
    this.setState((state) => {
      let newHistory = state.history.slice();
      newHistory.push([UserChoice, AIchoice, state.roundWinner]);
      return {
        history: newHistory
      };
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
