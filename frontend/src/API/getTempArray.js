

export const getTempArray = () => {

  let today = new Date();

  var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();
  const tempArr = [
    {
      name: "Задолженность 1",
      description: "Описание долга 1",
      amount: 1200,
      created: date,
      userId: 1,
      credtiorId: 2
    }, {
      name: "Задолженность 2",
      description: "Описание долга 2",
      amount: 2330,
      created: date,
      userId: 1,
      credtiorId: 2
    }, {
      name: "Задолженность 3",
      description: "Описание долга 3",
      amount: 14400,
      created: date,
      userId: 1,
      credtiorId: 2
    },
  ];
  return tempArr;
}