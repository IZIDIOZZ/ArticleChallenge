import React from "react";
const Like = ({ isLiked, onLike }) => {
  let classes = `fa fa-heart${!isLiked ? "-o" : ""} fa-2x btn pl-0`;
  return <i className={classes} aria-hidden="true" onClick={onLike}></i>;
};

export default Like;
