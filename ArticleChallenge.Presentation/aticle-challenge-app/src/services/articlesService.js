import axios from "axios";

const baseUrl = "https://localhost:44388";

export const getAllArticles = () => {
       return axios.get(baseUrl+'/api/Article/all')
}

export const getArticle = (articleId) => {
       return axios.get(baseUrl+`/api/Article/${articleId}`)
}

export const UserAlreadyLiked = (articleId, userIdLiked) => {
    return axios.get(baseUrl+`/api/Article/like/alreadyLiked/${articleId}/${userIdLiked}`)
}  

export const AddLikeArticle = (articleId, userIdLiked) => {
       const obj = {articleId,userIdLiked}
       return axios.post(baseUrl+'/api/Article/like',obj)
}  

export const RemoveLikeArticle = (articleId, userIdLiked) => {
       
       return axios.delete(baseUrl+`/api/Article/like/remove/${articleId}/${userIdLiked}`)
}   

    


