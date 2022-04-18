import React from 'react';
import {Routes, Route, Navigate} from "react-router-dom";
import About from "../pages/About";
import Debts from "../pages/Debts";



const AppRouter = () => {
  return (
    <Routes>
      <Route path={'/about'} element={<About/>}/>
      <Route path={'/debts'} element={<Debts/>}/>
      <Route path={'/*'} element={<Navigate to='/about' replace/>}/>
    </Routes>
  );
};

export default AppRouter;