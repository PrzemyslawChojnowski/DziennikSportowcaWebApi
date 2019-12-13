import React from "react";
import { render } from "react-dom";
import { Provider } from "react-redux";
import { Router, Route } from "react-router-dom";

import { store, history } from "./_helpers";
import { App } from "./App";

import "./styles/styles.css";

import "./_helpers/stringExtensions";

render(
    <Provider store={store}>
        <Router history={history}>
            <App />
        </Router>
    </Provider>,
    document.getElementById("app")
);
