import React, { PureComponent } from "react";

class PulseBallLoader extends PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const { isActive } = this.props;

        return (
            <div className="overlay" style={{ display: isActive ? "block" : "none" }}>
                <div className="pulseBallSpinner"></div>
            </div>
        );
    }
}

export default PulseBallLoader;
