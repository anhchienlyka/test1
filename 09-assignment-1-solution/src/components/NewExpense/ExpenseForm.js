import React from "react";
import "./ExpenseForm.css";

const ExpenseForm = () => {
  const titileChangeHandler=()=>{
 console.log('test')
  }
  return (
    <>
      <from>
        <div className="new-expense__controls">
          <div className="new-expense__control">
            <label>Title</label>
            <input type="text" onChange={titileChangeHandler} />
          </div>
          <div className="new-expense__control">
            <label>Amount</label>
            <input type="number" min="0.01" step="0.01" />
          </div>
          <div className="new-expense__control">
            <label>Date</label>
            <input type="date" min="2019-01-01" max="2023-12-31" />
          </div>
        </div>
        <div className="new-expense__actions">
            <button type="submit">Add Expense</button>
          </div>
      </from>
    </>
  );
};

export default ExpenseForm;
