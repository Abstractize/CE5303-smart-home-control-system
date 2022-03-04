import { AuthActionType } from "../action-types/auth-action-types";
import { Auth } from "../states/auth-state"

export const authReducer = (state = new Auth(), action) => {
    switch (action.type) {
        case AuthActionType.LOGIN:
            return {
                isLoading: true,
                user: state.user,
                error: state.error
            };
        case AuthActionType.FAILURE:
            return {
                error: action.error,
                user: state.user,
                isLoading: false
            };
        case AuthActionType.SUCCESS:
            return {
                user: action.user,
                error: state.error,
                isLoading: false
            }
        default:
            return state;

    }
};
