import { authReducer as auth } from './auth-reducer';
import { doorReducer as door } from './door-reducer';
import { photoReducer as photo } from './photo-reducer';
import { lightReducer as light } from './light-reducer';
const reducers = {
    auth: auth,
    door: door,
    photo: photo,
    light: light,
};

export default reducers