import React, { PureComponent } from "react";

class Card extends PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const { children } = this.props;
        return (
            <div className="card">
                <div className="card-body">{children}</div>
            </div>
        );
    }
}

export default Card;
