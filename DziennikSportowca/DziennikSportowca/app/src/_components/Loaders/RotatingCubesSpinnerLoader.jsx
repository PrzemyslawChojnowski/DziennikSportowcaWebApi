import React, { PureComponent } from "react";

class RotatingCubesSpinnerLoader extends PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const { isActive } = this.props;

        return (
            <div className="overlay" style={{ display: isActive ? "block" : "none" }}>
                <div className="rotatingCubesSpinner">
                    <div className="cube1" />
                    <div className="cube2" />
                </div>
            </div>
        );
    }
}

export default RotatingCubesSpinnerLoader;
