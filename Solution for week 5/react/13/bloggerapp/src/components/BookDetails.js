import React from 'react';
import { books } from '../data/books';

// BookDetails demonstrates:
//  5. The ternary operator (condition ? a : b), used twice - once to hide/show
//     the whole component, and once to switch between an empty-state and a list
//  6. A switch statement to compute a derived "price label" per book
function BookDetails({ show }) {
  // Technique 5a: ternary operator at the top of the component -
  // renders the whole block, or null, based on the "show" prop
  return show ? (
    <div className="st2">
      <h1>Book Details</h1>
      {/* Technique 5b: ternary operator choosing between two JSX branches */}
      {books.length === 0 ? (
        <p>No books to display.</p>
      ) : (
        <ul>
          {books.map((book) => {
            // Technique 6: switch statement to derive a label from the price
            let priceLabel;
            switch (true) {
              case book.price >= 700:
                priceLabel = 'Premium';
                break;
              case book.price >= 500:
                priceLabel = 'Standard';
                break;
              default:
                priceLabel = 'Budget';
            }

            return (
              <div key={book.id}>
                <h3>
                  {book.bname} <em>({priceLabel})</em>
                </h3>
                <h4>{book.price}</h4>
              </div>
            );
          })}
        </ul>
      )}
    </div>
  ) : null;
}

export default BookDetails;
