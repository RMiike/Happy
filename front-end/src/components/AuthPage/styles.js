import styled from "styled-components";
import { Link } from "react-router-dom";
export const Container = styled.div`
  width: 100vw;
  height: 100vh;
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  color: var(--color-text-primary);
  background: linear-gradient(
    329.54deg,
    var(--primary-landing-color-one) 0%,
    var(--primary-landing-color-two) 100%
  );
  @media (max-width: 800px) {
    background: linear-gradient(
      329.54deg,
      var(--primary-landing-color-one) 0%,
      var(--primary-landing-color-two) 100%
    );
    flex-direction: column;
  }
`;

export const LeftSide = styled.div`
  width: 70%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;

  p {
    font: 800 26px Nunito, sans-serif;
  }
  p:last-child {
    font: 600 26px Nunito, sans-serif;
  }
  @media (max-width: 800px) {
    height: 0;
  }
`;

export const Logo = styled.img`
  width: 330px;
  margin-bottom: 100px;
`;

export const RightSide = styled.div`
  width: 30%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  position: relative;
  flex-direction: column;
  background: var(--tertiary-background-color);
  border: 1px solid var(--primary-border);
  @media (max-width: 1000px) {
    width: 70%;
  }
  @media (max-width: 800px) {
    width: 100%;
  }
`;

export const BackButton = styled.div`
  position: absolute;
  right: 43px;
  top: 40px;

  width: 48px;
  height: 48px;
  background: var(--primary-background-color);
  border-radius: 16px;
  display: flex;
  align-items: center;
  justify-content: center;

  transition: background-color 0.2s;
  &&:hover {
    background: var(--secondary-buttom-color);
  }
`;
