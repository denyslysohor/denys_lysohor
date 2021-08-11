import React, { Component } from "react";

export class UserForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      id: props.user.id || null,
      firstName: props.user.firstName || "",
      lastName: props.user.lastName || "",
      role: props.user.role || ""
    };
    this.inputs = [
      { prop: "firstName", placeholder: "Имя" },
      { prop: "lastName", placeholder: "Фамилия" },
      { prop: "role", placeholder: "Роль" }
    ];
    this.handleInput = this.handleInput.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleCancel = this.handleCancel.bind(this);
  }
  UNSAFE_componentWillReceiveProps(props) {
    this.setState({
      id: props.user.id || null,
      firstName: props.user.firstName || "",
      lastName: props.user.lastName || "",
      role: props.user.role || ""
    });
  }
  handleInput(prop, evt) {
    if (this.state[prop] !== undefined) {
      this.setState((state) => {
        let updState = {};
        updState[prop] = evt.target.value;
        return updState;
      });
    }
  }
  handleSubmit() {
    if (!!this.props.onSubmit) {
      this.props.onSubmit({ ...this.state });
    }
  }
  handleCancel() {
    if (!!this.props.onCancel) {
      this.props.onCancel();
    }
  }
  render() {
    const inputs = this.inputs;
    return (
      <form>
        <b>{this.state.id === null ? "Создать" : "Редактировать"}</b>
        <br />
        {inputs.map((v, i) => (
          <React.Fragment key={i}>
            <input
              placeholder={v.placeholder}
              title={v.placeholder}
              type="text"
              name={v.prop}
              onInput={(e) => {
                this.handleInput(v.prop, e);
              }}
              value={this.state[v.prop]}
            />
            <br />
          </React.Fragment>
        ))}
        <button onClick={this.handleSubmit}>Сохранить</button>
        <button onClick={this.handleCancel}>Отмена</button>
      </form>
    );
  }
}
