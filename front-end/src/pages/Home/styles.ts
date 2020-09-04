import styled from 'styled-components';

export const Container = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;
  justify-content: center;

  padding: 100px;
  min-height: 100vh;
`;

export const Title = styled.h1`
  text-align: center;
  margin-bottom: 50px;
`;

export const Calculator = styled.div`
  display: flex;
  background: red;
  border-radius: 10px;
  flex-direction: column;
  justify-content: center;

  box-shadow: 0px 5px 10px 5px rgba(0, 0, 0, 0.2);
`;

export const Form = styled.div`
  padding: 20px;
  display: flex;
  background: #f5f5f5;
  flex-direction: row;
  justify-content: center;
`;

export const FormInput = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;
`;

export const InputRow = styled.div`
  display: flex;
  flex-direction: row;

  margin-bottom: 20px;

  div + div {
    margin-left: 20px;
  }
`;

export const Results = styled.div`
  padding: 20px;
  flex: 1;
  display: flex;
  background: #f5f5f5;
`;
