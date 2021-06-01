import axios from "axios";

const baseurl = process.env.REACT_APP_API_BASEURL;
const api = axios.create({
  baseURL: `https://${baseurl}`,
});

export default api;
