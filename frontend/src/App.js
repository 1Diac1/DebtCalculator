import React from 'react';
import {getArr} from "./API/getArray";

const App = () => {

  getArr();
  console.log('11');
  return (
    <div>
      <div>
        Site working.
      </div>
      <div>
        Still working, I just need commit.
      </div>
    </div>
  );
};

export default App;