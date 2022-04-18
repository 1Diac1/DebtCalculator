import React from 'react';
import {Link} from "react-router-dom";

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