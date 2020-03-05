import React, { useContext } from "react";
import LanguageContext from "../../../contexts/language/language.context";

import { Link } from "react-router-dom";
import { FormattedMessage } from "react-intl";
import { Icon } from "@iconify/react";

import NavLink from "../../../components/NavLink/NavLink";
import Popover from "../../../components/Popover/Popover";
import Button from "../../../components/Button/Button";
import HeaderWrapper, {
  HeaderLeftSide,
  HeaderRightSide,
  MainMenu,
  SelectedType,
  DropDownArrow,
  SelectedLang,
  LanguageItem,
  LangSwithcer,
  Flag
} from "./Header.style";

import { Icons, routes } from "../../../constants/";
import UserImage from "../../../image/user.jpg";
import { AuthContext } from "../../../contexts/auth";

type HeaderProps = {
  style?: any;
  className?: string;
};

const MenuArray = [
  {
    link: routes.SPORTS_EVENTS_PAGE,
    icon: <Icon icon={Icons.SportsIcon} width={"2em"} height={"2em"} />,
    label: "Sports",
    intlId: "sportslinkHeaderMenu"
  }
];

const DropDownMenuArray = [
  {
    link: routes.ACCOUNT_PAGE,
    label: "Profile",
    intlId: "navlinkProfile"
  }
];

const LanguageArray = [
  {
    id: "ar",
    label: "Arabic",
    intlLangName: "intlArabic",
    icon: <Icon icon={Icons.ARFlag} />
  },
  {
    id: "en",
    label: "English",
    intlLangName: "intlEnglish",
    icon: <Icon icon={Icons.USFlag} />
  },
  {
    id: "es",
    label: "Spanish",
    intlLangName: "intlSpanish",
    icon: <Icon icon={Icons.ESFlag} />
  }
];

const Header: React.FC<HeaderProps> = ({ style, className }) => {
  const { isAuthenticated } = useContext(AuthContext);

  const {
    state: { lang },
    toggleLanguage
  } = useContext<any>(LanguageContext);
  const selectedLangindex = LanguageArray.findIndex(x => x.id === lang);

  const handleLogout = () => {
    if (typeof window !== "undefined") {
      localStorage.removeItem("access_token");
      // authDispatch({ type: 'SIGN_OUT' });
    }
  };

  const handleToggleLanguage = e => {
    toggleLanguage(e.target.value);
  };

  const LanguageMenu = (item: any) => {
    return (
      <LanguageItem
        onClick={handleToggleLanguage}
        key={item.id}
        value={item.id}
      >
        <span>{item.icon}</span>
        <FormattedMessage id={item.intlLangName} defaultMessage={item.label} />
      </LanguageItem>
    );
  };

  const NavItem = (item: any) => {
    return (
      <NavLink
        key={item.link}
        // TODO:
        // onClick={() => ... }
        className="menu-item"
        href={item.link}
        label={item.label}
        icon={item.icon}
        iconClass="menu-item-icon"
      />
    );
  };

  const FormattedNavItem = (item: any) => {
    return (
      <FormattedMessage id={item.intlId}>
        {() => (
          <NavLink
            key={item.link}
            // TODO:
            // onClick={() => ... }
            className="menu-item"
            href={item.link}
            label={item.label}
            icon={item.icon}
            iconClass="menu-item-icon"
            intlId={item.intlId}
          />
        )}
      </FormattedMessage>
    );
  };

  return (
    <HeaderWrapper style={style} className={className}>
      <HeaderLeftSide>
        <Link to={routes.HOME_PAGE}>
          <div>Venu {/* TODO: Add Logo img Here Instead */}</div>
        </Link>
        <MainMenu>
          <Popover
            className="right"
            handler={
              <SelectedType>
                <span>
                  <span>Categories</span>
                </span>
                <DropDownArrow>
                  <Icon icon={Icons.ArrowDown} width={"2em"} height={"2em"} />
                </DropDownArrow>
              </SelectedType>
            }
            content={<>{MenuArray.map(FormattedNavItem)}</>}
          />
        </MainMenu>
      </HeaderLeftSide>
      <HeaderRightSide>
        <NavLink className="menu-item" href={routes.HOME_PAGE} label="Browse" />
        <LangSwithcer>
          <Popover
            className="right"
            handler={
              <SelectedLang>
                <Flag>{LanguageArray[selectedLangindex].icon}</Flag>
                <span>
                  <FormattedMessage
                    id={LanguageArray[selectedLangindex].intlLangName}
                    defaultMessage={LanguageArray[selectedLangindex].label}
                  />
                </span>
              </SelectedLang>
            }
            content={<>{LanguageArray.map(LanguageMenu)}</>}
          />
        </LangSwithcer>
        {!isAuthenticated ? (
          <Button
            // onClick={signInOutForm}
            size="small"
            title="Log in"
            style={{ fontSize: 15, color: "#fff" }}
            intlButtonId="joinButton"
          />
        ) : (
          <Popover
            direction="right"
            className="user-pages-dropdown"
            handler={<img src={UserImage} alt="user" />}
            content={
              <>
                {DropDownMenuArray.map((item, idx) => (
                  <NavLink
                    key={idx}
                    className="menu-item"
                    href={item.link}
                    label={item.label}
                    intlId={item.intlId}
                  />
                ))}
                <div className="menu-item" onClick={handleLogout} />
              </>
            }
          />
        )}
      </HeaderRightSide>
    </HeaderWrapper>
  );
};

export default Header;
