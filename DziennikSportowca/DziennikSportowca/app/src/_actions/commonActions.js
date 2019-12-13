import { history } from "../_helpers";

function goToUrl(url) {
    history.push(url);
}

const commonActions = {
    goToUrl
};

export default commonActions;
