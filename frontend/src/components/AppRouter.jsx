import React from 'react';
import {Routes, Route, Navigate} from "react-router-dom";
import Home from "../pages/Home";
import Debts from "../pages/Debts";



const AppRouter = () => {
  return (
    <div className="AppRouter">
      <Routes>
        <Route path={'/home'} element={<Home/>}/>
        <Route path={'/debts'} element={<Debts/>}/>
        <Route path={'/*'} element={<Navigate to='/home' replace/>}/>
      </Routes>
    </div>
  );
};

export default AppRouter;