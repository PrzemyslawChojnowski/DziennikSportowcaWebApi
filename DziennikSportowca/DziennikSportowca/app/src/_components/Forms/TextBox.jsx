import React, { Component } from "react";

class TextBox extends Component {
    constructor(props) {
        super(props);

        this.onChange = this.onChange.bind(this);
    }

    onChange(e) {
        const invariantText = e.target.value && e.target.value.replace(",", ".");

        if (this.props.onChange) this.props.onChange(invariantText);
    }

    get value() {
        return this.props.value && this.props.value.toString();
    }

    render() {
        const { name, placeholder, help, disabled, className, readOnly, plaintext } = this.props;

        let inputClasses = "form-control";

        if (plaintext) inputClasses += "-plaintext";

        if (className) inputClasses += " " + className;

        return (
            <input
                type="text"
                className={inputClasses}
                id={name}
                aria-describedby={help}
                placeholder={placeholder}
                disabled={disabled || plaintext}
                onChange={this.onChange}
                value={this.value}
                readOnly={readOnly}
            />
        );
    }
}

export default TextBox;
