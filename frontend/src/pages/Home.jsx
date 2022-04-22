import React from 'react';
import NavBar from "../components/NavBar";
import MainBodyDebts from "../components/MainBodyDebts";
import DebtGroups from "../components/DebtGroups";
import '../styles/App.css';
import FullHeader from "../components/FullHeader";


const Home = () => {
  return (
    <div id='home'>
      <FullHeader/>
      <NavBar/>
      <MainBodyDebts/>
      <DebtGroups/>
    </div>
  );
};

export default Home;