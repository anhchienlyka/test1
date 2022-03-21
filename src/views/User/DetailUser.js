import { wait } from "@testing-library/user-event/dist/utils";
import React from "react";
import axios from "axios";
import { withRouter } from "react-router-dom";

class DetailUser extends React.Component {
  state = {
    detailUser: {},

  };

  async componentDidMount() {
    if (this.props.match && this.props.match.params) {
      let id = this.props.match.params.id;
      let res = await axios.get(`https://reqres.in/api/users/${id}`);
      this.setState({
        detailUser: res && res.data && res.data.data ? res.data.data : [],
      });
    }
  }
  handleHome = () => {
    this.props.history.push(`/user`);
  };

  // handleBack = (id) => {
  //   id = id-1;
  //   console.log("iddddddd",id);
  //   let res =  axios.get(`https://reqres.in/api/users/${id}`);
  //   this.setState({
  //     detailUser: res && res.data && res.data.data ? res.data.data : [],
  //   });
  // };





  handlePreviously = (back) => {
    this.props.history.push(`/user/${back + 1}`);
  };
  render() {
    let detailUser = this.state;
    let isEmtyObj = Object.keys(detailUser).length === 0;
    return (
      <>
        <>
        {isEmtyObj === false && (
          <>
            <div>Hello {detailUser.first_name}</div>

            <div>Hello {detailUser.email}</div>
            <div>
              <img src={detailUser.avatar} />
            </div>
            <br></br>
          </>
        )}
          <br></br>
          <div>
            <button type="button" onClick={() => this.handleBack(detailUser.id)}>
              Back
            </button>
            <button type="button" onClick={() => this.handleHome()}>
              Home
            </button>
            <button type="button" onClick={() => this.handlePreviously()}>
              Previously
            </button>
          </div>
        </>
      </>
    );
  }
}
export default withRouter(DetailUser);
