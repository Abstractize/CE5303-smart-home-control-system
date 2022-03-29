import { doorService } from "../../services/door-service";
import { DoorActionType } from "../actions/door-actions";

export const actionCreator = {
  connect: () => async (dispatch, getState) => {
    const appState = getState();
    if (
      appState &&
      appState.door &&
      appState.door.subscriber === null
    ) {
      const connection = doorService.startConnection();
      connection
        .start()
        .then(() => {
          dispatch({ type: DoorActionType.CONNECT, connection: connection });
        })
        .catch((err) => {
          dispatch({ type: DoorActionType.FAILURE, error: err });
        });
    }
  },
  getStream: () => async (dispatch, getState) => {
    const appState = getState();

    if (appState && appState.door && appState.door.connection) {
      const subscriber = doorService
        .getStream(appState.door.connection)
        .subscribe({
          next: (data) => {
            dispatch({
              type: DoorActionType.REQUEST,
              data: data,
              subscriber: subscriber,
            });
          },
          complete: (item) => {
            dispatch({ type: DoorActionType.CLOSE, message: item });
          },
          error: (err) => {
            dispatch({ type: DoorActionType.FAILURE, error: err });
          },
        });
    }
  },
  disconnect: () => async (dispatch, getState) => {
    const appState = getState();

    if (
      appState &&
      appState.door &&
      appState.door.subscriber &&
      appState.door.connection
    ) {
      appState.door.connection
        .stop((item) => {
          appState.door.subscriber.dispose();
          dispatch({
            type: DoorActionType.CLOSE,
            message: item,
            subscriber: null,
          });
        })
        .catch((err) => {
          dispatch({ type: DoorActionType.FAILURE, error: err });
        });
    }
  },
};
