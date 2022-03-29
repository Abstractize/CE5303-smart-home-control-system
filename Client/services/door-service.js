import { HttpTransportType, HubConnectionBuilder } from '@microsoft/signalr';
import axios from 'axios';
import { API_URL } from '../constants';

const startConnection = () => new HubConnectionBuilder()
    .withUrl(`${API_URL}door/hub/`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets
    }).build();

const getStream = (connection) => connection.stream("Get");
const findStream = (connection, id) => connection.stream("Find", id);
const disconnect = (connection) => connection.stop();
const get = () => axios.get(`door`);
const find = (id) => axios.get(`door/${id}`);

export const doorService = { startConnection, getStream, findStream, get, find, disconnect };