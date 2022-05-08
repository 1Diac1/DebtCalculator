import React, {useState} from 'react';
import classes from './DebtGroups.module.css';
import addSquare from '../../img/navbar/add-square.svg';
import DebtModal from "./DebtModal";
import DbtGroup from "./DbtGroup";
import {useDispatch, useSelector} from "react-redux";
import {changeDebtGroupAction} from "../../store/debtGroupsReducer";

const DebtGroups = () => {

  const dispatch = useDispatch();
  const debtGroupArrRedux = useSelector(state => state.debtGroups);

  const [debtGroup, setDebtGroup] = useState(debtGroupArrRedux);
  const [visible, setVisible] = useState(false);

  const [currentGroup, setCurrentGroup] = useState(1);

  const changeGroup = async (groupId) => {
    setCurrentGroup(groupId);
    dispatch(changeDebtGroupAction(groupId));
  }

  return (
    <div className={classes.debtGroupsContainter}>
        <div className={classes.nameAndModal}>
          <span>MY DEBT GROUPS</span>
          <img src={addSquare} alt="button" onClick={() => setVisible(true)}/>
        </div>
        <DebtModal
          visible={visible}
          setVisible={setVisible}
          debtGroup={debtGroup}
          setDebtGroup={setDebtGroup}
        />
      <ul>
        {debtGroup.map(dbtGrp =>
          <DbtGroup
            key={dbtGrp.id}
            dbtGrp={dbtGrp}
            changeGroup={changeGroup}
            currentGroup={currentGroup}
          />
        )}
      </ul>
    </div>
  );
};

export default DebtGroups;