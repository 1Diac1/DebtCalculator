import React, {useState} from 'react';
import classes from './DebtGroups.module.css';

const DbtGroup = ({dbtGrp, changeGroup, currentGroup}) => {

  const styleforLi = [classes.liElem, classes.liElemActive];

  return (
    <li
      className={currentGroup === dbtGrp.id ? styleforLi.join(" ") : classes.liElem}
      onClick={() => changeGroup(dbtGrp.id)}
    >
      <span style={{color: dbtGrp.color, fontSize: "20px"}}>•</span>
      {dbtGrp.text}
    </li>
  );
};

export default DbtGroup;