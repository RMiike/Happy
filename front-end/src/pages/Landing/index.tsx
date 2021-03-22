import React from "react";
import logoImg from "../../assets/images/logo.svg";
import { FiArrowRight } from "react-icons/fi";
import { LandingPage, ContentWrapper, Location, EnterApp } from "./styles";

const Landing: React.FC = () => {
  return (
    <LandingPage>
      <ContentWrapper>
        <img src={logoImg} alt="Happy Logo" />
        <main>
          <h1>Leve felicidade para o mundo</h1>
          <p>Visite orfanatos e mude o dia de muitas crianças.</p>
          <Location>
            <strong>Taguatinga</strong>
            <span>Distrito Federal</span>
          </Location>
          <EnterApp to="/app" className="enter-app">
            <FiArrowRight size={26} color="rgba(0,0,0,0.6)" />
          </EnterApp>
        </main>
      </ContentWrapper>
    </LandingPage>
  );
};

export default Landing;
