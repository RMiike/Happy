import styled from "styled-components";
import { Link } from "react-router-dom";

export const PageMap = styled.div`
  width: 100vw;
  height: 100vh;
  position: relative;
  display: flex;
  aside {
    width: 440px;
    background: linear-gradient(
      329.54deg,
      var(--primary-landing-color-one) 0%,
      var(--primary-landing-color-two) 100%
    );
    padding: 80px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    h2 {
      font-size: 48px;
      font-weight: 800;
      line-height: 42px;
      margin-top: 64px;
    }
    p {
      line-height: 28px;
      margin-top: 24px;
    }
    footer {
      display: flex;
      flex-direction: column;
      line-height: 24px;

      strong {
        font-weight: 800;
      }
    }
  }
`;
export const CreateOrphanage = styled(Link)`
  position: absolute;
  right: 40px;
  bottom: 40px;
  width: 64px;
  height: 64px;
  background: var(--primary-buttom-color-two);
  border-radius: 20px;
  display: flex;
  justify-content: center;
  align-items: center;
  transition: background-color 0.2s;
  &&:hover {
    background: var(--secondary-buttom-color-two);
  }
`;
