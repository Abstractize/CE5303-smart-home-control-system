import { photoService } from '../../services/photo-service';
import { PhotoActionType } from '../actions/photo-actions';

export const actionCreator = {
    getPhotos: () => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.photo) {
            photoService.get().then(response =>
                response.data)
                .then(data => {
                    dispatch({ type: PhotoActionType.SUCCESS, photo: data.map((photo) => (
                        {...photo, url: photoService.find(photo.id)}
                    )) });
                }).catch(e =>{
                    dispatch({ type: PhotoActionType.FAILURE, error: e })
                });

            dispatch({ type: PhotoActionType.REQUEST });
        }
    }
};