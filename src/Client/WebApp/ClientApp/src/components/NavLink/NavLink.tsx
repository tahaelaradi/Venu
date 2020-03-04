import React from "react";
import styled from "styled-components";
import { FormattedMessage } from "react-intl";
import { Link } from "react-router-dom";

type NavLinkProps = {
  href: string;
  label: string;
  intlId?: string;
  icon?: React.ReactNode;
  className?: string;
  iconClass?: string;
  onClick?: () => void;
};

const Icon = styled.span`
  min-width: 16px;
  margin-right: 10px;
  display: flex;
  align-items: center;
  justify-content: center;
`;

const NavLink: React.SFC<NavLinkProps> = ({
  href,
  label,
  intlId,
  icon,
  className,
  onClick,
  iconClass
}) => {
  return (
    <div onClick={onClick} className={className ? className : ""}>
      <Link to={href}>
        <a
          /*className={pathname === href ? ' current-page' : ''}*/
          style={{ display: "flex", alignItems: "center" }}
        >
          {icon ? <Icon className={iconClass}>{icon}</Icon> : ""}

          <span className="label">
            {intlId ? (
              <FormattedMessage
                id={intlId ? intlId : "defaultNavLinkId"}
                defaultMessage={label}
              />
            ) : (
              label
            )}
          </span>
        </a>
      </Link>
    </div>
  );
};

export default NavLink;
