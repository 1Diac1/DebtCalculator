import {debtGroupsReducer} from "./debtGroupsReducer";
import {applyMiddleware, createStore} from "redux";
import {composeWithDevTools} from "redux-devtools-extension";
import thunk from "redux-thunk";

export const store = createStore(debtGroupsReducer,
  composeWithDevTools(applyMiddleware(thunk)));


