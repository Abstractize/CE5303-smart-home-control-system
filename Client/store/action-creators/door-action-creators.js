import { doorService } from '../../services/door-service';
import { DoorActionType } from '../actions/door-actions';

export const actionCreator = {
    connect: () => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.door) {
            const connection = doorService.startConnection();
            connection.start().then(
                () => {
                    dispatch({ type: DoorActionType.CONNECT, connection: connection });
                }).catch((err) => {
                    dispatch({ type: DoorActionType.FAILURE, error: err });
                });
        }
    },
    getStream: () => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.door && appState.door.connection) {
            doorService.getStream(appState.door.connection).subscribe({
                next: (data) => {
                    console.log(data);
                    dispatch({ type: DoorActionType.REQUEST, data: data });
                },
                complete: () => {
                    console.log('COMPLETED');
                    dispatch({ type: DoorActionType.SUCCESS, data: data });
                },
                error: (err) => {
                    dispatch({ type: DoorActionType.FAILURE, error: err });
                    console.error(err);
                },
            });
        }
    },
    disconnect: () => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.door && appState.door.connection) {
            doorService.getStream(appState.door.connection).dispose(item => {
                dispatch({ type: DoorActionType.CLOSE, message: item });
            });
        }
    },
};