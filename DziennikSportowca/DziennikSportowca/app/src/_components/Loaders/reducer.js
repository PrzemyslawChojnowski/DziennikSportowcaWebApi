import { combineReducers } from "redux";

import initialState from "../../_helpers/initialState";
import * as types from "../../Common/Consts/actionTypes";

const isActiveReducer = (state = initialState.loader.isActive, action) => {
    switch (action.type) {
        case types.TURN_ON_LOADER:
            return true;
        case types.TURN_OFF_LOADER:
            return false;
        default:
            return state;
    }
};

const loaderReducer = combineReducers({
    isActive: isActiveReducer
});

export default loaderReducer;
