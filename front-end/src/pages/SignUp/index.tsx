import React from "react";
import { FormContent, SignUpTitle } from "./styles";
import { FiMail, FiLock } from "react-icons/fi";
import Input from "../../components/Form/Input";
import Button from "../../components/Form/Button";
import AuthPage from "../../components/AuthPage";

const SignUp: React.FC = () => {
  return (
    <AuthPage>
      <FormContent onSubmit={() => {}}>
        <SignUpTitle>Registrar</SignUpTitle>
        <Input label="E-mail" name="email" type="email">
          <FiMail size={22} color="#8fa7b2" />
        </Input>
        <Input label="Senha" name="password" type="password">
          <FiLock size={22} color="#8fa7b2" />
        </Input>
        <Input label="Confirmar Senha" name="confirmpassword" type="password">
          <FiLock size={22} color="#8fa7b2" />
        </Input>
        <Button type="submit">Cadastrar</Button>
      </FormContent>
    </AuthPage>
  );
};

export default SignUp;
