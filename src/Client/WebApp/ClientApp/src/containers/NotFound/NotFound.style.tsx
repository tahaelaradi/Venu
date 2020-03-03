import { styled } from "baseui";

export const NoResultWrapper = styled("div", () => ({
  width: "100%",
  minHeight: "100vh",
  display: "flex",
  flexDirection: "column",
  alignItems: "center",
  justifyContent: "center",
  padding: "50px 20px"
}));

export const NoResultMsg = styled("h3", () => ({
  fontSize: "24px",
  fontWeight: 700,
  color: "#161f6a",
  margin: "0 0 15px"
}));
