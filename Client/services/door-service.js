import { HttpTransportType, HubConnectionBuilder } from "@microsoft/signalr";
import axios from 'axios';

const API = "https://localhost:5000";
const connection = new HubConnectionBuilder()
    .withUrl(`${API}/door/hub/`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets
    }).build();

connection.start().then(
    () => console.assert("Door Connection Started")
).catch(e => console.error("Can't connect to Door Service."));

const getStream = () => {
    return connection.stream("GetAsync");
};;
const findStream = (id) => connection.stream("FindAsync", id);
const get = () => axios.get(`API/door`);
const find = (id) => axios.get(`API/door${id}`);


export const doorService = { getStream, findStream, get, find };