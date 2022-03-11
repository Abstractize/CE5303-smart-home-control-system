import { HttpTransportType, HubConnectionBuilder } from "@microsoft/signalr";
import axios from 'axios';

const API = "https://localhost:5000";

const startConnection = () => new HubConnectionBuilder()
    .withUrl(`${API}/door/hub/`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets
    }).build();
const getStream = (connection) => connection.stream("Get");
const findStream = (connection, id) => connection.stream("Find", id);
const get = () => axios.get(`API/door`);
const find = (id) => axios.get(`API/door${id}`);

export const doorService = { startConnection, getStream, findStream, get, find };