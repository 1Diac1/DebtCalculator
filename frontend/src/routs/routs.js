import Login from "../pages/Login";
import Home from "../pages/Home";
import Debts from "../pages/Debts";
import SignUp from "../pages/SignUp";


export const privateRoutes = [
  {path: '/home', element: Home},
  {path: '/debts', element: Debts},
];

export const publicRoutes = [
  {path: '/login', element: Login},
  {path: '/signup', element: SignUp}
];