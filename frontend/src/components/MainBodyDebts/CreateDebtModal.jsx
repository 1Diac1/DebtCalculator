import React, {useState} from 'react';
import MyModal from "../../UI/MyModal";
import classes from './MainBodyDebts.module.css';


const CreateDebtModal = ({visible, setVisible, arrOfDebts, setArrOfDebts}) => {

  const [debtValue, setDebtValue] = useState({name: "", description: "", amount: 0});
  let today = new Date();

  let date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();

  const addDebt = () => {
    if (debtValue.name.trim().length !== 0 && debtValue.description.trim().length !== 0) {
      const group = {
        name: debtValue.name,
        description: debtValue.description,
        amount: debtValue.amount,
        created: date,
        userId: 1,
        credtiorId: 2
      };
      setArrOfDebts([...arrOfDebts, group]);
      setDebtValue({name: "", description: "", amount: 0});
      setVisible(false);
    }
  }

    return (
      <MyModal
        visible={visible}
        setVisible={setVisible}
      >
        <div className={classes.ModalDiv}>
          <input
            type="text"
            placeholder="Debt name"
            value={debtValue.name}
            onChange={event => setDebtValue({...debtValue, name: event.target.value})}
          />
          <input
            type="text"
            placeholder="Debt description"
            value={debtValue.description}
            onChange={event => setDebtValue({...debtValue, description: event.target.value})}
          />
          <input
            type="text"
            placeholder="Amount"
            value={debtValue.amount}
            onChange={event => setDebtValue({...debtValue, amount: +event.target.value})}
          />
          <button onClick={addDebt}>Add</button>
        </div>
      </MyModal>
    );
}
export default CreateDebtModal;