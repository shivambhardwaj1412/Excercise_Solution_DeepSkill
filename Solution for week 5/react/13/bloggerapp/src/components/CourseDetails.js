import React from 'react';
import { courses } from '../data/courses';

// CourseDetails demonstrates:
//  1. Early return (returning null) to hide a component entirely
//  2. A plain if statement for an "empty state"
//  3. if / else-if / else assigned to a variable, then rendered ("element variable" pattern)
//  4. The && (logical AND) short-circuit operator
function CourseDetails({ show }) {
  // Technique 1: returning null prevents this component from rendering at all
  if (!show) {
    return null;
  }

  // Technique 2: plain if statement, early return for an empty state
  if (courses.length === 0) {
    return (
      <div className="mystyle1">
        <h1>Course Details</h1>
        <p>No courses available.</p>
      </div>
    );
  }

  return (
    <div className="mystyle1">
      <h1>Course Details</h1>
      <ul>
        {courses.map((course) => {
          // Technique 3: if / else-if / else, result stored in a variable
          // then that variable ("element variable") is dropped into JSX below
          let levelBadge;
          if (course.level === 'Advanced') {
            levelBadge = <span className="badge badge-advanced">Advanced</span>;
          } else if (course.level === 'Intermediate') {
            levelBadge = <span className="badge badge-intermediate">Intermediate</span>;
          } else {
            levelBadge = <span className="badge badge-beginner">Beginner</span>;
          }

          return (
            <li key={course.id} className="course-item">
              <h3>
                {course.cname} {levelBadge}
              </h3>
              <h4>{course.date}</h4>
              {/* Technique 4: && operator - only render the tag if isNew is true */}
              {course.isNew && <span className="tag-new">New!</span>}
            </li>
          );
        })}
      </ul>
    </div>
  );
}

export default CourseDetails;
