import newGuid from './../utils/Guid';
const keyLocalUserID = "UserId";

export const storeUserId = () =>{
    if(localStorage.getItem(keyLocalUserID) !== null) return;
    localStorage.setItem(keyLocalUserID, newGuid());
}

export const getUserId = () =>{
    return  localStorage.getItem(keyLocalUserID);
}
