import React from "react";
import Image from "../../components/Image/Image";
import {
  EventCardWrapper,
  EventImageWrapper,
  EventInfo
} from "./EventCard.style";

type ProductCardProps = {
  title: string;
  image: any;
  data: any;
  onClick?: (e: any) => void;
  deviceType?: any;
};

const EventCard: React.FC<ProductCardProps> = ({
  title,
  image,
  onClick,
}) => {
  return (
    <EventCardWrapper onClick={onClick} className="product-card">
      <EventImageWrapper>
        <Image
          url={image}
          className="event-image"
          style={{ position: "relative" }}
          alt={title}
        />
      </EventImageWrapper>
      <EventInfo>
        <h3 className="event-title">{title}</h3>
      </EventInfo>
    </EventCardWrapper>
  );
};

export default EventCard;
