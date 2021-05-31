import styled from "styled-components/";

export const Container = styled.div`
  display: grid;
  grid-template-columns: 1fr 2fr;
  align-items: center;
  width: 100%;
  height: 52px;
  border-radius: 8px;
  border-width: 2px;
  font: 600 0.8rem Nunito;
  color: var(--primary-input-text);
  p {
    font: 600 0.8rem Nunito;
    color: var(--primary-input-text);
    width: 100%;
  }
`;

export const TextLabel = styled.div`
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
`;

export const Content = styled.input`
  width: 100%;
  color: var(--primary-input-text);
`;
