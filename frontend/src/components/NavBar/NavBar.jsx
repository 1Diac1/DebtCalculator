import React from 'react';
import {Link} from "react-router-dom";
import '../../styles/App.css';
import '../../styles/normalize.css';
import classes from './NavBar.module.css';
import homeImg from '../../img/navbar/category.svg';
import settings from '../../img/navbar/setting-2.svg';
import profileUser from '../../img/navbar/profile-2user.svg';
import taskSquare from '../../img/navbar/task-square.svg';

const NavBar = () => {
  return (
    <div className={classes.NavBarContainter}>
        <ul>
          <li><img src={homeImg} alt={'homeImg'}/><Link to='/home'>Home</Link></li>
          <li><img src={taskSquare} alt={'homeImg'}/><Link to='/debts'>Debts</Link></li>
          <li><img src={profileUser} alt={'homeImg'}/><Link to='/debtors'>Debtors</Link></li>
          <li><img src={settings} alt={'homeImg'}/><Link to='/settings'>Settings</Link></li>
        </ul>
    </div>
  );
};

export default NavBar;