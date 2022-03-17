import axios from 'axios';
import { API_URL } from '@env';
import https from 'https';

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