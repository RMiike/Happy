import styled from "styled-components";
import { Form } from "@unform/web";

export const FormContent = styled(Form)`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 352px;
  height: 630px;
`;

export const SignUpTitle = styled.h3`
  width: 100%;
  color: var(--tertiary-text-color);
  font: 800 2rem Nunito;
  text-align: left;
  margin-bottom: 40px;
`;
