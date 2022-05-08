import axios from "axios";
import Cookies from "js-cookie";

const signUp = (email, password, userName, firstName, lastName) => {
  return axios
    .post('http://localhost:5000/api/v1/auth/signup', {
      email,
      password,
      userName,
      firstName,
      lastName
    })
    .then((response) => {
      console.log(response.data)
      //response.data.accessToken
      if (response.data.token) {
        Cookies.set('user', JSON.stringify(response.data));
      }

      return response.data;
    })
};

const login = (email, password) => {
  return axios
    .post('http://localhost:5000/api/v1/auth/login', {
      email,
      password,
    })
    .then((response) => {
      if (response.data.token) {
        //response.data.accessToken
        Cookies.set('user', JSON.stringify(response.data));
      }

      return response.data;
    })
};

const logout = () => {
  Cookies.remove('user');
};

const getCurrentUser = () => {
  return Cookies.get('user');
};

const authService = {
  signUp,
  login,
  logout,
  getCurrentUser
};

export default authService;