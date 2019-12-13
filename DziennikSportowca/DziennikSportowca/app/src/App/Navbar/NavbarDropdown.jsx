import React from "react";
import { LinDk } from "react-router-dom";

const NavbarDropdown = props => {
    return (
        <li class="nav-item dropdown">
            <a
                className="nav-link dropdown-toggle"
                href="#"
                id="navbarDropdown"
                role="button"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
            >
                {props.name}
            </a>
            <div className="dropdown-menu" aria-labelledby="navbarDropdown">
                {props.children}
            </div>
        </li>
    );
};

export default NavbarDropdown;
