import styled from "styled-components";
import { Form } from "@unform/web";
import { Link } from "react-router-dom";

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
export const MidleDiv = styled.div`
  margin-top: -22px;
  width: 100%;
  max-height: 52px;
  display: flex;
  align-items: center;
`;
export const LinkToForgot = styled(Link)`
  text-decoration: none;
  margin-right: 20px;
  text-align: end;
  width: 100%;
  font: 600 0.8rem Nunito;
  color: var(--primary-input-text);
`;
export const LinkToRegister = styled(Link)`
  text-decoration: none;
  margin-top: 20px;
  text-align: center;
  width: 100%;
  font: 600 0.8rem Nunito;
  color: var(--primary-input-text);
`;
