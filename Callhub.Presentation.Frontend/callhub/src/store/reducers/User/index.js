const INITIAL_STATE = {
  id: "",
  name: "",
  department: {},
  avatar_url: ""
};

export default function user(state = INITIAL_STATE, action) {
  switch (action.type) {
    case "SET_USER":
      return { state: action.user };

    default:
      return state;
  }
}
