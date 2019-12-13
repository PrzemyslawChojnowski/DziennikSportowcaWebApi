import React, { Component } from "react";

class NavbarToggle extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="collapse" id="navbarToggleExternalContent">
                <div className="bg-dark p-4">
                    <h4 className="text-white">Collapsed content</h4>
                    <span className="text-muted">Toggleable via the navbar brand.</span>
                </div>
            </div>
        );
    }
}

export default NavbarToggle;
