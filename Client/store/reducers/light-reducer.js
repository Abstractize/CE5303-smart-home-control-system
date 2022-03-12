import { LightActionType } from "../actions/light-actions";
import { state as initialState } from "../states/light-state";

export const lightReducer = (state = initialState, action) => {
    switch (action.type) {
        case LightActionType.CONNECT:
            return {
                ...state,
                connection: action.connection,
            }
        case LightActionType.REQUEST:
            return {
                ...state,
                data: action.data,
                subscriber: action.subscriber,
            };
        case LightActionType.FAILURE:
            return {
                ...state,
                error: action.error,
            };
        case LightActionType.CLOSE:
            return {
                ...state,
                message: action.message,
                subscriber: action.subscriber,
            };
        default:
            return state;
    }
};
