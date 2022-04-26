import React from 'react';
import NavBar from "../components/NavBar/NavBar";
import MainBodyDebts from "../components/MainBodyDebts/MainBodyDebts";
import DebtGroups from "../components/DebtGroups/DebtGroups";
import '../styles/App.css';
import FullHeader from "../components/FullHeader/FullHeader";


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