import React, { PureComponent } from "react";
import { connect } from "react-redux";

import { history } from "../_helpers";
import { alertActions } from "../_actions";

import NavbarContainer from "./Navbar/NavbarContainer";
import NavbarToggle from "./Navbar/NavbarToggle";
import RoutesContainer from "./RoutesContainer";
import BreadcrumbContainer from "../_components/Breadcrumb";
import RotatingCubesSpinnerLoader from "../_components/Loaders/RotatingCubesSpinnerLoader";

class App extends PureComponent {
    constructor(props) {
        super(props);

        const { dispatch } = this.props;
        history.listen((location, action) => {
            // clear alert on location change
            dispatch(alertActions.clear());
        });
    }

    render() {
        const { alert, isLoaderActive } = this.props;

        return (
            <React.Fragment>
                <RotatingCubesSpinnerLoader isActive={isLoaderActive} />
                <NavbarContainer>
                    <NavbarToggle />
                </NavbarContainer>

                <div className="jumbotron">
                    <div className="container">
                        <BreadcrumbContainer />
                        {alert.message && (
                            <div className={`alert ${alert.type}`}>{alert.message}</div>
                        )}
                        <RoutesContainer />
                    </div>
                </div>
            </React.Fragment>
        );
    }
}

function mapStateToProps(state) {
    const { alert } = state;
    return {
        alert,
        isLoaderActive: state.loader.isActive
    };
}

const connectedApp = connect(mapStateToProps)(App);
export { connectedApp as App };
