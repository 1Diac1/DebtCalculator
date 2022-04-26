import React from 'react';
import classes from './Header.module.css';
import emblem from '../../img/Emblem.svg';

const HeaderEmblem = () => {
  return (
    <div className={classes.emblem__container}>
      <img draggable={"false"} src={emblem} alt='emblem' onClick={() => {console.log("Hlloe")}}/>
      DebtCalc.
      <span className={classes.emblem__span}>&#171;</span>
    </div>
  );
};

export default HeaderEmblem;