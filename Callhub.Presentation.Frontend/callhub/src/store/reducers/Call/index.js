const INITIAL_STATE = {
  selectedCall: null,
  list: [
    {
      id: "",
      title: "",
      lastMessage: "",
    },
  ],
};

export default function call(store = INITIAL_STATE, action) {
  switch (action.type) {
    case "ADD_CALL":
      return { ...store, list: [...store.list, action.payload] };

    case "SET_CALLS":
      return { list: action.payload, selectedCall: null };

    case "SELECT_CALL":
      return {
        ...store,
        selectedCall: store.list.find((x) => x.id == action.payload),
      };

    default:
      return store;
  }
}
