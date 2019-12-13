import React, { PureComponent } from "react";
import PropTypes from "prop-types";

class TableColumn extends PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const { label, name, format } = this.props;

        return (
            (!format && (
                <th scope="col" name={name} key={name}>
                    {label}
                </th>
            )) || (
                <th scope="col" name={name} key={name}>
                    {format}
                </th>
            )
        );
    }
}

TableColumn.propTypes = {
    label: PropTypes.string.isRequired,
    propertyName: PropTypes.string,
    format: PropTypes.object
};

export default TableColumn;
