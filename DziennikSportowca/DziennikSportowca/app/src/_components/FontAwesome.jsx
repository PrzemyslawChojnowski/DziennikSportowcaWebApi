import React, { PureComponent } from "react";
import PropTypes from "prop-types";

class FontAwesome extends PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        const {
            type,
            icon,
            size,
            fixed,
            rotate,
            flip,
            animate,
            pull,
            border,
            stack,
            inverse
        } = this.props;

        const iconSize = `fa-${size}`;
        const iconType = `fa-${icon}`;
        const fixedWidth = fixed ? "fa-fw" : "";
        const rotateClassName = rotate ? `fa-rotate-${rotate}` : "";
        const flipClassName = flip ? `fa-flip-${flip}` : "";
        const animation = animate ? `fa-${animate}` : "";
        const pullClassName = pull ? `fa-pull-${pull}` : "";
        const borderClassName = border ? `fa-border` : "";
        const stackClassName = stack ? `fa-stack-${stack}` : "";
        const inverseClassName = inverse ? `fa-inverse` : "";

        let finalClassName = `${type} ${iconType} ${iconSize} ${fixedWidth} `;
        finalClassName += `${rotateClassName} ${flipClassName} ${animation} `;
        finalClassName += `${pullClassName} ${borderClassName} ${stackClassName} `;
        finalClassName += `${inverseClassName} `;

        return <i className={finalClassName} />;
    }
}

FontAwesome.defaultProps = {
    type: "fas",
    size: "xs",
    fixed: false
};

FontAwesome.propTypes = {
    type: PropTypes.oneOf(["fas", "far", "fal", "fab"]), //Only fas and fab are of free use
    size: PropTypes.oneOf([
        "xs",
        "sm",
        "lg",
        "2x",
        "3x",
        "4x",
        "5x",
        "6x",
        "7x",
        "8x",
        "9x",
        "10x"
    ]),
    icon: PropTypes.string.isRequired,
    fixed: PropTypes.bool,
    rotate: PropTypes.oneOf(["90", "180", "270"]),
    flip: PropTypes.oneOf(["horizontal", "vertical"]),
    animate: PropTypes.oneOf(["spin", "pulse"]),
    pull: PropTypes.oneOf(["left", "right"]),
    border: PropTypes.bool,
    stack: PropTypes.oneOf(["1x", "2x", "3x", "4x"]), //and so on...
    invers: PropTypes.bool
};

export default FontAwesome;
