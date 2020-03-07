import styled from 'styled-components';
import { themeGet } from '@styled-system/theme-get';
import Buttons from '../../components/Button/Button';

export const Button = styled(Buttons)`
  &.google {
    background-color: #4285f4;
  }

  &.facebook {
    background-color: #4267b2;
    margin-bottom: 10px;
  }
`;

export const Wrapper = styled.div`
  text-align: center;
  background-color: #fff;
`;

export const Container = styled.div`
  padding: 40px 60px 0;

  @media (max-width: 768px) {
    padding: 40px 30px 0;
  }
`;

export const Heading = styled.h3`
  color: ${themeGet('colors.primary', '#009E7F')};
  margin-bottom: 10px;
  font-family: 'Poppins', sans-serif;
  font-size: ${themeGet('fontSizes.4', '21')}px;
  font-weight: ${themeGet('fontWeights.6', '700')};
`;

export const SubHeading = styled.span`
  margin-bottom: 30px;
  font-family: 'Source Sans Pro', sans-serif;
  font-size: ${themeGet('fontSizes.2', '15')}px;
  font-weight: ${themeGet('fontWeights.3', '400')};
  color: ${themeGet('colors.darkRegular', '#77798c')};
  display: block;
`;

export const Offer = styled.p`
  font-family: 'Source Sans Pro', sans-serif;
  font-size: ${themeGet('fontSizes.2', '15')}px;
  font-weight: ${themeGet('fontWeights.3', '400')};
  margin: 0;
`;

export const Input = styled.input`
  width: 100%;
  height: 38px;
  border-radius: 6px;
  background-color: ${themeGet('colors.lightColor', '#F7F7F7')};
  border: 1px solid ${themeGet('colors.borderColor', '#E6E6E6')};
  font-family: 'Source Sans Pro', sans-serif;
  font-size: ${themeGet('fontSizes.2', '15')}px;
  font-weight: ${themeGet('fontWeights.3', '400')};
  color: ${themeGet('colors.darkBold', '#0D1136')};
  line-height: 19px;
  padding: 0 18px;
  box-sizing: border-box;
  transition: border-color 0.25s ease;
  margin-bottom: 10px;

  &:hover,
  &:focus {
    outline: 0;
  }

  &:focus {
    border-color: ${themeGet('colors.primary', '#009e7f')};
  }

  &::placeholder {
    color: ${themeGet('colors.darkRegular', '#77798c')};
    font-size: 14px;
  }

  &::-webkit-inner-spin-button,
  &::-webkit-outer-spin-button {
    -webkit-appearance: none;
    margin: 0;
  }

  &.disabled {
    .inner-wrap {
      cursor: not-allowed;
      opacity: 0.6;
    }
  }
`;

export const Divider = styled.div`
  padding: 15px 0;
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  position: relative;

  span {
    font-family: 'Source Sans Pro', sans-serif;
    font-size: ${themeGet('fontSizes.2', '15')}px;
    font-weight: ${themeGet('fontWeights.3', '400')};
    color: ${themeGet('colors.darkBold', '#0D1136')};
    line-height: 1;
    background-color: #fff;
    z-index: 1;
    position: relative;
    padding: 0 10px;
  }

  &::before {
    content: '';
    width: 100%;
    height: 1px;
    background-color: ${themeGet('colors.borderColor', '#E6E6E6')};
    position: absolute;
    top: 50%;
  }
`;

export const LinkButton = styled.button`
  background-color: transparent;
  border: 0;
  outline: 0;
  box-shadow: none;
  padding: 0;
  font-size: 14px;
  font-weight: 700;
  color: ${themeGet('colors.primary', '#009E7F')};
  text-decoration: underline;
  cursor: pointer;
`;
