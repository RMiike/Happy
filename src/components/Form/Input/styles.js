import styled from "styled-components/";

export const Label = styled.label`
  color: var(--primary-input-text);
  font: 700 1rem Nunito;
  width: 100%;
  text-align: left;
  margin: 0 0 8px 25px;
`;
export const Container = styled.div`
  display: grid;
  position: relative;
  grid-template-columns: 1fr 5fr;
  align-items: center;
  width: 100%;
  height: 64px;
  background: var(--primary-input-background);
  border-radius: 20px;
  margin-bottom: 26px;
  border: 1px solid var(--primary-border);
  font: 400 1.6rem Nunito;
  color: var(--color-input-text);
`;

export const IconContainer = styled.div`
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
`;

export const ContentInp = styled.input`
  width: 100%;
  background: var(--primary-input-background);
  border-width: 0;
  outline: none;
  font: 700 1rem Nunito;
  color: var(--tertiary-text-color);
`;
