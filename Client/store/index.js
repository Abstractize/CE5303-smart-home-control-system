import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import reducers from './reducers';
import { state } from './states';

export default function configureStore(initialState = state) {
    const middleware = [
        thunk,
    ];

    const rootReducer = combineReducers({
        ...reducers,
    });

    const enhancers = [];

    return createStore(
        rootReducer,
        initialState,
        compose(applyMiddleware(...middleware), ...enhancers)
    );
}