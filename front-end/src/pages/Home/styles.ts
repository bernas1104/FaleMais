import styled from 'styled-components';

export const Container = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;

  padding: 15%;
  min-height: 100vh;
`;

export const Title = styled.h1`
  text-align: center;
  margin-bottom: 50px;
`;

export const Calculator = styled.div`
  flex: 1;
  display: flex;
  background: red;
  border-radius: 10px;
  flex-direction: row;
`;

export const Form = styled.div`
  padding: 20px;
  flex: 1;
  display: flex;
  background: #f5f5f5;
  flex-direction: column;
  justify-content: center;
`;

export const Results = styled.div`
  padding: 20px;
  flex: 1;
  display: flex;
  background: #f5f5f5;
`;

export const FormRow = styled.div`
  display: flex;
  flex-direction: row;
  margin-bottom: 20px;

  div + div {
    margin-left: 20px;
  }
`;
