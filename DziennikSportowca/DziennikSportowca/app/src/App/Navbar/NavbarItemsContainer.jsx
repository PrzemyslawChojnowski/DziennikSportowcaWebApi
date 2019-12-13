import React from "react";

const NavbarItemsContainer = props => {
    return (
        <div className="collapse navbar-collapse" id="navbarText">
            <ul className="navbar-nav mr-auto">{props.children}</ul>
        </div>
    );
};

export default NavbarItemsContainer;
