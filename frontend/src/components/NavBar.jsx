import React from 'react';
import {Link} from "react-router-dom";
import '../styles/App.css';
import '../styles/normalize.css';

const NavBar = () => {
  return (
    <div className="navbar">
      <button>Выйти</button>
      <div className="navbar__links">
        <Link to='/about'>О сайте</Link>
        <Link to='/debts'>Долги</Link>
      </div>
    </div>
  );
};

export default NavBar;