const INITIAL_STATE = {
  id: "",
  name: "",
  department: {},
  avatar_url: "",
  token: {},
  company: {},
};

export default function user(state = INITIAL_STATE, action) {
  switch (action.type) {
    case "SET_USER":
      return { state: action.payload };

    case "SET_USERCOMPANY":
      return { ...state, company: action.payload };

    case "SET_USERTOKEN":
      return { ...state, token: action.payload };

    default:
      return state;
  }
}
