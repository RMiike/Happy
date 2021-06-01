import React from "react";
import { Container, LeftSide, RightSide, Logo, BackButton } from "./styles";
import logotipo from "../../assets/images/Logotipo.svg";
import { FiArrowLeft } from "react-icons/fi";
import { useHistory } from "react-router-dom";

const AuthPage: React.FC = ({ children }) => {
  const { goBack } = useHistory();
  function handleGoBack() {
    goBack();
  }
  return (
    <Container>
      <LeftSide>
        <Logo src={logotipo} alt="Happy" />
        <p>Rio do Sul</p>
        <p>Santa Catarina</p>
      </LeftSide>
      <RightSide>{children}</RightSide>
      <BackButton>
        <FiArrowLeft onClick={handleGoBack} size={26} color="#15C3D6" />
      </BackButton>
    </Container>
  );
};

export default AuthPage;
