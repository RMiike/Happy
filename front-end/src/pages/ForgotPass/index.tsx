import React from "react";
import { FormContent, Title, DescriptionTitle } from "./styles";
import { FiMail } from "react-icons/fi";
import Input from "../../components/Form/Input";
import Button from "../../components/Form/Button";
import AuthPage from "../../components/AuthPage";

// import { Container } from './styles';

const ForgotPass: React.FC = () => {
  return (
    <AuthPage>
      <FormContent onSubmit={() => {}}>
        <Title>Esqueci a senha</Title>
        <DescriptionTitle>
          Sua redefinição de senha será enviada para o e-mail cadastrado.
        </DescriptionTitle>
        <Input label="E-mail" name="email" type="email">
          <FiMail size={22} color="#8fa7b2" />
        </Input>
        <Button type="submit">Entrar</Button>
      </FormContent>
    </AuthPage>
  );
};

export default ForgotPass;
