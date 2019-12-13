import React, { Component } from "react";

const FormGroup = props => {
    return (
        <div className="form-group">
            {props.label}
            {props.input}
            {props.additional}
        </div>
    );
};

export default FormGroup;
