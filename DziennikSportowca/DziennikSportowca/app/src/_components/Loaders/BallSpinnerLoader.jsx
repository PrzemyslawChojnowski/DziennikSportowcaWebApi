import React, { PureComponent } from "react";

class BallSpinnerLoader extends PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const { isActive } = this.props;

        return (
            <div className="overlay" style={{ display: isActive ? "block" : "none" }}>
                <div className="ballSpinner">
                    <div className="double-bounce1" />
                    <div className="double-bounce2" />
                </div>
            </div>
        );
    }
}

export default BallSpinnerLoader;
