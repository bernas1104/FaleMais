/* eslint-disable @typescript-eslint/no-unused-vars */

import styled, { css } from 'styled-components';

interface ContainerProps {
  selectActive: boolean;
  isSelected: boolean;
  enabled: boolean;
}

interface OverlayProps {
  selectActive: boolean;
}

interface OptionsProps {
  selectActive: boolean;
}

export const Container = styled.div<ContainerProps>`
  border-radius: 4px;
  border: 1px solid rgba(51, 51, 51, 0.4);

  flex: 1;
  height: 46px;
  display: flex;
  position: relative;
  flex-direction: row;
  align-items: center;

  transition: all 280ms cubic-bezier(0.4, 0, 0.2, 1);

  svg {
    margin: 10px;
  }

  span {
    flex: 1;
  }

  label {
    top: 11px;
    left: 40px;
    position: absolute;

    transition: all 0.28s;
  }

  select {
    display: none;
  }

  ${props =>
    (props.selectActive || props.isSelected) &&
    css`
      label {
        top: -8px;
        left: 10px;
        font-size: 0.8rem;
        background: #f5f5f5;
      }
    `}

  ${props =>
    !props.enabled &&
    css`
      color: #888;
      background: #d5d5d5;
    `}

  ${props =>
    props.enabled &&
    css`
      cursor: pointer;
    `}

  &:hover {
    border-color: rgba(51, 51, 51, 1);
  }
`;

export const OptionsContainer = styled.div<OptionsProps>`
  display: none;

  ${props =>
    props.selectActive &&
    css`
      display: flex;
    `}

  position: absolute;
  top: 50%;
  left: -10px;
  cursor: default;

  z-index: 2;
  width: 103%;
  background: #f5f5f5;
  border-radius: 4px;
  box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14),
    0 1px 10px 0 rgba(0, 0, 0, 0.12);

  flex-direction: column;

  a {
    padding: 10px;

    flex: 1;
    color: #333;
    text-decoration: none;
    transition: all 280ms cubic-bezier(0.4, 0, 0.2, 1);
  }

  a:hover {
    background: #e5e5e5;
  }
`;

export const Overlay = styled.div<OverlayProps>`
  display: none;

  ${props =>
    props.selectActive &&
    css`
      display: block;
    `}

  position: fixed;
  top: 0;
  left: 0;
  cursor: default;

  z-index: 1;
  width: 100vw;
  height: 100vh;
  background: transparent;
`;
