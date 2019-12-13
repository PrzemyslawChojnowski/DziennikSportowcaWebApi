import React from "react";

const Tab = props => {
    return (
        <a
            className="nav-item nav-link active"

            id={props.id}
            data-toggle="tab"
            href="#nav-home"
            role="tab"
            aria-controls="nav-home"
            aria-selected="true"
        >
            {props.name}
        </a>
    );
};
export default Tab;
