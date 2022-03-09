import { DoorActionType } from "../actions/door-actions";
import { state as initialState } from "../states/door-state";

export const doorReducer = (state = initialState, action) => {
    switch (action.type) {
        case DoorActionType.REQUEST:
            return {
                error: state.error,
                data: action.data
            };
        case DoorActionType.FAILURE:
            return {
                data: state.data,
                error: action.error
            };
        default:
            return state;
    }
};
