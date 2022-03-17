import React from "react";
import ChildComponent from "./ChildComponent";
import AddComponent from "./AddCompenent";

class MyComponent extends React.Component {
  state = {
    arrJob: [
      { id: "123a", title: "dev", salary: "500" },
      { id: "123b", title: "test", salary: "400" },
    ],
  };
  addNewJob = (job) => {
    //console.log("check: ", job)
    //let currentJob = this.state.arrJob
    //currentJob.push(job)
    this.setState({
      arrJob: [...this.state.arrJob, job],
      // arrJob: currentJob
    });
  };

  deleteOneJob = (job) => {
    let currentJob = this.state.arrJob;
    currentJob = currentJob.filter(item => item.id !== job.id);
    this.setState({
      arrJob: currentJob,
    });
  };
  clickFC = () => {
    alert("Hello");
  };

  render() {
    return (
      <>
        <h2>My name is {this.state.name}</h2>
        <AddComponent addNewJob={this.addNewJob} />
        <ChildComponent
          ab={this.state.arrJob}
          deleteOneJob={this.deleteOneJob}
        />
      </>
    );
  }
}
export default MyComponent;
