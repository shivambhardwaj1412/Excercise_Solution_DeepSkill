import React from 'react';
import { blogs } from '../data/blogs';

// Technique 7: an object used as an "enum" lookup map instead of if/else or switch
const categoryIcons = {
  tutorial: '\ud83d\udcd8',
  guide: '\ud83d\udee0\ufe0f',
  news: '\ud83d\udcf0',
};

// BlogDetails demonstrates:
//  7. Object/enum lookup map (categoryIcons above)
//  8. An IIFE (Immediately Invoked Function Expression) inside JSX for
//     more complex branching logic than a ternary can comfortably express
//  9. The && operator again, plus the || operator for default fallback text
function BlogDetails({ show }) {
  if (!show) return null;

  return (
    <div className="v1">
      <h1>Blog Details</h1>
      {blogs.map((blog) => (
        <div key={blog.id}>
          {/* Technique 8: IIFE - lets us run a small block of if/return logic
              directly inside the JSX tree */}
          {(() => {
            if (!blog.published) {
              return (
                <p>
                  <em>This post is not yet published.</em>
                </p>
              );
            }
            return (
              <>
                <h1>
                  {blog.title} {categoryIcons[blog.category] || '\ud83d\udcc4'}
                  {/* Technique 9a: && operator - featured badge only if featured */}
                  {blog.featured && <strong> \u2b50 Featured</strong>}
                </h1>
                <h3>{blog.author}</h3>
                {/* Technique 9b: || operator - fallback text if content is empty */}
                <p>{blog.content || 'No content provided.'}</p>
              </>
            );
          })()}
        </div>
      ))}
    </div>
  );
}

export default BlogDetails;
