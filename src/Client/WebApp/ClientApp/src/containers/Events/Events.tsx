import React from "react";
import ProductCard from "../../components/EventCard/EventCard";
import {
  ProductsRow,
  ProductsCol,
  LoaderWrapper,
  LoaderItem,
  ProductCardWrapper
} from "./Events.style";
import { useQuery } from "@apollo/react-hooks";
import Placeholder from "../../components/Placeholder/Placeholder";
import Fade from "react-reveal/Fade";
import NoResultFound from "../../components/NoResult/NoResult";
import { GET_EVENTS } from "../../graphql/query/event.query";

type ProductsProps = {
  deviceType?: {
    mobile: boolean;
    tablet: boolean;
    desktop: boolean;
  };
  type: string;
  fetchLimit?: number;
  loadMore?: boolean;
};
export const Events: React.FC<ProductsProps> = ({
  deviceType,
  type,
  fetchLimit = 12
}) => {
  const { data, error, loading } = useQuery(GET_EVENTS);

  if (loading) {
    return (
      <LoaderWrapper>
        <LoaderItem>
          <Placeholder />
        </LoaderItem>
        <LoaderItem>
          <Placeholder />
        </LoaderItem>
        <LoaderItem>
          <Placeholder />
        </LoaderItem>
      </LoaderWrapper>
    );
  }

  if (error) return <div>{error.message}</div>;
  if (!data || !data.events || data.events.length === 0) {
    return <NoResultFound />;
  }

  return (
    <>
      <ProductsRow>
        {data.events.map((item: any, index: number) => (
          <ProductsCol key={index}>
            <ProductCardWrapper>
              <Fade
                duration={800}
                delay={index * 10}
                style={{ height: "100%" }}
              >
                <ProductCard
                  title={item.name}
                  description={item.description}
                  image={item.image}
                  data={item}
                  deviceType={deviceType}
                  onClick={() => {}}
                />
              </Fade>
            </ProductCardWrapper>
          </ProductsCol>
        ))}
      </ProductsRow>
    </>
  );
};
export default Events;

