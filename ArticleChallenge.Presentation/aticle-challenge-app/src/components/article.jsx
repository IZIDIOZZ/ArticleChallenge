import React from "react";
import { AddLikeArticle, getArticle } from "../services/articlesService";
import { getUserId } from "../services/localStorageService";
import Like from "./common/like";
import NavLink from "react-router-dom/NavLink";
import {
  UserAlreadyLiked,
  RemoveLikeArticle,
} from "./../services/articlesService";

class Article extends React.Component {
  state = { article: [], isLiked: false };

  async componentDidMount() {
    const { id } = this.props.match.params;
    if (id == null) this.props.history.push("/not-found");
    const { data: article } = await getArticle(id);
    const { likes } = article;
    this.setState({
      article,
      isLiked: likes.some((x) => x.userIdLiked === getUserId()),
    });
  }

  handleLike = async (articleId) => {
    const userId = getUserId();
    const { data: userLiked } = await UserAlreadyLiked(articleId, userId);

    if (userLiked) {
      const { data: articleWithLikeRemoved } = await RemoveLikeArticle(
        articleId,
        userId
      );
      return this.setState({ article: articleWithLikeRemoved, isLiked: false });
    }
    const { data: article } = await AddLikeArticle(articleId, userId);

    if (!article) return;
    this.setState({ article: article, isLiked: true });
  };

  render() {
    const { title, author, content, publishDate, likesCount } =
      this.state.article;
    const { id } = this.props.match.params;
    return (
      <div className="col d-flex flex-column justify-content-center align-content-center">
        <h2> {title}</h2>
        <h6>
          Written by <span className="text-capitalize"> {author}</span>
        </h6>
        <p>
          {content} <br />
          <small className="">
            {new Date(Date.parse(publishDate)).toLocaleString()}
          </small>
        </p>
        <div className="d-flex align-items-center mb-2">
          <Like
            isLiked={this.state.isLiked}
            onLike={() => this.handleLike(id)}
          />
          {(likesCount === 0 && (
            <p className="h5 m-0">This article has no Likes</p>
          )) || <p className="h5 m-0">{likesCount} Likes</p>}
        </div>
        <p>
          <NavLink to="/" className="btn btn-primary">
            Go Back to Articles
          </NavLink>
        </p>
      </div>
    );
  }
}

export default Article;
