import React, { PureComponent } from "react";

class Accordion extends PureComponent {
    constructor(props) {
        super(props);

        this.generateCard = this.generateCard.bind(this);
    }

    generateCard() {
        const { children, header, defaultCollapsed } = this.props;

        return (
            <div className="card">
                <div className="card-header" id="accordionHeader">
                    <h5 className="mb-0">
                        <button
                            className="btn btn-link"
                            data-toggle="collapse"
                            data-target="#accordionBody"
                            aria-expanded={defaultCollapsed && "true"}
                            aria-controls="accordionBody"
                        >
                            {header}
                        </button>
                    </h5>
                </div>

                <div
                    id="accordionBody"
                    className={`collapse ${defaultCollapsed && "show"}`}
                    aria-labelledby="accordionHeader"
                    data-parent="#accordion"
                >
                    <div className="card-body">{children}</div>
                </div>
            </div>
        );
    }

    render() {
        return <div id="accordion">{this.generateCard()}</div>;
    }
}

Accordion.defaultProps = {
    defaultCollapsed: true
};

export default Accordion;
