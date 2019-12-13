import React, { PureComponent } from "react";
import Button from "../Button";
import FontAwesome from "../FontAwesome";

class TableActionButton extends PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const { onClick, icon, type, ...otherProps } = this.props;
        return (
            <Button onClick={onClick} size="sm" outline type="primary" {...otherProps}>
                <FontAwesome icon={icon} size="1x" type={type} />
            </Button>
        );
    }
}

export default TableActionButton;
