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
    this.setState({ articles });
  }

  handleLike = async (articleId) => {
    const articles = [...this.state.articles];
    const userId = getUserId();
    const indexArticle = articles.findIndex((x) => x.articleId === articleId);

    const { data: userLiked } = await UserAlreadyLiked(articleId, userId);

    if (userLiked) {
      const { data: articleWithLikeRemoved } = await RemoveLikeArticle(
        articleId,
        userId
      );
      articles[indexArticle] = articleWithLikeRemoved;
      return this.setState({ articles });
    }

    const { data } = await AddLikeArticle(articleId, userId);

    if (!data) return;

    this.saveLikedArticle(data);

    articles[indexArticle] = data;

    this.setState({ articles });
  };

  saveLikedArticle(article) {
    const lastLike = article.likes;
    console.log(lastLike);
    storeUserLike(lastLike.at(-1));
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
