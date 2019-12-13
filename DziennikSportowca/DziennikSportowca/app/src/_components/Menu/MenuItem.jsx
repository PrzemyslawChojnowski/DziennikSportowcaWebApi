import React, { Component } from "react";

class MenuItem extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        const { action, name } = this.props;

        return (
            <span className="dropdown-item" onClick={action}>
                {name}
            </span>
        );
    }
}

export default MenuItem;
