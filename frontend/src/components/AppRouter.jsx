import React, {useContext} from 'react';
import {Routes, Route, Navigate} from "react-router-dom";
import {AuthContext} from "../context/context";
import {privateRoutes, publicRoutes} from "../routs/routs";


const AppRouter = () => {

  const {isAuth} = useContext(AuthContext);

  return (
    isAuth ?
      <Routes>
        {privateRoutes.map(rout =>
          <Route
            path={rout.path}
            element={<rout.element/>}
            key={rout.path}
          />
        )}
        <Route path='/*' element={<Navigate to='/home' replace/>}/>
      </Routes>
      :
      <Routes>
        {publicRoutes.map(rout =>
          <Route
            path={rout.path}
            element={<rout.element/>}
            key={rout.path}
          />
        )}
        <Route path='/*' element={<Navigate to='/login' replace/>}/>
      </Routes>
  );
};

export default AppRouter;