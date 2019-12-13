import React, { Component } from "react";

import UserContainer from "./UserContainer";
import NavbarItem from "./NavbarItem";
import NavbarItemsContainer from "./NavbarItemsContainer";
import NavbarBrand from "./NavbarBrand";
import NavbarDropdown from "./NavbarDropdown";
import MenuItem from "../../_components/Menu/MenuItem";

import langs from "../../Common/Consts/langs.pl";
import urls from "../../Common/Consts/urls";

import NavbarToggle from "./NavbarToggle";

class Navbar extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        const { currentUser, logout, goToUrl } = this.props;

        return (
            <div className="pos-f-t">
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                    <NavbarItemsContainer>
                        <NavbarBrand to={urls.home}>{langs.labels.appName}</NavbarBrand>
                        <NavbarItem to={urls.login} name={langs.labels.login} />
                    </NavbarItemsContainer>
                    <UserContainer>
                        {currentUser && <MenuItem name={langs.labels.logout} action={logout} />}
                        <MenuItem name={langs.labels.login} action={() => goToUrl(urls.login)} />
                        <MenuItem
                            name={langs.labels.register}
                            action={() => goToUrl(urls.register)}
                        />
                    </UserContainer>
                </nav>
            </div>
        );
    }
}

export default Navbar;
