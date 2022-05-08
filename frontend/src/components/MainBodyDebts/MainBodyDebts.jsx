import React, {useState} from 'react';
import classes from './MainBodyDebts.module.css';
import {useSelector} from "react-redux";
import {getTempArray} from "../../API/getTempArray";
import CreateDebtModal from "./CreateDebtModal";
import MainBodyHeader from "./MainBodyHeader";
import MainBodyDebtPost from "./MainBodyDebtPost";


const MainBodyDebts = () => {

  const debtGroupID = useSelector(state => state.id);
  const debtArray = useSelector(state => state.debtGroups);
  const debtText = debtArray[debtGroupID - 1].text;

  const [arrOfDebts, setArrOfDebts] = useState(getTempArray());

  const [visible, setVisible] = useState(false);

  return (
    <div className={classes.mainBodyContainer}>
        <MainBodyHeader
          setVisible={setVisible}
          debtText={debtText}
        />
        <CreateDebtModal
          visible={visible}
          setVisible={setVisible}
          arrOfDebts={arrOfDebts}
          setArrOfDebts={setArrOfDebts}
        />
      <div className={classes.debtsList}>
        {arrOfDebts.map((elem, index) =>
          <MainBodyDebtPost
            key={index}
            elem={elem}
            index={index}
          />
        )}
      </div>
    </div>
  );
};

export default MainBodyDebts;