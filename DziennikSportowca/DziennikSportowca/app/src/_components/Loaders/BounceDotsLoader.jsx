import React, { PureComponent } from "react";

class BounceDotsLoader extends PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const { isActive } = this.props;

        return (
            <div className="overlay" style={{ display: isActive ? "block" : "none" }}>
                <div className="bounceDotsSpinner">
                    <div className="bounce1" />
                    <div className="bounce2" />
                    <div className="bounce3" />
                </div>
            </div>
        );
    }
}

export default BounceDotsLoader;
