import {combineReducers} from 'redux';

import shopsReducer from './shopsReducer.js';
import managersReducer from './managersReducer.js';
import jobHistoriesReducer from './jobHistoriesReducer.js';

const generalReducer = combineReducers({
    shops: shopsReducer,
    managers: managersReducer,
    jobHistories: jobHistoriesReducer
});
export default generalReducer;