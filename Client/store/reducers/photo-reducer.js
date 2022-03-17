import { PhotoActionType } from "../actions/photo-actions";
import { state as initialState } from "../states/photo-state"

export const photoReducer = (state = initialState, action) => {
    switch (action.type) {
        case PhotoActionType.REQUEST:
            return {
                ...state,
                isLoading: true,
            };
        case PhotoActionType.REQUEST_PICTURE:
            return {
                ...state,
                isTakingPicture: true,
            }
        case PhotoActionType.REQUEST_VIDEO:
            return {
                ...state,
                isVideoLoading: true,
            }
        case PhotoActionType.FAILURE:
            return {
                ...state,
                error: action.error,
                isLoading: false,
            };
        case PhotoActionType.SUCCESS:
            return {
                ...state,
                photo: action.photo,
                isLoading: false,
            }
        case PhotoActionType.SUCCESS_PICTURE:
            return {
                ...state,
                isTakingPicture: false,
            }
        case PhotoActionType.SUCCESS_VIDEO:
            return {
                ...state,
                video: action.video,
                isVideoLoading: false,
            }
        default:
            return state;

    }
};