import { HttpTransportType, HubConnectionBuilder } from "@microsoft/signalr";
import axios from 'axios';
import { DoorActionType } from '../store/actions/door-actions';

const API = "https://localhost:5000";
const connection = new HubConnectionBuilder()
    .withUrl(`${API}/door/hub/`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets
    }).build();

connection
    .start()
    .then()
    .catch();

const startGet = () =>
    axios.get(`${API}/door/`);

const listenGet = async (dispatch) =>
    connection.on("GetAsync", (data) => {
        dispatch({ type: DoorActionType.REQUEST, data: data })
    });

const startFind = (id) =>
    axios.get(`${API}/door/${id}`);

const listenFind = async (dispatch) =>
    connection.on("FindAsync", (data) => {
        //dispatch({ type: DoorActionType.REQUEST, data: [] })
    });

export const doorService = { listenFind, startFind, listenGet, startGet };