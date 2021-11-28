import React from "react";
import { Link, NavLink } from "react-router-dom";
import Like from "./common/like";
const ArticleCard = ({ article, onLike, userId }) => {
  const { title, author, content, articleId, likesCount, publishDate } =
    article;
  return (
    <div className="card m-3">
      <div className="card-body">
        <h3 className="card-title">
          <strong>Title:</strong> {title}
        </h3>
        <h5 className="card-title">
          <strong>Author:</strong> {author}
        </h5>
        <p className="card-text">{`${content.toString().slice(0, 200)}...`}</p>
        <div className="d-flex align-items-center mb-2">
          {(likesCount === 0 && (
            <p className="h5 m-0">This article has no Likes</p>
          )) || <p className="h5 m-0">{likesCount} Likes</p>}
        </div>
        <NavLink to={`articles/${articleId}`} className="btn btn-primary">
          Go to Article
        </NavLink>
      </div>
      <div className="card-footer text-muted">
        Article published in:{" "}
        {new Date(Date.parse(publishDate)).toLocaleDateString()}
      </div>
    </div>
  );
};

export default ArticleCard;
