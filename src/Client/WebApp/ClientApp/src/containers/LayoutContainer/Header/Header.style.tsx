import styled, { keyframes } from "styled-components";
import { themeGet } from "@styled-system/theme-get";

const positionAnim = keyframes`
  from {
    position: fixed;
    opacity: 1;
  }

  to {
    opacity: 0;
    transition: all 0.3s ease;
  }
`;

const hideSearch = keyframes`
  from {
    display: none;
  }

  to {
    display: flex;
  }
`;

const HeaderWrapper = styled.header`
  padding: 30px 60px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  position: fixed;
  z-index: 99999;
  top: 0;
  left: 0;
  width: 100%;
  background-color: #fff;
  box-shadow: 0 1px 2px rgba(0, 0, 0, 0.06);
  transition: all 0.3s ease;
  &.home {
    position: absolute;
    background-color: transparent;
    box-shadow: none;
  }

  @media (max-width: 1400px) {
    padding: 25px 40px;
  }

  @media (max-width: 990px) {
    display: none;
  }

  .headerSearch {
    margin: 0 30px;

    @media only screen and (min-width: 991px) and (max-width: 1200px) {
      margin: 0 15px;

      input {
        width: 80%;
      }

      .buttonText {
        display: none;
      }
    }
  }

  &.unSticky {
    animation: ${positionAnim} 0.3s ease;
    .headerSearch {
      animation: ${hideSearch} 0.3s ease;
    }
  }

  &.sticky {
    background-color: #ffffff;
    position: fixed;
    box-shadow: 0 1px 2px rgba(0, 0, 0, 0.06);
    padding-top: 20px;
    padding-bottom: 20px;

    @media (max-width: 1400px) {
      padding-top: 20px;
      padding-bottom: 20px;
    }

    .headerSearch {
      display: flex;

      form {
        background-color: ${themeGet("colors.lightMediumColor", "#F3F3F3")};

        input {
          background-color: ${themeGet("colors.lightMediumColor", "#F3F3F3")};
        }
      }

      @media only screen and (min-width: 991px) and (max-width: 1200px) {
        .buttonText {
          display: none;
        }
      }
    }
  }

  .popover-wrapper {
    .popover-content {
      padding: 20px 0;

      .menu-item {
        a {
          margin: 0;
          padding: 12px 30px;
          border-bottom: 1px solid ${themeGet("colors.lightColor", "#F7F7F7")};
          cursor: pointer;
          &:last-child {
            border-bottom: 0;
          }
          &:hover {
            color: ${themeGet("colors.primary", "#009E7F")};
          }
          &.current-page {
            color: ${themeGet("colors.primary", "#009E7F")};
          }

          .menu-item-icon {
            margin-right: 15px;
            
            svg {
              width="3em";
              height="3em";
            }
          }
        }
      }
    }
  }

  .headerSearch {
    input {
      @media (max-width: 1400px) {
        padding: 0 15px;
        font-size: 15px;
      }

      @media only screen and (min-width: 991px) and (max-width: 1200px) {
      }
    }
    button {
      @media (max-width: 1400px) {
        padding: 0 15px;
        font-size: 15px;
      }
    }
  }
`;

export const HeaderLeftSide = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-shrink: 0;
`;

export const HeaderRightSide = styled.div`
  display: flex;
  align-items: center;
  flex-shrink: 0;

  .menu-icon {
    min-width: 14px;
    margin-right: 7px;
  }

  .menu-item {
    a {
      font-family: "Source Sans Pro", sans-serif;
      font-size: ${themeGet("fontSizes.2", "15")}px;
      font-weight: ${themeGet("fontWeights.6", "500")};
      color: ${themeGet("colors.darkBold", "#0D1136")};
      line-height: 1.2em;
      display: block;
      transition: 0.15s ease-in-out;
      display: flex;
      align-items: center;
      margin-right: 45px;

      @media (max-width: 1400px) {
        margin-right: 35px;
        font-size: 15px;
      }
      &:hover {
        color: ${themeGet("colors.primary", "#009E7F")};
      }
      &.current-page {
        color: ${themeGet("colors.primary", "#009E7F")};
      }
    }
  }

  .user-pages-dropdown {
    .popover-handler {
      width: 38px;
      height: 38px;
      border-radius: 50%;
      display: block;
      overflow: hidden;
      img {
        width: 100%;
        height: auto;
        display: block;
      }
    }

    .popover-content {
      .inner-wrap {
        padding: ;
      }
    }
  }
