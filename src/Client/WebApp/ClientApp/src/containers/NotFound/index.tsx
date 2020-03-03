import React from "react";
import {
  NoResultWrapper,
  NoResultMsg
} from "./NotFound.style";

type NoResultProps = {
  id?: string;
  style?: any;
};

const NoResult: React.FC<NoResultProps> = ({ id, style }) => {
  return (
    <NoResultWrapper id={id} style={style}>
      <NoResultMsg>404 Not found!</NoResultMsg>
    </NoResultWrapper>
  );
};

export default NoResult;