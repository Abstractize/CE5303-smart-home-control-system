import { authService } from '../../services/auth-service';
import { AuthActionType } from '../actions/auth-actions';

export const actionCreator = {
    login: (loginValue, navigation) => async (dispatch, getState) => {
        const appState = getState();

        if (appState && appState.auth) {
            authService.add(loginValue).then(response =>
                response.data)
                .then(data => {
                    dispatch({ type: AuthActionType.SUCCESS, user: data });
                    navigation.navigate("Home");
                }).catch(e =>{
                    dispatch({ type: AuthActionType.FAILURE, error: e })
                    console.error(e);
                });

            dispatch({ type: AuthActionType.LOGIN });
        }
    }
};
