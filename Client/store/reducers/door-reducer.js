import { DoorActionType } from "../actions/door-actions";
import { state as initialState } from "../states/door-state";

export const doorReducer = (state = initialState, action) => {
    switch (action.type) {
        case DoorActionType.CONNECT:
            return {
                connection: action.connection,
                error: state.error,
                data: state.data,
            }
        case DoorActionType.REQUEST:
            return {
                error: state.error,
                data: action.data,
                connection: state.connection,
            };
        case DoorActionType.FAILURE:
            return {
                data: state.data,
                error: action.error,
                connection: state.connection,
            };
        case DoorActionType.SUCCESS:
            return {
                error: state.error,
                data: action.data,
                connection: state.connection,
            };
        case DoorActionType.CLOSE:
            return {
                error: state.error,
                data: state.data,
                message: action.message,
                connection: state.connection,
            };
        default:
            return state;
    }
};
