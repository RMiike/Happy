import styled from "styled-components";

export const Container = styled.button`
  width: 100%;
  height: 64px;
  background: var(--tertiary-button-color-two);
  border-radius: 20px;
  justify-content: center;
  align-items: center;
  color: var(--color-text);
  font: 700 1rem Nunito;
  opacity: 0.5;
  border: 0;
  &:hover {
    opacity: 1;
    transition: 0.8s;
  }
`;
