import { DoorActionType } from "../actions/door-actions";
import { state as initialState } from "../states/door-state";

export const doorReducer = (state = initialState, action) => {
    switch (action.type) {
        case DoorActionType.CONNECT:
            return {
                ...state,
                connection: action.connection,
            }
        case DoorActionType.REQUEST:
            return {
                ...state,
                data: action.data,
                subscriber: action.subscriber,
            };
        case DoorActionType.FAILURE:
            return {
                ...state,
                error: action.error,
            };
        case DoorActionType.CLOSE:
            return {
                ...state,
                message: action.message,
                subscriber: action.subscriber,
            };
        default:
            return state;
    }
};
