import React from "react";
import { Link } from "react-router-dom";

const NavbarItem = props => {
    let className = "nav-link ";
    if (props.dropdown) className = "dropdown-item ";
    if (props.className) className += props.className;

    return (
        <li className="nav-item">
            <Link className={className} to={props.to}>
                {props.name}
            </Link>
        </li>
    );
};

export default NavbarItem;
