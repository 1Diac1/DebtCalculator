import React, {useState} from 'react';
import {colorGenerator} from "../../functions/colorGenerator";
import MyModal from "../../UI/MyModal";
import {useDispatch} from "react-redux";
import {addDebtGroupAction} from "../../store/debtGroupsReducer";

const DebtModal = ({visible, setVisible, debtGroup, setDebtGroup}) => {

  const [inputValue, setInputValue] = useState("");

  const dispatch = useDispatch();

  const addDebtGroup = () => {
    if (inputValue.trim().length !== 0) {
      const group = {color: colorGenerator(), text: inputValue, id: debtGroup.length + 1};
      setDebtGroup([...debtGroup, group]);
      setInputValue("");
      setVisible(false);
      dispatch(addDebtGroupAction(group));
    }
  }

  return (
    <MyModal
      visible={visible}
      setVisible={setVisible}
    >
      <input
        type="text"
        placeholder="Value"
        value={inputValue}
        onChange={event => setInputValue(event.target.value)}
      />
      <button onClick={addDebtGroup}>Add</button>
    </MyModal>
  );
};

export default DebtModal;