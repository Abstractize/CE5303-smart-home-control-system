import { HttpTransportType, HubConnectionBuilder } from '@microsoft/signalr';
import axios from 'axios';
import { API_URL } from '@env';

const startConnection = () => new HubConnectionBuilder()
    .withUrl(`${API_URL}light/hub/`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets
    }).build();
const getStream = (connection) => connection.stream("Get");
const findStream = (connection, id) => connection.stream("Find", id);
const get = () => axios.get(`${API_URL}light`);
const find = (id) => axios.get(`${API_URL}light${id}`);
const update = (id, value) => axios.put(`${API_URL}light/${id}`, value)

export const lightService = { startConnection, getStream, findStream, get, find, update };