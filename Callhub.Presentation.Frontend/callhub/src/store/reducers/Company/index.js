const INITIAL_STATE = {
  list: [
    {
      id: 1,
      name: "Rocketseat",
      departments: [
        { id: 1, name: "financeiro" },
        { id: 2, name: "compras" },
        { id: 3, name: "controladoria" }
      ]
    },
    {
      id: 2,
      name: "D'stak",
      departments: [
        { id: 1, name: "contabilidade" },
        { id: 2, name: "compras" },
        { id: 3, name: "controladoria" }
      ]
    },
    {
      id: 3,
      name: "MGM",
      departments: [
        { id: 1, name: "financeiro" },
        { id: 2, name: "compras" },
        { id: 3, name: "controladoria" },
        { id: 4, name: "engenharia" },
        { id: 5, name: "ti" }
      ]
    }
  ],
  selected: {}
};

export default function company(state = INITIAL_STATE, action) {
  switch (action.type) {
    case "SET_COMPANY":
      return { ...state, selected: action.company };

    default:
      return state;
  }
}
