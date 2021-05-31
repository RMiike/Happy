import React from "react";
import { Container, LeftSide, RightSide, Logo } from "./styles";
import logotipo from "../../assets/images/Logotipo.svg";

const AuthPage: React.FC = ({ children }) => {
  return (
    <Container>
      <LeftSide>
        <Logo src={logotipo} alt="Happy" />
        <p>Rio do Sul</p>
        <p>Santa Catarina</p>
      </LeftSide>
      <RightSide>{children}</RightSide>
    </Container>
  );
};

export default AuthPage;
