import React, {useState} from 'react';
import classes from "../LoginComponent/LoginComponent.module.css";
import {Link} from "react-router-dom";
import authService from "../../services/authService";

const SignUpComponent = () => {

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [names, setNames] = useState({firstName: "", lastName: "", userName: ""})

  const signUp = async (e) => {
    e.preventDefault();
    if (!email || !password) {
      return console.log('Email or Password empty');
    }
    if (password !== confirmPassword) {
      return console.log("Passwords doesn't match!");
    }
    const responseData = await authService.signUp(email, password, names.userName, names.firstName, names.lastName);
    console.log(responseData);
    console.log('Signed');
  }

  return (
    <div className={classes.loginPageClass}>
      <form className={classes.loginForm}>
        <div className={classes.welcomeSignUp}>Welcome</div>
        <div className={classes.firstAndLastNames}>
          <input //FirstName
            type="text"
            value={names.firstName}
            onChange={(event) => setNames({...names, firstName: event.target.value})}
            placeholder="First Name"
          />
          <input //LastName
            type="text"
            value={names.lastName}
            onChange={(event) => setNames({...names, lastName: event.target.value})}
            placeholder="Last Name"
          />
        </div>
        <input //UserName
          type="text"
          value={names.userName}
          onChange={(event) => setNames({...names, userName: event.target.value})}
          placeholder="Username"
        />
        <input //Email
          type="text"
          value={email}
          onChange={(event) => setEmail(event.target.value)}
          placeholder="Email"
        />
        <input //Password
          type="password"
          value={password}
          onChange={(event) => setPassword(event.target.value)}
          placeholder="Password"
        />
        <input //Confirmation of password
          type="password"
          value={confirmPassword}
          onChange={(event) => setConfirmPassword(event.target.value)}
          placeholder="Confirm password"
        />
        <button
          className={classes.submitButton}
          onClick={signUp}
        >SIGN UP</button>
        <div
          className={classes.signUpCaption}>Already have an Account? <Link to='/login'>Login</Link>
        </div>
      </form>
    </div>
  );
};

export default SignUpComponent;