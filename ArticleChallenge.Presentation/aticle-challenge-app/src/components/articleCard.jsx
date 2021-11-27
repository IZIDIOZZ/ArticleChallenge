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
        <p className="card-text">{content}</p>
        <div className="d-flex align-items-center mb-2">
          <Like
            likesCount={likesCount}
            isLiked={article.likes.some((x) => x.userIdLiked == userId)}
            onLike={() => onLike(articleId)}
          />
          {(likesCount === 0 && (
            <p className="h5 m-0">Este artigo não tem Likes</p>
          )) || <p className="h5 m-0">{likesCount}</p>}
        </div>
        <NavLink to={`articles/${articleId}`} className="btn btn-primary">
          Go to Article
        </NavLink>
      </div>
      <div className="card-footer text-muted">
        Artigo publicado em:{" "}
        {new Date(Date.parse(publishDate)).toLocaleDateString()}
      </div>
    </div>
  );
};

export default ArticleCard;
