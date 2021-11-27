import React from "react";
import {
  getAllArticles,
  AddLikeArticle,
  UserAlreadyLiked,
  RemoveLikeArticle,
} from "./../services/articlesService";
import ArticleList from "./articleList";
import {
  storeUserLike,
  storeUserId,
  getUserId,
} from "./../services/localStorageService";
class Articles extends React.Component {
  state = {
    articles: [],
  };

  async componentDidMount() {
    const { data: articles } = await getAllArticles();
    storeUserId();
    if (articles === null) return;
    this.setState({ articles });
  }

  render() {
    const { articles } = this.state;
    return (
      <div>
        <ArticleList
          articles={articles}
          userId={getUserId()}
          onLike={this.handleLike}
        />
      </div>
    );
  }
}
export default Articles;
