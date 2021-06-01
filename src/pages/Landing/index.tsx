import React from "react";
import logoImg from "../../assets/images/logo.svg";
import { FiArrowRight } from "react-icons/fi";
import {
  LandingPage,
  ContentWrapper,
  Location,
  EnterApp,
  RestrictAccess,
} from "./styles";

const Landing: React.FC = () => {
  return (
    <LandingPage>
      <ContentWrapper>
        <img src={logoImg} alt="Happy Logo" />
        <Location>
          <strong>Taguatinga</strong>
          <span>Distrito Federal</span>
        </Location>
        <main>
          <h1>Leve felicidade para o mundo</h1>
          <p>Visite orfanatos e mude o dia de muitas crianças.</p>

          <EnterApp to="/app" className="enter-app">
            <FiArrowRight size={26} color="rgba(0,0,0,0.6)" />
          </EnterApp>
          <RestrictAccess to="/signin" className="enter-app">
            Acesso restrito
          </RestrictAccess>
        </main>
      </ContentWrapper>
    </LandingPage>
  );
};

export default Landing;
