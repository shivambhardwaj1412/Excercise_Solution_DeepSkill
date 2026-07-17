import React from 'react';
import '../Stylesheets/mystyle.css';

function CalculateScore(props) {
  const average = (props.Total / props.goal) * 100;

  return (
    <div className="container">
      <h2>Student Details:</h2>
      <table className="score-table">
        <tbody>
          <tr>
            <td>Name</td>
            <td>{props.Name}</td>
          </tr>
          <tr>
            <td>School</td>
            <td>{props.School}</td>
          </tr>
          <tr>
            <td>Total</td>
            <td>{props.Total}Marks</td>
          </tr>
          <tr>
            <td>Score</td>
            <td>{average.toFixed(2)}%</td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}

export default CalculateScore;
