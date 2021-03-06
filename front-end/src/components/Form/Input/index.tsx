import React, { useEffect, useRef, InputHTMLAttributes } from "react";
import { useField } from "@unform/core";
import { Container, ContentInp, IconContainer, Label } from "./styles";

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
  name: string;
  label: string;
  value?: string;
}

const Input: React.FC<InputProps> = ({
  name,
  label,
  value,
  children,
  ...rest
}) => {
  const inputRef = useRef<any>(null);
  const { fieldName, defaultValue, registerField, error } = useField(name);
  useEffect(() => {
    registerField({
      name: fieldName,
      ref: inputRef.current,
      path: "value",
    });
  }, [fieldName, registerField]);
  return (
    <>
      <Label>{label}</Label>
      <Container>
        {error && (
          <span
            style={{
              position: "absolute",
              color: "#f7b37e",
              top: -15,
              left: 35,
              font: "700 1.2rem Nunito",
            }}
          >
            {error}
          </span>
        )}
        <IconContainer>{children}</IconContainer>
        <ContentInp
          id={name}
          {...rest}
          defaultValue={value ? value : defaultValue}
          ref={inputRef}
        />
      </Container>
    </>
  );
};

export default Input;
