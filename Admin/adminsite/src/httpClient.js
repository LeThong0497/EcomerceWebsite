import axios from "axios";

axios.interceptors.response.use( data => {
  console.log(data.data);
})
const instance = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
});

export default instance;