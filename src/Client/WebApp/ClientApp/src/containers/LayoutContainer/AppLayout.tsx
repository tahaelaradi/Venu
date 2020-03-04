import React, { FunctionComponent } from "react";
import Sticky from "react-stickynode";
import styled from "styled-components";

import Header from "./Header/Header";

import { useStickyState } from "../../contexts/app/app.provider";
import { routes } from "../../constants";

const LayoutWrapper = styled.div`
  background-color: #f7f7f7;

  .reuseModalHolder {
    padding: 0;
    overflow: auto;
    border-radius: 3px 3px 0 0;
    border: 0;
  }
`;

type LayoutProps = {
  className?: string;
  deviceType: {
    mobile: boolean;
    tablet: boolean;
    desktop: boolean;
  };
  token?: string;
};

const Layout: FunctionComponent<LayoutProps> = ({
  className,
  children,
  deviceType: { mobile, tablet, desktop },
  token
}) => {
  const isSticky = useStickyState("isSticky");
  const isHomePage = window.location.pathname === routes.HOME_PAGE;

  return (
    <LayoutWrapper className={`layoutWrapper ${className}`}>
      {(mobile || tablet) && <Sticky enabled={isSticky} innerZ={1001} />}

      {desktop && (
        <Sticky enabled={isSticky} innerZ={1001}>
          <Header
            className={`${isSticky ? "sticky" : "unSticky"}`}
            token={token}
            pathname={"/"}
          />
        </Sticky>
      )}
      {children}
    </LayoutWrapper>
  );
};

export default Layout;
