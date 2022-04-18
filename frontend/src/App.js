import React from 'react';
import {getTempArray} from "./API/getTempArray";
import {BrowserRouter} from "react-router-dom";
import NavBar from "./components/NavBar";
import AppRouter from "./components/AppRouter";

const App = () => {

  const tempArr = getTempArray();
  console.log(tempArr);
  return (
    <BrowserRouter>
      <NavBar/>
      <AppRouter/>
    </BrowserRouter>
  );
};

export default App;