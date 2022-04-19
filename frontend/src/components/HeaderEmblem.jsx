import React from 'react';
import classes from '../styles/Header.module.css';
import emblem from '../img/Emblem.svg';

const HeaderEmblem = () => {
  return (
    <div className={classes.emblem__container}>
      <img src={emblem} alt='emblem'/>
      DebtCalc.
      <span className={classes.emblem__span}>&#171;</span>
    </div>


  );
};

export default HeaderEmblem;