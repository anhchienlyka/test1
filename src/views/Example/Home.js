import React from "react";
import { withRouter } from "react-router";
import Color from "../HOC/Color";
import logo from "../../assets/images/chien.jpg";
import { connect } from "react-redux";
class Home extends React.Component {
  // componentDidMount() {
  //   setTimeout(() => {
  //     this.props.history.push('/todo');
  //   }, 3000);
  // }

  clickDelete = (user) => {
    this.props.deleteUserRedux(user);
  };
addUser = () =>{
  this.props.addUserRedux();
}
  render() {
    console.log(">>>>>", this.props);
    let listUser = this.props.dataRedux;
    return (
      <>
        <div>Hello. welcome to home</div>
        {/* <div>
          <img src={logo}/>

        </div> */}
        <div>
          {listUser &&
            listUser.length > 0 &&
            listUser.map((item, index) => {
              return (
                <div key={item.id}>
                  {index + 1} {item.name}{" "}
                  <span onClick={() => this.clickDelete(item)}>X&nbsp;&nbsp;&nbsp;</span>
                </div>
              );
            })}
            <button type="button" onClick={()=>this.addUser()}>ADD</button>
        </div>
      </>
    );
  }
}
const hihi = (state) => {
  console.log("userrrrr", state.users);
  return {
    dataRedux: state.users,
  };
};
const mapDispath = (dispatch) => {
  return {
    deleteUserRedux: (userdelete) =>  dispatch({ type: "DELETE_USER", payload: userdelete }),
    addUserRedux: () => dispatch({type: "CREATE_USER"}),
    
  };
};
//export default withRouter(Home);
export default connect(hihi,mapDispath)(Color(Home));
