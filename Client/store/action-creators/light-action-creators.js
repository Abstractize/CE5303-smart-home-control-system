import { lightService } from "../../services/light-service";
import { LightActionType } from "../actions/light-actions";

export const actionCreator = {
  connect: () => async (dispatch, getState) => {
    const appState = getState();
    if (
      appState &&
      appState.light &&
      appState.light.connection === null &&
      appState.light.subscriber === null
    ) {
      const connection = lightService.startConnection();
      connection
        .start()
        .then(() => {
          dispatch({ type: LightActionType.CONNECT, connection: connection });
        })
        .catch((err) => {
          dispatch({ type: LightActionType.FAILURE, error: err });
        });
    }
  },
  switchLight: (id, value) => async (dispatch, getState) => {
    const appState = getState();

    if (appState && appState.light) {
      lightService
        .update(id, value)
        .then((response) => response.data)
        .catch((err) =>
          dispatch({
            type: LightActionType.FAILURE,
            error: err,
          })
        );
    }
  },
  getStream: () => async (dispatch, getState) => {
    const appState = getState();

    if (appState && appState.light && appState.light.connection) {
      const subscriber = lightService
        .getStream(appState.light.connection)
        .subscribe({
          next: (data) => {
            dispatch({
              type: LightActionType.REQUEST,
              data: data,
              subscriber: subscriber,
            });
          },
          complete: (item) => {
            dispatch({ type: LightActionType.CLOSE, message: item });
          },
          error: (err) => {
            dispatch({ type: LightActionType.FAILURE, error: err });
          },
        });
    }
  },
  disconnect: () => async (dispatch, getState) => {
    const appState = getState();

    if (
      appState &&
      appState.light &&
      appState.light.subscriber &&
      appState.light.connection
    ) {
      appState.light.connection
        .stop((item) => {
          appState.light.subscriber.dispose();
          dispatch({
            type: LightActionType.CLOSE,
            message: item,
            subscriber: null,
          });
          console.log(item);
        })
        .catch((err) => {
          dispatch({ type: LightActionType.FAILURE, error: err });
        });
    }
  },
};
