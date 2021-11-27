import newGuid from './../utils/Guid';
const keyLocalStorage = "LikedArticles";
const keyLocalUserID = "UserId";

export const storeUserLike = (ArticleLike) =>{
    // atob()
    const {likeArticleId} = ArticleLike

    const articlesLiked = JSON.parse(localStorage.getItem(keyLocalStorage)) || []
    
    if(articlesLiked.find(x=>x.likeArticleId === likeArticleId)) {
        articlesLiked = articlesLiked.filter(x=>x.likeArticleId !== likeArticleId)
    }
    else articlesLiked.push(ArticleLike)
    console.log(articlesLiked)
    
    // localStorage.setItem(keyLocalStorage,JSON.stringify(articlesLiked))
}

export const removeStoredUserLike = (likeArticleId) =>{
    // atob()
    localStorage.removeItem(likeArticleId);
}

export const storeUserId = () =>{
    if(localStorage.getItem(keyLocalUserID) !== null) return;
    localStorage.setItem(keyLocalUserID, newGuid());
}

export const getUserId = () =>{
    return  localStorage.getItem(keyLocalUserID);
}
