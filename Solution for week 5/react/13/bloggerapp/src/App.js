import React, { useState, useEffect } from 'react';
import './App.css';
import BookDetails from './components/BookDetails';
import BlogDetails from './components/BlogDetails';
import CourseDetails from './components/CourseDetails';

// App.js demonstrates:
//  10. Ternary operator for a "loading" state
//  11. && operator for an "everything hidden" message
//  12. Passing a boolean "show" prop down so each child decides
//      its own conditional rendering (return null / ternary pattern)
function App() {
  const [loading, setLoading] = useState(true);
  const [showBooks, setShowBooks] = useState(true);
  const [showBlogs, setShowBlogs] = useState(true);
  const [showCourses, setShowCourses] = useState(true);

  useEffect(() => {
    const timer = setTimeout(() => setLoading(false), 600);
    return () => clearTimeout(timer);
  }, []);

  return (
    <div>
      <div className="toolbar">
        <label>
          <input
            type="checkbox"
            checked={showBooks}
            onChange={() => setShowBooks(!showBooks)}
          />
          Show Books
        </label>
        <label>
          <input
            type="checkbox"
            checked={showBlogs}
            onChange={() => setShowBlogs(!showBlogs)}
          />
          Show Blogs
        </label>
        <label>
          <input
            type="checkbox"
            checked={showCourses}
            onChange={() => setShowCourses(!showCourses)}
          />
          Show Courses
        </label>
      </div>

      {/* Technique 10: ternary operator for a loading state */}
      {loading ? (
        <p className="loading">Loading blogger app...</p>
      ) : (
        <div className="container">
          <BookDetails show={showBooks} />
          <BlogDetails show={showBlogs} />
          <CourseDetails show={showCourses} />
        </div>
      )}

      {/* Technique 11: && operator - only shown when nothing is selected */}
      {!loading && !showBooks && !showBlogs && !showCourses && (
        <p className="empty-msg">Nothing selected. Check a box above to see content.</p>
      )}
    </div>
  );
}

export default App;
