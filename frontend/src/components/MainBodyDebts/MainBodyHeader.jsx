import React from 'react';
import classes from "./MainBodyDebts.module.css";
import pencil from "../../img/pencil.svg";
import link from "../../img/Group 626.svg";

const MainBodyHeader = ({setVisible, debtText}) => {
  return (
    <div className={classes.debtGroup}>
      <div className={classes.debtGroupName}>
        {debtText}
      </div>
      <div className={classes.debtGroupImage}>
        <img
          src={pencil} alt={pencil}
          onClick={() => setVisible(true)}
        />
      </div>
      <div className={classes.debtGroupImage}>
        <img src={link} alt={link}/>
      </div>
    </div>
  );
};

export default MainBodyHeader;