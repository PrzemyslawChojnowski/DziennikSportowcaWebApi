import React from "react";
import { Route, Switch } from "react-router-dom";

import { PrivateRoute } from "../_components";
import { HomePage } from "../HomePage";
import { LoginPage } from "../LoginPage";
import { RegisterPage } from "../RegisterPage";

import urls from "../Common/Consts/urls";

const RoutesContainer = props => {
    return (
        <main>
            <Switch>
                <PrivateRoute exact path={urls.default} component={HomePage} />
                <Route path={urls.home} component={HomePage} />
                <Route path={urls.login} component={LoginPage} />
                <Route path={urls.register} component={RegisterPage} />
            </Switch>
        </main>
    );
};

export default RoutesContainer;
