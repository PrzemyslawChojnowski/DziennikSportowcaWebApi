import { connect } from "react-redux";
import Navbar from "./Navbar";

import { userActions } from "../../_actions/userActions";
import commonActions from "../../_actions/commonActions";

const mapStateToProps = (state, ownProps) => {
    return {
        currentUser: state.authentication.user
    };
};

const mapDispatchToProps = dispatch => {
    return {
        logout: () => dispatch(userActions.logout()),
        goToUrl: url => commonActions.goToUrl(url)
    };
};

const NavbarContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(Navbar);

export default NavbarContainer;
