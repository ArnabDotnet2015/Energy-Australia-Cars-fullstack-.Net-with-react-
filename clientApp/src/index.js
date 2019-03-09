import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import './index.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import {BrowserRouter} from 'react-router-dom';
import configureStore from './redux/store';

import App from './App';
import registerServiceWorker from './registerServiceWorker';

// Get the application-wide store instance, prepopulating with state from the server where available.
const store = configureStore()

const rootElement = document.getElementById('root');

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>,
  rootElement);

registerServiceWorker();
