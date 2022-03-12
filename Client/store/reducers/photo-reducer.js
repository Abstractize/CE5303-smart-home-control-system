import { PhotoActionType } from "../actions/photo-actions";
import { state as initialState} from "../states/photo-state"

export const photoReducer = (state = initialState, action) => {
    switch (action.type) {
        case PhotoActionType.REQUEST:
            return {
                ...state,
                isLoading: true,
            };
        case PhotoActionType.FAILURE:
            return {
                ...state,
                error: action.error,
                isLoading: false
            };
        case PhotoActionType.SUCCESS:
            return {
                ...state,
                photo: action.photo,
                isLoading: false
            }
        default:
            return state;

    }
};