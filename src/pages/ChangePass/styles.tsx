import styled from "styled-components";
import { Form } from "@unform/web";

export const FormContent = styled(Form)`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 352px;
  height: 430px;
`;

export const Title = styled.h3`
  width: 100%;
  color: var(--tertiary-text-color);
  font: 800 2.1rem Nunito;
  text-align: left;
  margin-bottom: 10px;
`;
export const DescriptionTitle = styled.p`
  width: 100%;
  color: var(--tertiary-text-color);
  font: 600 1.1rem Nunito;
  text-align: left;
  margin-bottom: 20px;
`;
