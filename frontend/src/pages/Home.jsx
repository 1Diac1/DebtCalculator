import React from 'react';
import NavBar from "../components/NavBar";
import MainBodyDebts from "../components/MainBodyDebts";
import MyProjects from "../components/MyProjects";
import '../styles/App.css';
import FullHeader from "../components/FullHeader";


const Home = () => {
  return (
    <div id='home'>
      <FullHeader/>
      <NavBar/>
      <MainBodyDebts/>
      <MyProjects/>
    </div>
  );
};

export default Home;