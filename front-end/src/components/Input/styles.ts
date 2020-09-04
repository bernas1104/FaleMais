/* eslint-disable @typescript-eslint/no-unused-vars */

import styled, { css } from 'styled-components';

interface ContainerProps {
  isFocused: boolean;
  isFilled: boolean;
}

export const Container = styled.div<ContainerProps>`
  border-radius: 4px;
  border: 1px solid rgba(51, 51, 51, 0.4);

  flex: 1;
  display: flex;
  position: relative;
  flex-direction: row;
  align-items: center;

  transition: all 280ms cubic-bezier(0.4, 0, 0.2, 1);

  &:hover {
    border-color: rgba(51, 51, 51, 1);
  }

  svg {
    margin: 10px;
    opacity: 0.7;
  }

  label {
    top: 13px;
    left: 40px;
    position: absolute;

    transition: all 0.28s;
  }

  input {
    width: 100%;
    border: 0;
    font-weight: 300;
    font-size: 1.25rem;
    background: transparent;
    padding: 10px 10px 10px 0;
  }

  ${props =>
    (props.isFocused || props.isFilled) &&
    css`
      label {
        top: -8px;
        left: 10px;
        font-size: 0.8rem;
        background: #f5f5f5;
      }
    `}
`;
