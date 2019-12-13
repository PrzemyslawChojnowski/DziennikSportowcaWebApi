import React, { PureComponent } from "react";

class CircleLoader extends PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const { isActive } = this.props;

        return (
            <div className="overlay" style={{ display: isActive ? "block" : "none" }}>
                <div className="sk-circle">
                    <div className="sk-circle1 sk-child" />
                    <div className="sk-circle2 sk-child" />
                    <div className="sk-circle3 sk-child" />
                    <div className="sk-circle4 sk-child" />
                    <div className="sk-circle5 sk-child" />
                    <div className="sk-circle6 sk-child" />
                    <div className="sk-circle7 sk-child" />
                    <div className="sk-circle8 sk-child" />
                    <div className="sk-circle9 sk-child" />
                    <div className="sk-circle10 sk-child" />
                    <div className="sk-circle11 sk-child" />
                    <div className="sk-circle12 sk-child" />
                </div>
            </div>
        );
    }
}

export default CircleLoader;
