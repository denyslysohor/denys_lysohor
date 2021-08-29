import { JobHistoriesActions } from '../actions/jobHistoriesActions.js';
import initialState from './initialState.js';
export default function jobHistoriesReducer(state, action){
    if (!state) state = initialState.jobHistories;
    switch (action.type) {
        case JobHistoriesActions.GET_ALL_JOB_HISTORIES:
            return Object.assign({}, state, {
                list: action.data
            });
        case JobHistoriesActions.GET_JOB_HISTORY: {
            let jhId = -1;
            let jhList = [...state.list];
            for (let jh of jhList) {
                if (jh.id === action.data.id) {
                    jhId = jh.id;
                    break;
                }
            }
            if (jhId === -1) {
                jhList.push(action.data);
                jhId = action.data.id;
            }
            return {
                list: jhList,
                viewing: jhId
            };
        }
        case JobHistoriesActions.EMPLOY:
            return Object.assign({}, state, {
                list: [...state.list, action.data]
            });
        case JobHistoriesActions.UNEMPLOY: {
            let jhList = state.list.map(function(jh){
                return (jh.id === action.data.id ? action.data : jh);
            })
            return Object.assign({}, state, {list: jhList});
        }
        default: return state;
    }
}