`;

export const MainMenu = styled.div`
  display: flex;
  align-items: center;

  .popover-wrapper {
    .popover-content {
      .menu-item {
        font-family: "Source Sans Pro", sans-serif;
        a {
          font-size: 15px;
          font-weight: 500;
          color: ${themeGet("colors.darkBold", "#0D1136")};
          line-height: 1.2em;
          display: block;
          padding: 15px 30px;
          border-radius: 6px;
          transition: 0.15s ease-in-out;
          display: flex;
          align-items: center;
          @media (max-width: 1400px) {
            margin-right: 10px;
            font-size: 15px;
          }

          @media only screen and (min-width: 991px) and (max-width: 1200px) {
            padding: 15px 30px;
          }

          &:hover {
            color: ${themeGet("colors.primary", "#009E7F")};
          }
          &.current-page {
            color: ${themeGet("colors.primary", "#009E7F")};
            background-color: #fff;
          }
        }
      }
    }
  }
`;

export const SelectedType = styled.button`
  width: auto;
  height: 38px;
  display: flex;
  align-items: center;
  background-color: ${themeGet("colors.white", "#ffffff")};
  border: 1px solid ${themeGet("colors.borderColor", "#f1f1f1")};
  padding-top: 0;
  padding-bottom: 0;
  padding-left: ${themeGet("space.4", "15")}px;
  padding-right: ${themeGet("space.4", "15")}px;
  border-radius: ${themeGet("radius.3", "6")}px;
  outline: 0;
  min-width: 150px;

  span {
    display: flex;
    align-items: center;
    font-family: "Source Sans Pro", sans-serif;
    font-size: ${themeGet("fontSizes.2", "15")}px;
    font-weight: ${themeGet("fontWeights.6", "500")};
    color: ${themeGet("colors.primary", "#009E7F")};
    text-decoration: none;

    &:first-child {
      margin-right: auto;
    }
  }
`;

export const DropDownArrow = styled.span`
  width: 12px;
  margin-left: 16px;
`;

export const SelectedLang = styled.button`
  width: auto;
  height: 38px;
  display: flex;
  align-items: center;
  background-color: ${themeGet("colors.white", "#ffffff")};
  border: 1px solid ${themeGet("colors.borderColor", "#f1f1f1")};
  padding-top: 0;
  padding-bottom: 0;
  border-radius: ${themeGet("radius.3", "6")}px;
  outline: 0;

  span {
    display: flex;
    align-items: center;
    font-family: "Source Sans Pro", sans-serif;
    font-size: ${themeGet("fontSizes.2", "15")}px;
    font-weight: ${themeGet("fontWeights.6", "500")};
    color: ${themeGet("colors.primary", "#009E7F")};
    text-decoration: none;

    &:first-child {
      margin-right: auto;
    }
  }
`;

export const LanguageItem = styled.button`
  width: 100%;
  font-size: 15px;
  font-weight: 500;
  color: ${themeGet("colors.darkBold", "#0D1136")};
  line-height: 1.2em;
  display: block;
  padding: 15px 30px;
  border-radius: 6px;
  transition: 0.15s ease-in-out;
  display: flex;
  align-items: center;
  border: 0;
  border-bottom: 1px solid ${themeGet("colors.borderColor", "#f1f1f1")};
  border-radius: 0;
  background-color: transparent;
  outline: 0;
  cursor: pointer;

  &:last-child {
    border-bottom: 0;
  }

  @media (max-width: 1400px) {
    margin-right: 10px;
    font-size: 15px;
  }

  @media only screen and (min-width: 991px) and (max-width: 1200px) {
    padding: 15px 30px;
  }

  span {
    display: flex;
    align-items: center;
    justify-content: center;
    border-radius: 2px;
    overflow: hidden;
    margin-right: 15px;

    svg {
      display: block;
      width: 20px;
      height: auto;
    }
  }
`;

export const LangSwithcer = styled.div`
  margin-right: 20px;

  .popover-wrapper.right {
    .popover-content {
      padding: 15px 0;
    }
  }
`;

export const Flag = styled.div`
  margin: 0px 5px;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 2px;
  overflow: hidden;
  svg {
    width: 20px;
    height: auto;
  }
`;

export default HeaderWrapper;
