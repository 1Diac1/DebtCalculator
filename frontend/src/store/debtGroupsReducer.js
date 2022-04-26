const defaultState = {
  debtGroups: [
      {id: 1, color: '#7AC555', text: "Colleagues debts"},
      {id: 2, color: '#FFA500', text: "Friends debts"},
      {id: 3, color: '#E4CCFD', text: "Family debts"}
  ],
  id: 1
};


const ADD_GROUP = "ADD_GROUP";
const CHANGE_GROUP = "CHANGE_GROUP";

export const debtGroupsReducer = (state = defaultState, action) => {
  switch (action.type) {
    case  CHANGE_GROUP:
      return {...state, id: action.payload};
    case  ADD_GROUP:
      return {...state, debtGroups: [...state.debtGroups, action.payload]};
    default:
      return state;
  }
}

export const changeDebtGroupAction = (payload) => ({type: CHANGE_GROUP, payload: payload});
export const addDebtGroupAction = (payload) => ({type: ADD_GROUP, payload: payload});