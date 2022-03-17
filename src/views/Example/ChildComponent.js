import React from "react";
import "./Demo.css";

class ChildComponent extends React.Component {
  state = {
    showJob: false,
  };

  handleShowHide = () => {
    this.setState({
      showJob: !this.state.showJob,
    });
  };
  handleOnclickDelete = (job) => {
    //console.log(">>>> ", job);
    this.props.deleteOneJob(job);
  };
  render() {
    let { ab } = this.props;
    let { showJob } = this.state;
    let check = showJob === true ? "showJob = true" : "showJob = false";

    return (
      <>
        {showJob === false ? (
          <div>
            <button className="btn-show" onClick={() => this.handleShowHide()}>
              Show
            </button>
          </div>
        ) : (
          <>
            <div>Child Component {this.props.name}</div>
            <div>
              {ab.map((item, index) => {
                if (item.salary >= 500) {
                  return (
                    <div key={item.id}>
                      {item.title} - {item.salary}
                      <></>{" "}
                      <span onClick={() => this.handleOnclickDelete(item)}>
                        x
                      </span>
                    </div>
                  );
                }
              })}
            </div>
            <div>
              <button onClick={() => this.handleShowHide()}>Hide</button>
            </div>
          </>
        )}
      </>
    );
  }
}
export default ChildComponent;
