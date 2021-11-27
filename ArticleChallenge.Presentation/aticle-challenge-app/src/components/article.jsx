import React from "react";
import { getArticle } from "../services/articlesService";
import { getUserId } from "../services/localStorageService";
class Article extends React.Component {
  state = { article: [] };

  async componentDidMount() {
    // const { data: article } = await getArticle();
    // if (article === null) return;
    // this.setState({ article });
  }
  render() {
    console.log(this.props);
    return (
      <div className="col d-flex flex-column justify-content-center align-content-center">
        <h2></h2>
        <p></p>
        <p>
          <a className="btn btn-secondary" href="#" role="button">
            View details »
          </a>
        </p>
      </div>
    );
  }
}

export default Article;
