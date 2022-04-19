import React from 'react';
import {getTempArray} from "./API/getTempArray";
import {BrowserRouter} from "react-router-dom";
import NavBar from "./components/NavBar";
import HeaderEmblem from "./components/HeaderEmblem";
import AppRouter from "./components/AppRouter";
import HeaderRightPart from "./components/HeaderRightPart";
import MainBodyDebts from "./components/MainBodyDebts";
import MyProjects from "./components/MyProjects";

const App = () => {

  const tempArr = getTempArray();
  console.log(tempArr);
  return (
      <BrowserRouter>
        <HeaderEmblem/>
        <AppRouter/>
        <HeaderRightPart/>
        <NavBar/>
        <MainBodyDebts/>
        <MyProjects/>
      </BrowserRouter>
  );
};

export default App;