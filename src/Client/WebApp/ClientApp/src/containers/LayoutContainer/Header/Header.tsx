import React from "react";
import NavLink from "../../../components/NavLink/NavLink";
import Popover from "../../../components/Popover/Popover";
import { Link } from "react-router-dom";

import { routes } from "../../../constants";
import Button from "../../../components/Button/Button";
import HeaderWrapper, {
  HeaderLeftSide,
  HeaderRightSide,
  MainMenu,
  SelectedType,
  DropDownArrow
} from "./Header.style";

import UserImage from "../../../image/user.jpg";

type HeaderProps = {
  style?: any;
  className?: string;
  token: string;
  pathname: string;
};

const MenuArray = [
  {
    link: routes.SPORTS_EVENTS_PAGE,
    // icon: sports_icon,
    label: "Sports"
  }
];

const DropDownMenuArray = [
  {
    link: routes.ACCOUNT_PAGE,
    label: "Profile",
    intlId: "navlinkProfile"
  }
];

const Header: React.FC<HeaderProps> = ({
  style,
  className,
  token,
  pathname
}) => {
  // const { isAuthenticated } = useContext(AuthContext);
  const isAuthenticated = true;
  console.log("isAuthenticated: ", isAuthenticated);

  const handleLogout = () => {
    if (typeof window !== "undefined") {
      localStorage.removeItem("access_token");
      // authDispatch({ type: 'SIGN_OUT' });
    }
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

  return (
    <HeaderWrapper style={style} className={className}>
      <HeaderLeftSide>
        <Link to={routes.HOME_PAGE}>
          <a>Venu {/* TODO: Add Logo img Here Instead */}</a>
        </Link>
        <MainMenu>
          <Popover
            className="right"
            handler={
              <SelectedType>
                <span>
                  <span>Menu</span>
                </span>
                <DropDownArrow>{/*<MenuDown />*/}</DropDownArrow>
              </SelectedType>
            }
            content={<>{MenuArray.map(NavItem)}</>}
          />
        </MainMenu>
      </HeaderLeftSide>
      <HeaderRightSide>
        <NavLink className="menu-item" href={routes.HOME_PAGE} label="Browse" />
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
