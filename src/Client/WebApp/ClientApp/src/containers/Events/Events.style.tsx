import styled from "styled-components";
import { themeGet } from "@styled-system/theme-get";

export const ProductsRow = styled.div`
  display: flex;
  flex-wrap: wrap;
  margin-top: 25px;
  background-color: #f7f7f7;
  position: relative;
  z-index: 1;

  @media (max-width: 768px) {
    margin-left: -7.5px;
    margin-right: -7.5px;
    margin-top: 15px;
  }
`;

export const ProductsCol = styled.div`
  flex: 0 0 20%;
  max-width: 20%;
  padding-left: 15px;
  padding-right: 15px;
  margin-bottom: 30px;

  .book-card {
    border-radius: 0;
  }

  @media (min-width: 1501px) {
    &:nth-child(5n + 1) {
      .book-card {
        border-radius: 6px 0 0 6px;
      }
    }

    &:nth-child(5n) {
      .book-card {
        border-radius: 0 6px 6px 0;
      }
    }
  }

  @media (min-width: 1301px) and (max-width: 1500px) {
    flex: 0 0 25%;
    max-width: 25%;

    &:nth-child(4n + 1) {
      .book-card {
        border-radius: 6px 0 0 6px;
      }
    }

    &:nth-child(4n) {
      .book-card {
        border-radius: 0 6px 6px 0;
      }
    }
  }

  @media (min-width: 768px) and (max-width: 1300px) {
    flex: 0 0 33.3333333%;
    max-width: 33.3333333%;

    &:nth-child(3n + 1) {
      .book-card {
        border-radius: 6px 0 0 6px;
      }
    }

    &:nth-child(3n) {
      .book-card {
        border-radius: 0 6px 6px 0;
      }
    }
  }
  @media (max-width: 1199px) and (min-width: 991px) {
    padding-left: 10px;
    padding-right: 10px;
    margin-bottom: 20px;
  }
  @media (max-width: 768px) {
    padding-left: 7.5px;
    padding-right: 7.5px;
    margin-bottom: 15px;
  }
  @media (max-width: 767px) {
    flex: 0 0 50%;
    max-width: 50%;

    &:nth-child(2n + 1) {
      .book-card {
        border-radius: 6px 0 0 6px;
      }
    }

    &:nth-child(2n) {
      .book-card {
        border-radius: 0 6px 6px 0;
      }
    }
  }
`;

export const LoaderWrapper = styled.div`
  width: 100%;
  height: 100vh;
  display: flex;
  flex-wrap: wrap;
`;

export const LoaderItem = styled.div`
  width: 25%;
  padding: 0 15px;
  margin-bottom: 30px;
`;

export const ProductCardWrapper = styled.div`
  height: 100%;

  > div {
    height: 100%;
  }
`;
