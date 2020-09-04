import styled from 'styled-components';
import { animated } from 'react-spring';

export const Container = styled(animated.div)`
  position: relative;

  padding: 10px;
  border-radius: 6px;

  display: flex;
  flex-direction: row;
  align-items: center;
  margin-bottom: 20px;
  background: #ff7878;
  box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14),
    0 1px 10px 0 rgba(0, 0, 0, 0.12);

  button {
    border: 0;
    cursor: pointer;
    background: transparent;
  }
`;

export const Content = styled.div`
  margin: 0 20px;

  display: flex;
  flex-direction: column;

  color: #f5f5f5;

  strong {
    font-size: 0.85rem;
  }

  p {
    margin-top: 5px;
    font-size: 0.7rem;
  }
`;
