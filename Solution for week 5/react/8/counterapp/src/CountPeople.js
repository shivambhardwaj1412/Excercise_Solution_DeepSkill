import React, { Component } from 'react';

class CountPeople extends Component {
  constructor() {
    super();
    this.state = {
      entrycount: 0,
      exitcount: 0
    };
  }

  updateEntry() {
    this.setState((prevState, props) => {
      return { entrycount: prevState.entrycount + 1 };
    });
  }

  updateExit() {
    this.setState((prevState, props) => {
      return { exitcount: prevState.exitcount + 1 };
    });
  }

  render() {
    return (
      <div style={{ display: 'flex', justifyContent: 'center', marginTop: '150px', gap: '250px' }}>
        <div>
          <button
            style={{ backgroundColor: 'lightgreen', border: '1px solid black' }}
            onClick={() => this.updateEntry()}
          >
            Login
          </button>
          {' '}{this.state.entrycount} People Entered!!!
        </div>

        <div>
          <button
            style={{ backgroundColor: 'lightgreen', border: '1px solid black' }}
            onClick={() => this.updateExit()}
          >
            Exit
          </button>
          {' '}{this.state.exitcount} People Left!!!
        </div>
      </div>
    );
  }
}

export default CountPeople;