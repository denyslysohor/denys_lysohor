import { ManagersActions } from "../actions/managersActions.js";
import initialState from "./initialState.js";
export default function managersReducer(state, action){
    if (!state) state = initialState.managers;
    switch (action.type) {
        case ManagersActions.GET_ALL_MANAGERS:
            return Object.assign({}, state, {
                list: action.data
            });
        case ManagersActions.GET_MANAGER: {
            let mgrId = -1;
            let mgrList = [...state.list];
            for (let jh of mgrList) {
                if (jh.id === action.data.id) {
                    mgrId = jh.id;
                    break;
                }
            }
            if (mgrId === -1) {
                mgrList.push(action.data);
                mgrId = action.data.id;
            }
            return {
                list: mgrList,
                viewing: mgrId
            };
        }
        case ManagersActions.ADD_MANAGER:
            return Object.assign({}, state, {
                list: [...state.list, action.data]
            });
        default: return state;
    }
}