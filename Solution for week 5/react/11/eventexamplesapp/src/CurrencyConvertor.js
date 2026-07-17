import React, { Component } from 'react';

class CurrencyConvertor extends Component {
  constructor() {
    super();
    this.state = {
      amount: '',
      currency: ''
    };
    this.handleAmountChange = this.handleAmountChange.bind(this);
    this.handleCurrencyChange = this.handleCurrencyChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleAmountChange(event) {
    this.setState({ amount: event.target.value });
  }

  handleCurrencyChange(event) {
    this.setState({ currency: event.target.value });
  }

  handleSubmit() {
    const conversionRate = 80; // sample INR -> Euro rate
    const convertedAmount = this.state.amount * conversionRate;
    alert(`Converting to  ${this.state.currency} Amount is ${convertedAmount}`);
  }

  render() {
    return (
      <div>
        <h1 style={{ color: 'green' }}>Currency Convertor!!!</h1>

        <table>
          <tbody>
            <tr>
              <td>Amount:</td>
              <td>
                <input
                  type="text"
                  value={this.state.amount}
                  onChange={this.handleAmountChange}
                />
              </td>
            </tr>
            <tr>
              <td>Currency:</td>
              <td>
                <input
                  type="text"
                  value={this.state.currency}
                  onChange={this.handleCurrencyChange}
                />
              </td>
            </tr>
          </tbody>
        </table>

        <button onClick={this.handleSubmit}>Submit</button>
      </div>
    );
  }
}

export default CurrencyConvertor;