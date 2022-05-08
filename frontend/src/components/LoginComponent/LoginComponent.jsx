import React, {useContext, useState} from 'react';
import {AuthContext} from "../../context/context";
import classes from "./LoginComponent.module.css";
import {Link} from "react-router-dom";
import authService from "../../services/authService";

const LoginComponent = () => {

  const {setIsAuth} = useContext(AuthContext);

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const login = async (e) => {
    e.preventDefault();
    if (!email || !password) {
      return console.log('Email or Password empty');
    }
    const responseData = await authService.login(email, password);
    setIsAuth(true);
  }

  return (
    <div className={classes.loginPageClass}>
      <form className={classes.loginForm}>
        <div className={classes.welcomeLogin}>Welcome</div>
        <input
          type="text"
          value={email}
          onChange={(event) => setEmail(event.target.value)}
          placeholder="Email"
        />
        <input
          type="password"
          value={password}
          onChange={(event) => setPassword(event.target.value)}
          placeholder="Password"
        />
        <button
          className={classes.submitButton}
          onClick={login}
        >LOGIN</button>
        <div className={classes.signUpCaption}>Don't have an Account? <Link to='/signup'>Sign Up!</Link>
        </div>
      </form>
    </div>
  );
};

export default LoginComponent;