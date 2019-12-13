import React, { Component } from "react";
import { connect } from "react-redux";

class User extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        const { currentUser } = this.props;
        const userName =
            currentUser && currentUser.firstName && currentUser.lastName && currentUser.username
                ? `${currentUser.firstName} ${currentUser.lastName} (${currentUser.username})`
                : "Niezalogowany";
        return (
            <div className="float-right">
                <div className="nav-item dropdown">
                    <a
                        className="nav-link dropdown-toggle"
                        href="#"
                        id="navbarDropdownMenuLink"
                        data-toggle="dropdown"
                        aria-haspopup="true"
                        aria-expanded="false"
                    >
                        <i className="far fa-user fa-2x" data-toggle="tooltip" title={userName} />
                    </a>
                    {this.props.children && (
                        <div
                            className="dropdown-menu dropdown-menu-right"
                            aria-labelledby="navbarDropdownMenuLink"
                        >
                            {this.props.children}
                        </div>
                    )}
                </div>
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        currentUser: state.authentication.user
    };
}

const UserContainer = connect(mapStateToProps)(User);
export default UserContainer;
