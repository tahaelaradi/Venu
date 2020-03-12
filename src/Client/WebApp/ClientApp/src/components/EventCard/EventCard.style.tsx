import styled from "styled-components";
import { themeGet } from "@styled-system/theme-get";

export const EventCardWrapper = styled.div`
  height: 100%;
  width: 100%;
  background-color: #fff;
  position: relative;
  font-family: sans-serif;
  border-radius: 6px;
  cursor: pointer;
`;

export const EventImageWrapper = styled.div`
  height: 240px;
  padding: 5px;
  position: relative;
  text-align: center;
  display: flex;
  align-items: center;
  justify-content: center;

  img {
    max-width: 100%;
    max-height: 100%;
    display: inline-block;
  }

  @media (max-width: 767px) {
    height: 145px;
  }
`;

export const EventInfo = styled.div`
  padding: 20px 25px 30px;

  @media (max-width: 767px) {
    padding: 15px 20px;
    min-height: 123px;
  }

  .event-title {
    font-family: sans-serif;
    font-size: ${themeGet("fontSizes.2", "15")}px;
    font-weight: ${themeGet("fontWeights.6", "700")};
    color: ${themeGet("colors.darkBold", "#0D1136")};
    margin: 0 0 7px 0;
    width: 100%;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;

    @media (max-width: 767px) {
      font-size: 14px;
      margin: 0 0 5px 0;
    }
  }
`;
