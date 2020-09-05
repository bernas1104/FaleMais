/* eslint-disable @typescript-eslint/no-unused-vars */

import styled, { css } from 'styled-components';

interface ContainerProps {
  background?: string;
}

export const Container = styled.div<ContainerProps>`
  display: flex;

  button {
    cursor: pointer;
    border: 0;
    height: 36px;
    padding: 0 12px;
    min-width: 64px;
    border-radius: 4px;
    background: #be0021;

    ${props =>
      props.background &&
      css`
        background: ${props.background};
      `}

    flex: 1;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;

    color: #f5f5f5;
    font-size: 1rem;
    font-weight: 400;

    box-shadow: 0 3px 1px -2px rgba(0, 0, 0, 0.2),
      0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 1px 5px 0 rgba(0, 0, 0, 0.12);
    transition: all 280ms cubic-bezier(0.4, 0, 0.2, 1);

    svg {
      margin-right: 10px;
    }
  }

  button:hover {
    opacity: 0.8;
    box-shadow: 0px 2px 4px -1px rgba(0, 0, 0, 0.2),
      0px 4px 5px 0px rgba(0, 0, 0, 0.14), 0px 1px 10px 0px rgba(0, 0, 0, 0.12);
  }

  button:active {
    opacity: 0.6;
    box-shadow: 0px 5px 5px -3px rgba(0, 0, 0, 0.2),
      0px 8px 10px 1px rgba(0, 0, 0, 0.14), 0px 3px 14px 2px rgba(0, 0, 0, 0.12);
  }
`;
