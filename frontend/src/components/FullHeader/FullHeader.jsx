import React from 'react';
import HeaderEmblem from "./HeaderEmblem";
import HeaderRightPart from "./HeaderRightPart";

const FullHeader = () => {
  return (
    <div className='fullHeader'>
      <HeaderEmblem/>
      <HeaderRightPart/>
    </div>
  );
};

export default FullHeader;