import React, {useEffect, useState} from 'react';
import {BrowserRouter} from "react-router-dom";
import AppRouter from "./components/AppRouter";
import {AuthContext} from "./context/context";
import Cookies from "js-cookie";

const App = () => {

  const [isAuth, setIsAuth] = useState(false);

  useEffect(() => {
    if (Cookies.get('user')) {
      setIsAuth(true);
    }
    //setIsLoading(false);
  }, []);

  return (
    <AuthContext.Provider value={{
      isAuth,
      setIsAuth
    }}>
      <BrowserRouter>
        <AppRouter/>
      </BrowserRouter>
    </AuthContext.Provider>
  );
};

export default App;