import React from "react";
import ArticleCard from "./articleCard";
const ArticleList = ({ articles, userId, onLike }) => {
  return (
    <div className="">
      {articles.map((a) => (
        <div className="col" key={a.articleId}>
          <ArticleCard article={a} onLike={onLike} userId={userId} />
        </div>
      ))}
    </div>
  );
};

export default ArticleList;
