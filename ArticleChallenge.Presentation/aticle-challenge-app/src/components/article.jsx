import React from "react";
import { AddLikeArticle, getArticle } from "../services/articlesService";
import { getUserId, storeUserLike } from "../services/localStorageService";
import Like from "./common/like";
import NavLink from "react-router-dom/NavLink";
import {
  UserAlreadyLiked,
  RemoveLikeArticle,
} from "./../services/articlesService";

class Article extends React.Component {
  state = { article: [], isLiked: false };

  constructor() {
    super();
  }
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
    let article = { ...this.state.article };
    const userId = getUserId();

    const { data: userLiked } = await UserAlreadyLiked(articleId, userId);

    if (userLiked) {
      const { data: articleWithLikeRemoved } = await RemoveLikeArticle(
        articleId,
        userId
      );
      article = articleWithLikeRemoved;
      return this.setState({ article, isLiked: false });
    }
    const { data } = await AddLikeArticle(articleId, userId);
    if (!data) return;
    this.saveLikedArticle(data);

    article = data;

    this.setState({ article, isLiked: true });
  };

  saveLikedArticle(article) {
    const lastLike = article.likes;
    storeUserLike(lastLike.at(-1));
  }

  userLiked(likes, userId) {
    if (likes == null) return false;
    return likes.some((x) => x.userIdLiked == userId);
  }

  render() {
    const { title, author, content, publishDate, likesCount } =
      this.state.article;
    const { article } = this.state;
    const { id } = this.props.match.params;
    return (
      <React.Fragment>
        {Object.keys(article).length > 0 ? (
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
                <p className="h5 m-0">Este artigo não tem Likes</p>
              )) || <p className="h5 m-0">{likesCount}</p>}
            </div>
            <p>
              <NavLink to="/" className="btn btn-primary">
                Go Back to Articles
              </NavLink>
            </p>
          </div>
        ) : (
          <div className="d-flex justify-content-center align-content-center">
            <h1>Article Not Found</h1>
          </div>
        )}
      </React.Fragment>
    );
  }
}

export default Article;
