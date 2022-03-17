import React from "react";
import { toast } from "react-toastify";
import AddTodo from "./AddTodo";
import "./ListTodo.scss";

class ListTodo extends React.Component {
  state = {
    listTodos: [
      { id: "todo1", title: "WFH" },
      { id: "todo2", title: "WFO" },
      { id: "todo3", title: "Test" },
      { id: "todo4", title: "Dev" },
    ],
    editTodo: {},
  };
  addNewTodo = (todo) => {
    this.setState({
      listTodos: [...this.state.listTodos, todo],
    });
    toast.success("Add success!");
  };
  handleDeleteTodo = (todo) => {
    let currentTodo = this.state.listTodos;
    currentTodo = currentTodo.filter((item) => item.id !== todo.id);
    this.setState({
      listTodos: currentTodo,
    });
    toast.success("Delete success!");
  };
  handleEditTodo = (todo) => {
    let { editTodo, listTodos } = this.state;

    let isEmtyObj = Object.keys(editTodo).length === 0;

    //khi an nut save
    if (isEmtyObj === false && editTodo.id === todo.id) {
      let ListTodoCoppy = [...listTodos];
      let ObjectIndex = ListTodoCoppy.findIndex((item) => item.id === todo.id);
      ListTodoCoppy[ObjectIndex].title = editTodo.title;
      this.setState({
        listTodos: ListTodoCoppy,
        editTodo: {},
      });

      toast.success("Edit success!");
      return;
    }
    // edit
    this.setState({
      editTodo: todo,
    });
  };
  handleOnChange = (event) => {
    let editTodocoppy = { ...this.state.editTodo };
    editTodocoppy.title = event.target.value;
    this.setState({
      editTodo: editTodocoppy,
    });
  };

  render() {
    let { listTodos, editTodo } = this.state;
    //let [listTodos] = this.state;
    //kiem tra xem Obj co empty k
    let isEmtyObj = Object.keys(editTodo).length === 0;
    console.log(">>>check empty obj", isEmtyObj);
    return (
      <>
        <p>Hello world. </p>
        <div className="list-todo-container">
          <AddTodo addNewTodo={this.addNewTodo} />
          <div className="list-todo-content">
            {listTodos &&
              listTodos.length > 0 &&
              listTodos.map((item, index) => {
                return (
                  <div className="todo-child" key={item.id}>
                    {isEmtyObj == true ? (
                      <span>
                        {index + 1} - {item.title}{" "}
                      </span>
                    ) : (
                      <>
                        {editTodo.id === item.id ? (
                          <span>
                            {index + 1} -{" "}
                            <input
                              value={editTodo.title}
                              onChange={(event) => this.handleOnChange(event)}
                            />
                          </span>
                        ) : (
                          <span>
                            {index + 1} - {item.title}{" "}
                          </span>
                        )}
                      </>
                    )}

                    <button
                      className="edit"
                      onClick={() => this.handleEditTodo(item)}
                    >
                      {isEmtyObj === false && editTodo.id === item.id
                        ? "Save"
                        : "Edit"}
                    </button>
                    <button
                      className="delete"
                      onClick={() => this.handleDeleteTodo(item)}
                    >
                      Delete
                    </button>
                  </div>
                );
              })}
          </div>
        </div>
      </>
    );
  }
}
export default ListTodo;
