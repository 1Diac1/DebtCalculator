import React from 'react';
import {request} from "./API/fetchRequest";

const App = () => {

  request();
  return (
    <div>
      Site working;
    </div>
  );
};

export default App;