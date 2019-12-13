import { combineReducers } from "redux";
import { reducer as formReducer } from "redux-form";

import { authentication } from "./authenticationReducer";
import { registration } from "./registrationReducer";
import { users } from "./usersReducer";
import { alert } from "./alertReducer";
import loaderReducer from "../_components/Loaders/reducer";

const rootReducer = combineReducers({
    authentication,
    registration,
    users,
    alert,
    form: formReducer,
    loader: loaderReducer
});

export default rootReducer;
