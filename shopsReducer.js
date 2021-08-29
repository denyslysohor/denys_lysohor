import { ShopsActions } from "../actions/shopsActions";
import initialState from "./initialState.js";
export default function shopsReducer(state, action){
    if (!state) state = initialState.shops;
    switch (action.type) {
        case ShopsActions.GET_ALL_SHOPS:
            return Object.assign({}, state, {
                list: action.data
            });
        case ShopsActions.GET_SHOP: {
            let shopId = -1;
            let shopList = [...state.list];
            for (let jh of shopList) {
                if (jh.id === action.data.id) {
                    shopId = jh.id;
                    break;
                }
            }
            if (shopId === -1) {
                shopList.push(action.data);
                shopId = action.data.id;
            }
            return {
                list: shopList,
                viewing: shopId
            };
        }
        case ShopsActions.ADD_SHOP:
            return Object.assign({}, state, {
                list: [...state.list, action.data]
            });
        default: return state;
    }
}