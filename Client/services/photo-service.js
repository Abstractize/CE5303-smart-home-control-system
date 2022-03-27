import axios from 'axios';
import https from 'https';
import { API_URL } from '../constants/';

const httpsAgent = new https.Agent({ rejectUnauthorized: false });
const instance = axios.create({ httpsAgent });
instance.defaults.baseURL = API_URL;

const find = (id) =>
    (`${API_URL}photo/${id}`);

const get = () =>
    instance.get(`photo/`);

const add = () =>
    instance.post(`photo/`);

const getStreamUrl = () =>
    instance.get(`video/`);
export const photoService = { find, get, add, getStreamUrl };