export const addCall = (call) => ({
  type: "ADD_CALL",
  payload: call,
});

export const selectCall = (id) => ({
  type: "SELECT_CALL",
  payload: id,
});

export const setCalls = (calls) => ({
  type: "SET_CALLS",
  payload: calls,
});

export const setNewCallData = (data) => ({
  type: "SET_NEWCALL_DATA",
  payload: data,
});

export const setNewCallPriority = (priority) => {
  return {
    type: "SET_NEWCALL_PRIORITY",
    payload: priority,
  };
};

export const setNewCallAttachs = (attachs) => {
  return {
    type: "SET_NEWCALL_ATTACHS",
    payload: attachs,
  };
};
