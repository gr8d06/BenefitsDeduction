import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';

import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.min.css';
import '@fortawesome/fontawesome-free';
import './App.scss';

import EnrolledList from "./components/EnrolledList";
import Header from "./components/Header";
import Toolbar2 from "./components/Toolbar2";

ReactDOM.render(
  <React.StrictMode>
    <div className="container">
      <Header />
      <Toolbar2 />
      <Router>
        <Switch>
          <Route path="/enrollees">
            <EnrolledList />
          </Route>
        </Switch>
      </Router>
    </div>
  </React.StrictMode>,
  document.getElementById('root')
);

//Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
