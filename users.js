import React, { Component } from "react";
import { connect } from "react-redux";
import {
  getUsers,
  deleteUser,
  createUser,
  updateUser
} from "../store/actions/usersActions";
import { UserForm } from "./userForm";

class users extends Component {
  constructor(props) {
    super(props);
    this.state = {
      editing: null
    };
    this.ondeleteUser = this.ondeleteUser.bind(this);
    this.handleFormSubmit = this.handleFormSubmit.bind(this);
  }
  componentDidMount() {
    this.props.getUsers();
  }

  ondeleteUser(id) {
    debugger;
    this.props.deleteUser(id);
  }
  handleFormSubmit(data) {
    debugger;
    //пока без валидации
    if (data.id === null) {
      this.props.createUser(data);
    } else {
      this.props.updateUser(data);
    }
  }

  render(state) {
    const { users } = this.props.users;
    return (
      <>
        {this.state.editing !== null && (
          <UserForm
            user={
              this.state.editing[0] === null
                ? {}
                : users.filter((v) => v.id === this.state.editing[0])[0]
            }
            onSubmit={(data) => {
              this.handleFormSubmit(data);
              this.setState({ editing: null });
            }}
            onCancel={() => {
              this.setState({ editing: null });
            }}
          />
        )}
        <div>
          {users.map((u) => (
            <React.Fragment key={u.id}>
              <h6
                onDoubleClick={() => {
                  this.setState({
                    editing: [u.id]
                  });
                }}
              >
                {this.state.editing !== null &&
                u.id === this.state.editing[0] ? (
                  <u>
                    {u.firstName} {u.lastName}
                  </u>
                ) : (
                  <>
                    {u.firstName} {u.lastName}
                  </>
                )}
              </h6>
              <button onClick={() => this.ondeleteUser(u.id)}>-</button>
            </React.Fragment>
          ))}
        </div>
        <br />
        <div>
          <button
            onClick={() => {
              this.setState({ editing: [null] });
            }}
            title="Создать пользователя"
          >
            +
          </button>
        </div>
      </>
    );
  }
}

const mapStateToProps = (state) => ({ users: state.users });

export default connect(mapStateToProps, {
  getUsers,
  deleteUser,
  createUser,
  updateUser
})(users);
