import React, { PureComponent } from "react";

class CubeSpinnerLoader extends PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const { isActive } = this.props;

        return (
            <div className="overlay" style={{ display: isActive ? "block" : "none" }}>
                <div className="cubeSpinner" />
            </div>
        );
    }
}

export default CubeSpinnerLoader;
