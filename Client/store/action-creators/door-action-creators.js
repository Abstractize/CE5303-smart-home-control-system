import { doorService } from '../../services/door-service';
import { DoorActionType } from '../actions/door-actions';

export const actionCreator = {
    start: () => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.door)
            doorService.startGet().then(() =>
                dispatch({ type: DoorActionType.REQUEST, data: [] })
            ).catch(e => {
                dispatch({ type: DoorActionType.FAILURE, error: e })
                console.error(e);
            })

    },
    get: () => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.door) {
            doorService.listenGet(dispatch)
                .then()
                .catch(e => {
                    dispatch({ type: DoorActionType.FAILURE, error: e })
                    console.error(e);
                });
        }
    }
};