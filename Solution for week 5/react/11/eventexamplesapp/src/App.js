import React, { Component } from 'react';
import CurrencyConvertor from './CurrencyConvertor';

class App extends Component {
  constructor() {
    super();
    this.state = {
      count: 5
    };
  }

  // a. Increment the counter
  increment() {
    this.setState((prevState) => {
      return { count: prevState.count + 1 };
    });
  }

  // b. Say Hello + static message
  sayHello() {
    alert('Hello! Member1');
  }

  // Increment button invokes BOTH methods
  handleIncrementClick() {
    this.increment();
    this.sayHello();
  }

  decrement() {
    this.setState((prevState) => {
      return { count: prevState.count - 1 };
    });
  }

  // Function that takes an argument
  sayWelcome(message) {
    alert(message);
  }

  // Synthetic event handler
  handleClick(event) {
    alert('I was clicked');
  }

  render() {
    return (
      <div>
        <p>{this.state.count}</p>

        <button onClick={() => this.handleIncrementClick()}>
          Increment
        </button>
        <br />
        <button onClick={() => this.decrement()}>
          Decrement
        </button>
        <br />
        <button onClick={() => this.sayWelcome('welcome')}>
          Say welcome
        </button>
        <br />
        <button onClick={(event) => this.handleClick(event)}>
          Click on me
        </button>

        <CurrencyConvertor />
      </div>
    );
  }
}

export default App;