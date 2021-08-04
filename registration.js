import React, { Component } from "react";

export class Registration extends Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <>
        <form>
          <input
            type="text"
            name="firstname"
            placeholder={"Firstname"}
            minLength={3}
            maxLength={20}
          />
          <br />
          <input
            type="text"
            name="lastname"
            placeholder={"Lastname"}
            minLength={3}
            maxLength={20}
          />
          <br />
          <input type="text" name="patron" placeholder={"Patron"} />
          <br />
          <input
            type="date"
            name="birth"
            placeholder={"Date of birth"}
            max={"2007-08-01"}
            step="1"
          />
          <br />
          <input
            type="number"
            name="height"
            placeholder={"Height"}
            min={50}
            required="required"
          />
          <br />
          <input type="submit" value="Отправить" />
        </form>
        <br />
      </>
    );
  }
}
