import React from "react";
import StoreNav from "../../components/StoreNav/StoreNav";
import { openModal, Modal } from "@redq/reuse-modal";

import {
  MainContentArea,
  SidebarSection,
  ContentSection,
  OfferSection,
  MobileCarouselDropdown
} from "../../styled/pages.style";

const PAGE_TYPE = "home_page";

function HomePage({ deviceType }) {
  const targetRef = React.useRef(null);

  return (
    <>
      <header>
        <title>Venu</title>
      </header>
      <Modal>
        {deviceType.desktop ? (
          <>
            <MobileCarouselDropdown>
              <StoreNav />
            </MobileCarouselDropdown>
            <MainContentArea>
              <SidebarSection></SidebarSection>
              <ContentSection>
                <div ref={targetRef}></div>
              </ContentSection>
            </MainContentArea>
          </>
        ) : (
          <MainContentArea>
            <StoreNav />
            <OfferSection>
              <div style={{ margin: "0px" }}></div>
            </OfferSection>
            <ContentSection style={{ width: "100%" }}></ContentSection>
          </MainContentArea>
        )}
      </Modal>
    </>
  );
}

export default HomePage;
