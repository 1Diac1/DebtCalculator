import React from 'react';
import {getTempArray} from "./API/getTempArray";
import {BrowserRouter} from "react-router-dom";
import AppRouter from "./components/AppRouter";

const App = () => {

  const tempArr = getTempArray();
  console.log(tempArr);
  return (
      <BrowserRouter>
        <AppRouter/>
      </BrowserRouter>
  );
};

export default App;