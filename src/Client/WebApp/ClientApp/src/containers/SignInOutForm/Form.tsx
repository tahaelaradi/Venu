import React, { useContext } from "react";
import SignInForm from "./SignIn";
import SignUpForm from "./SignUp";
import { AuthContext } from "../../contexts/auth/auth.context";

export default function AuthenticationForm() {
  const { authState } = useContext<any>(AuthContext);
  let RenderForm;

  if (authState.currentForm === "signIn") {
    RenderForm = SignInForm;
  }

  if (authState.currentForm === "signUp") {
    RenderForm = SignUpForm;
  }

  return <RenderForm />;
}
