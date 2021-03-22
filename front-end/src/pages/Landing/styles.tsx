import styled from "styled-components";
import landing from "../../assets/images/landing.svg";
import { Link } from "react-router-dom";

export const LandingPage = styled.div`
  width: 100vw;
  height: 100vh;
  background: linear-gradient(
    329.54deg,
    var(--primary-landing-color-one) 0%,
    var(--primary-landing-color-two) 100%
  );

  display: flex;
  align-items: center;
  justify-content: center;
`;

export const ContentWrapper = styled.div`
  position: relative;
  width: 100%;
  max-width: 1100px;

  height: 100%;
  max-height: 680px;

  display: flex;
  align-items: flex-start;
  flex-direction: column;
  justify-content: space-between;

  background: url(${landing}) no-repeat 80% center;
  main {
    max-width: 350px;

    h1 {
      font-size: 76px;
      font-weight: 900;
      line-height: 78px;
    }
    p {
      margin-top: 40px;
      font-size: 24px;
      line-height: 34px;
    }
  }
`;

export const Location = styled.div`
  position: absolute;
  right: 0;
  top: 0;

  font-size: 24px;
  line-height: 34px;

  display: flex;
  flex-direction: column;
  text-align: right;
  strong {
    font-weight: 800;
  }
`;

export const EnterApp = styled(Link)`
  position: absolute;
  right: 0;
  bottom: 0;

  width: 80px;
  height: 80px;
  background: var(--primary-buttom-color);
  border-radius: 30px;
  display: flex;
  align-items: center;
  justify-content: center;

  transition: background-color 0.2s;
  &&:hover {
    background: var(--secondary-buttom-color);
  }
`;
