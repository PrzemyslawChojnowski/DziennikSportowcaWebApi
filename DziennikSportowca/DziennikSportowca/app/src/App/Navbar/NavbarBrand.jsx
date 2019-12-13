import React from "react";
import { Link } from "react-router-dom";

const NavbarBrand = props => {
    return (
        <div className="navbar-brand">
            <Link to={props.to}>
                {props.children}
            </Link>
        </div>
    );
};

export default NavbarBrand;
