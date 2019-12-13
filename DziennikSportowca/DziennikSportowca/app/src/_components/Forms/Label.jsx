import React, { Component } from "react";

const Label = props => {
    return (
        <strong>
            <label htmlFor={props.htmlFor}>{`${props.children}${!props.withoutColon &&
                ":"}`}</label>
        </strong>
    );
};

export default Label;
