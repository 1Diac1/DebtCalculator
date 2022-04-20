import React from 'react';
import {Link} from "react-router-dom";
import '../styles/App.css';
import '../styles/normalize.css';
import classes from '../styles/NavBar.module.css';

const NavBar = () => {
  return (
    <div className={classes.NavBarContainter}>
        <ul>
          <li><Link to='/home'>Домашняя</Link></li>
          <li> <Link to='/debts'>Долги</Link></li>
          <li> <Link to='/friends'>Друзья</Link></li>
          <li> <Link to='/settings'>Настройки</Link></li>
        </ul>
    </div>
  );
};

export default NavBar;