import React from 'react';

const App = () => {

  let arr = [{Name: 'BOB'}];
  console.log(arr);
  return (
    <div>
      {arr[0].Name}
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