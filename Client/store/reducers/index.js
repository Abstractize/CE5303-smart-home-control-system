import { authReducer as auth } from "./auth-reducer";
import { doorReducer as door } from "./door-reducer";

const reducers = {
    auth: auth,
    door: door
};

export default reducers