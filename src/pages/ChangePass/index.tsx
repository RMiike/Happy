import React from "react";
import { FormContent, Title, DescriptionTitle } from "./styles";
import { FiLock } from "react-icons/fi";
import Input from "../../components/Form/Input";
import Button from "../../components/Form/Button";
import AuthPage from "../../components/AuthPage";

// import { Container } from './styles';

const ChangePass: React.FC = () => {
  return (
    <AuthPage>
      <FormContent onSubmit={() => {}}>
        <Title>Redefinição de senha</Title>
        <DescriptionTitle>
          Escolha uma nova senha para você acessar o dashboard do Happy
        </DescriptionTitle>
        <Input label="Nova senha" name="new-password" type="password">
          <FiLock size={22} color="#8fa7b2" />
        </Input>
        <Input label="Confirme a senha" name="confirm-password" type="password">
          <FiLock size={22} color="#8fa7b2" />
        </Input>
        <Button type="submit">Entrar</Button>
      </FormContent>
    </AuthPage>
  );
};

export default ChangePass;
