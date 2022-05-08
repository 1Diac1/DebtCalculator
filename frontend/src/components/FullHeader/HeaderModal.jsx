import React, {useContext} from 'react';
import classes from './HeaderModal.module.css';
import {AuthContext} from "../../context/context";
import authService from "../../services/authService";

const HeaderModal = ({visible, setVisible}) => {

  const rootClasses = [classes.HeaderModal];
  const {setIsAuth} = useContext(AuthContext);

  const logout = () => {
    setIsAuth(false);
    authService.logout();
  }

  if (visible) {
    rootClasses.push(classes.HeaderModalActive);
  }

  return (
    <div className={rootClasses.join(" ")} onMouseDown={() => setVisible(false)}>
      <div className={classes.HeaderModalWindow}>
        <button
          className={classes.HeaderModalContent}
          onMouseDown={(e) => e.stopPropagation()}
          onClick={logout}
        >Выйти</button>
      </div>
    </div>
  );
};

export default HeaderModal;