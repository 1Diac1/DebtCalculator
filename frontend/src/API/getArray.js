import axios from "axios";

export const getArr = async () => {
  const response = await axios.get("http://localhost:5000/api/Debt/get-all");
  console.log(response.data);
}