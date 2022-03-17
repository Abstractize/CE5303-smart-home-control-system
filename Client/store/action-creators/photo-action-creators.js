import { photoService } from '../../services/photo-service';
import { PhotoActionType } from '../actions/photo-actions';

export const actionCreator = {
    getPhotos: () => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.photo) {
            photoService.get().then(response =>
                response.data)
                .then(data => {
                    console.table(data);
                    dispatch({ type: PhotoActionType.SUCCESS, photo: data.map((photo) => (
                        {...photo, url: photoService.find(photo.id)}
                    )) });
                }).catch(e =>{
                    dispatch({ type: PhotoActionType.FAILURE, error: e })
                });

            dispatch({ type: PhotoActionType.REQUEST });
        }
    },
    addPhoto: () => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.photo) {
            photoService.add().then(response =>
                response.data)
                .then(() => {
                    dispatch({ type: PhotoActionType.SUCCESS_PICTURE })
                }).catch(e =>{
                    dispatch({ type: PhotoActionType.FAILURE, error: e })
                });
            dispatch({ type: PhotoActionType.REQUEST_PICTURE });
        }
    },
    getStreamUrl: () => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.photo) {
            photoService.getStreamUrl().then(response =>
                response.data)
                .then(data => {
                    dispatch({ type: PhotoActionType.SUCCESS_VIDEO, video: data })
                }).catch(e =>{
                    dispatch({ type: PhotoActionType.FAILURE, error: e })
                });
            dispatch({ type: PhotoActionType.REQUEST_VIDEO });
        }
    },
};