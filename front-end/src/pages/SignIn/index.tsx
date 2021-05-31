import React from "react";
import { FormContent, SignInTitle, MidleDiv, LinkTo } from "./styles";
import { FiMail, FiLock } from "react-icons/fi";
import Input from "../../components/Form/Input";
import CheckBox from "../../components/Form/Checkbox";
import Button from "../../components/Form/Button";
import AuthPage from "../../components/AuthPage";

const SignIn: React.FC = () => {
  return (
    <AuthPage>
      <FormContent onSubmit={() => {}}>
        <SignInTitle>Fazer login</SignInTitle>
        <Input label="E-mail" name="email" type="email">
          <FiMail size={22} color="#8fa7b2" />
        </Input>
        <Input label="Senha" name="password" type="password">
          <FiLock size={22} color="#8fa7b2" />
        </Input>
        <MidleDiv>
          <CheckBox type="checkbox" name="checkbox" onChange={() => {}}>
            <p>Lembrar-me</p>
          </CheckBox>
          <LinkTo to="/forgot_password">Esqueci minha senha</LinkTo>
        </MidleDiv>
        <Button type="submit">Entrar</Button>
      </FormContent>
    </AuthPage>
  );
};

export default SignIn;
