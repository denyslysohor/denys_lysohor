import React from 'react';
import ReactDOM from 'react-dom';

import {Provider, connect} from 'react-redux';

import './index.css';
import App from './components/App';

import store from './logic/store/store.js';

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <App />
    </Provider>
  </React.StrictMode>,
  document.getElementById('root')
);

//TODO: стили
//TODO: обернуть App в react-redux, чтобы передать в атрибуты действия и части состояния