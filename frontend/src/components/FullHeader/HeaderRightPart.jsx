import React, {useEffect, useMemo, useState} from 'react';
import classes from './Header.module.css';
import searchNormal from '../../img/search-normal.svg';
import calendar from '../../img/calendar-2.svg';
import messageQuestion from '../../img/message-question.svg';
import notification from '../../img/notification.svg';
import profilePic from '../../img/profilePic.svg';
import arrowDown from '../../img/arrow-down.svg';
import HeaderModal from "./HeaderModal";
import authService from "../../services/authService";
import jwtDecode from "jwt-decode";

const HeaderRightPart = () => {

  const user = useMemo(() => {
    return jwtDecode(authService.getCurrentUser());
  }, []);

  const [visible, setVisible] = useState(false);

  return (
    <div className={classes.search__profile__containter}>
      <div className={classes.search}>
        <input type="text" placeholder="Search for anything..."/>
        <img src={searchNormal} alt="search-normal" className={classes.search__icon}/>
      </div>

      <div className={classes.profileContainer}>
        <div className={classes.pictureContainter}>
          <img src={calendar} alt="calendar"/>
          <img src={messageQuestion} alt="messageQuestion"/>
          <img src={notification} alt="notification"/>
        </div>
        <div className={classes.nameAndCountry}>
          <div className={classes.name}>{user.firstName + " " + user.lastName}</div>
          <div className={classes.country}>{user.userName}</div>
        </div>
        <div className={classes.avatarContainer}>
          <img src={profilePic} alt="profilePic" className={classes.profPic}/>
          <img
            src={arrowDown} alt="arrowDown"
            className={classes.arrowDown}
            onClick={() => setVisible(true)}
          />
          <HeaderModal
            visible={visible}
            setVisible={setVisible}
          />
        </div>
      </div>
    </div>
  );
};

export default HeaderRightPart;