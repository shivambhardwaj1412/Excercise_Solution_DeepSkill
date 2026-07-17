import React from 'react';
import './App.css';

// Element to display the heading
const element = "Office Space";

// List of office objects (Name, Rent, Address, image)
const officeList = [
  {
    Name: 'DBS',
    Rent: 50000,
    Address: 'Chennai',
    src: 'https://images.unsplash.com/photo-1497366216548-37526070297c?w=400'
  },
  {
    Name: 'WeWork',
    Rent: 75000,
    Address: 'Bangalore',
    src: 'https://images.unsplash.com/photo-1497366811353-6870744d04b2?w=400'
  },
  {
    Name: 'Regus',
    Rent: 55000,
    Address: 'Mumbai',
    src: 'https://images.unsplash.com/photo-1524758631624-e2822e304c36?w=400'
  }
];

// Function to decide the CSS class based on Rent
function getRentColor(ItemName) {
  let colors = [];
  if (ItemName.Rent <= 60000) {
    colors.push('textRed');
  } else {
    colors.push('textGreen');
  }
  return colors.join(' ');
}

function App() {
  return (
    <div>
      <h1>{element}, at Affordable Range</h1>

      {officeList.map((ItemName, index) => {
        // JSX attribute for the image
        const jsxatt = (
          <img
            src={ItemName.src}
            width="25%"
            height="25%"
            alt="Office Space"
          />
        );

        return (
          <div className="office-card" key={index}>
            {jsxatt}
            <h1>Name: {ItemName.Name}</h1>
            <h3 className={getRentColor(ItemName)}>
              Rent: Rs. {ItemName.Rent}
            </h3>
            <h3>Address: {ItemName.Address}</h3>
          </div>
        );
      })}
    </div>
  );
}

export default App;