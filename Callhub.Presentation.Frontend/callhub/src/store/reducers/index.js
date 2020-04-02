import { combineReducers } from "redux";

import company from "./Company";
import user from "./User";

export default combineReducers({
  company,
  user
});
