import {createStore, applyMiddleware} from 'redux';
import {default as ReduxThunkDefault} from 'redux-thunk';
import generalReducer from './reducers/generalReducer.js';

const store = createStore(generalReducer, applyMiddleware(ReduxThunkDefault));
export default store;