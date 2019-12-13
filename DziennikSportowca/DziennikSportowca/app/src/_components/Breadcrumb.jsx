import React, { PureComponent } from "react";
import { connect } from "react-redux";
import { withRouter, Link } from "react-router-dom";
import { history } from "../_helpers";

class Breadcrumb extends PureComponent {
    constructor(props) {
        super(props);
    }

    mapRouteParts(location) {
        if (location && location.pathname) {
            const locationParts = location.pathname.split("/");
            let actualPath = "/";
            if (locationParts.length > 0) {
                return locationParts.map(function(path, index) {
                    actualPath += path;
                    const name = index == 0 ? "Home" : path.capitalize();
                    if (index != locationParts.length - 1) {
                        return (
                            <li class="breadcrumb-item">
                                <Link to={actualPath}>{name}</Link>
                            </li>
                        );
                    } else {
                        return (
                            <li class="breadcrumb-item active" aria-current="page">
                                {name}
                            </li>
                        );
                    }
                });
            }
        }
    }

    render() {
        const { location } = this.props;
        return (
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">{this.mapRouteParts(location)}</ol>
            </nav>
        );
    }
}

const BreadcrumbContainer = withRouter(Breadcrumb);

export default BreadcrumbContainer;
