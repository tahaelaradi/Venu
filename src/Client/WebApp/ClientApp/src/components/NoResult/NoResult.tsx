import React from 'react';
import NoResultSvg from './no-result.png';
import { NoResultWrapper, ImageWrapper } from './NoResult.style';

type NoResultFoundProps = {
  id?: string;
};

const NoResultFound: React.FC<NoResultFoundProps> = ({ id }) => {
  return (
    <NoResultWrapper id={id}>
      <h3>Sorry, No result found...</h3>

      <ImageWrapper>
        <img src={NoResultSvg} alt="No Result" />
      </ImageWrapper>
    </NoResultWrapper>
  );
};

export default NoResultFound;
