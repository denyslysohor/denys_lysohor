import { GET_USERS, DELETE_USER, CREATE_USER, UPDATE_USER } from "../types.js";

const initialState = {
  users: [],
  loading: true
};

export default function (state = initialState, action) {
  debugger;

  switch (action.type) {
    case GET_USERS:
      return {
        ...state,
        users: action.payload,
        loading: false
      };
    case DELETE_USER:
      return {
        ...state,
        users: state.users.filter(({ id }) => id !== action.payload),
        loading: false
      };
    
    case CREATE_USER:
      return {
        ...state,
        users: [...state.users, action.payload],
        loading: false
      };
    case UPDATE_USER:
      return {
        ...state,
        users: [...state.users].map((user) =>
          user.id === action.payload.id ? action.payload : user
        ),
        loading: false
      };
    default:
      return state;
  }
}
