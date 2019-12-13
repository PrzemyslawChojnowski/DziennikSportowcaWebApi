import React, { PureComponent } from "react";

class RotatingBallsLoader extends PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const { isActive } = this.props;

        return (
            <div className="overlay" style={{ display: isActive ? "block" : "none" }}>
                <div className="rotatingBallsSpinner">
                    <div className="dot1" />
                    <div className="dot2" />
                </div>
            </div>
        );
    }
}

export default RotatingBallsLoader;
