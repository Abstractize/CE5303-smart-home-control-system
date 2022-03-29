import { AuthActionType } from "../actions/auth-actions";
import { state as initialState} from "../states/auth-state"

export const authReducer = (state = initialState, action) => {
    switch (action.type) {
        case AuthActionType.LOGIN:
            return {
                ...state,
                isLoading: true,
            };
        case AuthActionType.FAILURE:
            return {
                ...state,
                error: action.error,
                isLoading: false
            };
        case AuthActionType.SUCCESS:
            return {
                ...state,
                user: action.user,
                isLoading: false,
                error: null,
            }
        default:
            return state;

    }
};
