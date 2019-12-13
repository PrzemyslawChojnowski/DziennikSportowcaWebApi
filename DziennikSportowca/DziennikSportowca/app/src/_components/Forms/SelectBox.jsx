import React, { Component } from "react";
import { Input } from "reactstrap";

class SelectBox extends Component {
    constructor(props) {
        super(props);

        this.mapOptions = this.mapOptions.bind(this);
        this.onChange = this.onChange.bind(this);
    }

    mapOptions() {
        const { options, name, placeholder } = this.props;

        let optionsToRender = [];

        optionsToRender.push(
            <option disabled selected value style={{ display: "none" }}>
                {placeholder}
            </option>
        );

        options.map((item, index) => {
            optionsToRender.push(
                <option key={`${name}.${index}`} value={item.value}>
                    {item.name}
                </option>
            );
        });

        return optionsToRender;
    }

    onChange(e) {
        if (this.props.onChange) this.props.onChange(e);
    }

    render() {
        const { name, placeholder, disabled, className, readOnly, plaintext } = this.props;

        return (
            <Input
                type="select"
                name={name}
                id={name}
                plaintext={plaintext}
                className={className}
                placeholder={placeholder}
                disabled={disabled}
                readOnly={readOnly}
                onChange={this.onChange}
            >
                {this.mapOptions()}
            </Input>
        );
    }
}

export default SelectBox;
