import styled from "styled-components";
import { Form } from "@unform/web";
import { Link } from "react-router-dom";

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

export const MidleDiv = styled.div`
  margin-top: -22px;
  width: 100%;
  max-height: 52px;
  display: flex;
  align-items: center;
`;
export const LinkTo = styled(Link)`
  text-decoration: none;
  margin-right: 20px;
  text-align: end;
  width: 100%;
  font: 600 0.8rem Nunito;
  color: var(--primary-input-text);
`;
