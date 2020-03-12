import React from "react";
import StoreNav from "../../components/StoreNav/StoreNav";
import { Modal } from "@redq/reuse-modal";

import {
  MainContentArea,
  ContentSection,
  MobileCarouselDropdown
} from "../../styled/pages.style";
import Events from "../../containers/Events/Events";

const PAGE_TYPE = "home_page";

function HomePage({ deviceType }) {
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
              <ContentSection>
                <Events
                  type={PAGE_TYPE}
                  deviceType={deviceType}
                  fetchLimit={16}
                />
              </ContentSection>
            </MainContentArea>
          </>
        ) : (
          <MainContentArea>
            <StoreNav />
            <ContentSection style={{ width: "100%" }}>
              <Events
                type={PAGE_TYPE}
                deviceType={deviceType}
                fetchLimit={16}
              />
            </ContentSection>
          </MainContentArea>
        )}
      </Modal>
    </>
  );
}

export default HomePage;
