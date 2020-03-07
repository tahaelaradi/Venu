import React, { useContext } from "react";
import {
  Button,
  Wrapper,
  Container,
  Heading,
  SubHeading,
  Offer,
  Input,
  Divider,
  LinkButton
} from "./SignInOutForm.style";
import { AuthContext } from "../../contexts/auth/auth.context";
import { FormattedMessage } from "react-intl";

export default function SignUpModal() {
  const { authDispatch } = useContext<any>(AuthContext);

  const toggleSignInForm = () => {
    authDispatch({
      type: "SIGNIN"
    });
  };

  return (
    <Wrapper>
      <Container>
        <Heading>
          <FormattedMessage id="signUpBtnText" defaultMessage="Sign Up" />
        </Heading>

        <SubHeading>
          <FormattedMessage
            id="signUpText"
            defaultMessage="Every fill is required in sign up"
          />
        </SubHeading>

        <FormattedMessage
          id="emailAddressPlaceholder"
          defaultMessage="Email Address"
        >
          {placeholder => <Input type="text" placeholder={placeholder} />}
        </FormattedMessage>

        <FormattedMessage
          id="passwordPlaceholder"
          defaultMessage="Password (min 6 characters)"
        >
          {placeholder => <Input type="email" placeholder={placeholder} />}
        </FormattedMessage>

        <Button
          fullwidth
          title={"Continue"}
          intlButtonId="continueBtn"
          style={{ color: "#fff" }}
        />

        <Divider />

        <Offer style={{ padding: "20px 0" }}>
          <FormattedMessage
            id="alreadyHaveAccount"
            defaultMessage="Already have an account?"
          />{" "}
          <LinkButton onClick={toggleSignInForm}>
            <FormattedMessage id="loginBtnText" defaultMessage="Login" />
          </LinkButton>
        </Offer>
      </Container>
    </Wrapper>
  );
}
