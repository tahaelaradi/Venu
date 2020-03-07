import React, { useContext } from "react";
import {
  LinkButton,
  Button,
  Wrapper,
  Container,
  Heading,
  SubHeading,
  Offer,
  Input,
  Divider
} from "./SignInOutForm.style";
import { FormattedMessage } from "react-intl";
import { closeModal } from "@redq/reuse-modal";
import { AuthContext } from "../../contexts/auth/auth.context";
import { userService } from "../../services/user.service";

export default function SignInModal() {
  const { authDispatch } = useContext<any>(AuthContext);
  const [email, setEmail] = React.useState("");
  const [password, setPassword] = React.useState("");

  const toggleSignUpForm = () => {
    authDispatch({
      type: "SIGNUP"
    });
  };

  const loginCallback = () => {
    if (typeof window !== "undefined") {
      userService
        .login(email, password)
        .then(result => {
          localStorage.setItem("venu_token", `${result.token}`);
          authDispatch({ type: "SIGNIN_SUCCESS" });
        })
        .catch(e => console.log(e));
      closeModal();
    }
  };

  return (
    <Wrapper>
      <Container>
        <Heading>
          <FormattedMessage id="welcomeBack" defaultMessage="Welcome Back" />
        </Heading>

        <SubHeading>
          <FormattedMessage
            id="loginText"
            defaultMessage="Login with your email &amp; password"
          />
        </SubHeading>
        <form onSubmit={loginCallback}>
          <FormattedMessage
            id="emailAddressPlaceholder"
            defaultMessage="Email Address."
          >
            {placeholder => (
              <Input
                type="email"
                placeholder={placeholder}
                value={email}
                onChange={e => setEmail(e.target.value)}
                required
              />
            )}
          </FormattedMessage>

          <FormattedMessage
            id="passwordPlaceholder"
            defaultMessage="Password (min 6 characters)"
          >
            {placeholder => (
              <Input
                type="password"
                placeholder={placeholder}
                value={password}
                onChange={e => setPassword(e.target.value)}
                required
              />
            )}
          </FormattedMessage>

          <Button
            fullwidth
            title={"Continue"}
            intlButtonId="continueBtn"
            type="submit"
            style={{ color: "#fff" }}
          />
        </form>
        <Divider />

        <Offer style={{ padding: "20px 0" }}>
          <FormattedMessage
            id="dontHaveAccount"
            defaultMessage="Not on Venu yet?"
          />{" "}
          <LinkButton onClick={toggleSignUpForm}>
            <FormattedMessage id="signUpBtnText" defaultMessage="Sign Up" />
          </LinkButton>
        </Offer>
      </Container>
    </Wrapper>
  );
}
