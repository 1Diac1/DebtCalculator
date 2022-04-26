import React from 'react';
import classes from "./MainBodyDebts.module.css";

const MainBodyDebtPost = ({elem, index}) => {
  return (
    <div key={index}>
      <div className={classes.debtElem}>
        <div className={classes.debtHeader}>
          {elem.name} - {elem.amount}
        </div>
        <div className={classes.debtDescription}>
          {elem.description}
          <span>{elem.created}</span>
        </div>
      </div>
    </div>
  );
};

export default MainBodyDebtPost;