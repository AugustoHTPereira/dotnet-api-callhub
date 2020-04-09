export const addCall = (call) => ({
  type: "ADD_CALL",
  payload: call,
});


export const selectCall = (id) => ({
  type: "SELECT_CALL",
  payload: id
})

export const setCalls = (calls) => ({
  type: "SET_CALLS",
  payload: calls
})