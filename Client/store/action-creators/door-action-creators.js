import { doorService } from '../../services/door-service';
import { DoorActionType } from '../actions/door-actions';

export const actionCreator = {
    getStream: () => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.door) {
            doorService.getStream().subscribe({
                next: (data) => {
                    dispatch({ type: DoorActionType.REQUEST, data: data });
                },
                complete: () => {
                    dispatch({ type: DoorActionType.SUCCESS, data: data });
                },
                error: (err) => {
                    dispatch({ type: DoorActionType.FAILURE, error: err });
                    console.error(err);
                },
            });
        }
    },
    closeStream: () => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.door) {
            doorService.getStream().dispose(item => {
                dispatch({ type: DoorActionType.CLOSE, message: item });
            });
        }
    },
};