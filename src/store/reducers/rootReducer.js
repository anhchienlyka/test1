//state: trang thai redux
const initState = {
  users: [
    { id: 1, name: "Chi" },
    { id: 2, name: "Thoi" },
  ],
};
const rootReducer = (state = initState, action) => {
  switch (action.type) {
    case "DELETE_USER":
      console.log(">>>>", action);
      let users = state.users;
      let lan = state.users;
      console.log("usrsssss",users);
      console.log("lannnnn",lan);
      users = users.filter(item => item.id !== action.payload.id)
      return {
          ...state, users
      }
    case 'CREATE_USER':
        let id = Math.floor(Math.random() *100);
        let user = {id: id, name: `random - ${id}`}
        return {
            ...state,users: [...state.users,user]
        }
    default:
        return state;
  }
  
};
export default rootReducer;
