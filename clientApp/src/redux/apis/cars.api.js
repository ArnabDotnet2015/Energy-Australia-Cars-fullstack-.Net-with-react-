import axios from 'axios';
import config from '../../config';
// const url = `https://localhost:44394/api/CarShow/GetMakeAsync`;
const url = config.apiBaseUrl + 'api/CarShow/GetMakeAsync';


export default class imagesAPI {
    static fetchCars = () => axios.get(url);
}