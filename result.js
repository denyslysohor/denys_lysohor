import React, { Component } from "react";

class Result extends Component {
  render(props) {
    return (
      <>
        <div>Your choice: {`${this.props.id}`}</div>
        <div>AI choice: {`${this.props.ran}`}</div>
        <div>Round Winner: {`${this.props.roundWinner}`}</div>
        <div>User Points: {`${this.props.UserPoints}`}</div>
        <div>AI Points: {`${this.props.AIPoints}`}</div>
        <div>
          <table border="1" width="100%">
            <thead>
              <tr>
                <th colSpan="3">History</th>
              </tr>
              <tr>
                <th>Your choice</th>
                <th>AI choice</th>
                <th>Round winner</th>
              </tr>
            </thead>
            <tbody>
              {this.props.history && this.props.history.length > 0 ? (
                this.props.history.map((v, i) => {
                  let cells = [];
                  for (let k in v) {
                    cells.push(v[k]);
                  }
                  return (
                    <tr key={`htr_${i}`}>
                      {cells.map((v, j) => (
                        <td key={`htd_${i}_${j}`}>{v}</td>
                      ))}
                    </tr>
                  );
                })
              ) : (
                <tr>
                  <td colSpan="3">No rounds yet</td>
                </tr>
              )}
            </tbody>
          </table>
          <br />
        </div>
      </>
    );
  }
}
export default Result;
