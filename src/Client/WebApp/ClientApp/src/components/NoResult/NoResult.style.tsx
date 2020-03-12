import styled from "styled-components";

export const NoResultWrapper = styled.div`
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 50px 20px;

  h3 {
    font-size: 24px;
    font-weight: 700;
    color: #0d1136;
    margin: 0 0 15px;
  }

  p {
    font-size: 16px;
    font-weight: 400;
    color: #707070;
    margin: 0;
  }
`;

export const ImageWrapper = styled.div`
  margin-top: 50px;
  width: 100%;
  max-width: 600px;
  display: flex;
  align-items: center;
  justify-content: center;

  img {
    max-width: 100%;
  }
`;
