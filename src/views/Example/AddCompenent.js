import React from "react";

class AddComponent extends React.Component {
  state = {
    title: "",
    salary: "",
  };
  handletitleJob = (event) => {
    this.setState({
      title: event.target.value,
    });
  };
  handleChangesalary = (event) => {
    this.setState({
      salary: event.target.value,
    });
  };
  handleSubmitt = (event) => {
    event.preventDefault();
    if (!this.state.title || !this.state.salary) {
      alert("Missing required");
    }
    this.props.addNewJob({
      id: Math.floor(Math.random() * 100),
      title: this.state.title,
      salary: this.state.salary,
    });
    this.setState({
      title: "",
      salary: "",
    });
  };
  render() {
    return (
      <>
        <form>
          <label htmlFor="fname">Title Job</label>
          <br />
          <input
            type="text"
            value={this.state.title}
            onChange={(event) => this.handletitleJob(event)}
          />
          <br />
          <label htmlFor="lname">Salary</label>
          <br />
          <input
            type="text"
            value={this.state.salary}
            onChange={(event) => this.handleChangesalary(event)}
          />
          
          <br />
          <input
            type="submit"
            value="submit"
            onClick={(event) => this.handleSubmitt(event)}
          />
        </form>
      </>
    );
  }
}
export default AddComponent;
