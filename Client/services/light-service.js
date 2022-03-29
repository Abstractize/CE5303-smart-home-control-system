import { HttpTransportType, HubConnectionBuilder } from '@microsoft/signalr';
import axios from 'axios';
import { API_URL } from '../constants';

const startConnection = () => new HubConnectionBuilder()
    .withUrl(`${API_URL}light/hub/`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets
    }).build();
const getStream = (connection) => connection.stream("Get");
const findStream = (connection, id) => connection.stream("Find", id);
const get = () => axios.get(`light`);
const find = (id) => axios.get(`light${id}`);
const update = (id, value) => axios.put(`light/${id}`, value)

export const lightService = { startConnection, getStream, findStream, get, find, update };