# bloggerapp

A React app with three components — **Book Details**, **Blog Details**, and **Course Details** —
built to showcase as many React conditional-rendering techniques as possible.

## Run it

```
npm install
npm start
```

Opens at http://localhost:3000

## Structure

```
src/
  data/
    books.js
    courses.js
    blogs.js
  components/
    BookDetails.js
    BlogDetails.js
    CourseDetails.js
  App.js
  App.css
  index.js
  index.css
```

## Conditional rendering techniques demonstrated

| # | Technique | Where |
|---|-----------|-------|
| 1 | Early `return null` to hide a component entirely | `CourseDetails.js` |
| 2 | Plain `if` statement / early return for an empty state | `CourseDetails.js` |
| 3 | `if / else if / else` chain, result stored in a variable then rendered ("element variable" pattern) | `CourseDetails.js` |
| 4 | `&&` (logical AND) short-circuit | `CourseDetails.js`, `App.js` |
| 5 | Ternary operator (`condition ? a : b`) | `BookDetails.js`, `App.js` |
| 6 | `switch` statement to derive a value | `BookDetails.js` |
| 7 | Object/enum lookup map used instead of if/else | `BlogDetails.js` |
| 8 | IIFE (Immediately Invoked Function Expression) inside JSX | `BlogDetails.js` |
| 9 | `\|\|` operator for default/fallback values | `BlogDetails.js` |
| 10 | Ternary for a "loading" state | `App.js` |
| 11 | Passing a `show` boolean prop down so each child owns its own conditional logic | `App.js` |

## Interacting with it

Three checkboxes at the top let you toggle each section on/off, which exercises
each component's own conditional-rendering branch (ternary / return-null) live in the browser.
