import styled from 'styled-components';

export const Container = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;
  justify-content: center;

  padding: 100px 15%;
  min-height: 100vh;

  @media screen and (max-width: 900px) {
    padding: 20px;
  }
`;

export const Calculator = styled.div`
  display: flex;
  border-radius: 10px;
  flex-direction: column;
  justify-content: center;

  padding: 30px 0 50px;

  box-shadow: 0px 5px 10px 5px rgba(0, 0, 0, 0.2);
`;

export const Title = styled.h1`
  margin: 20px 0;
  text-align: center;
`;

export const Form = styled.div`
  padding: 20px;
  display: flex;
  background: #f5f5f5;
  flex-direction: row;
  justify-content: center;

  @media screen and (max-width: 400px) {
    flex-direction: column !important;
  }
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

  @media screen and (max-width: 900px) {
    margin-bottom: 0;
    flex-direction: column;

    > div {
      margin-left: 0 !important;
      margin-bottom: 20px;
    }
  }
`;

export const Results = styled.div`
  padding: 0 20px;
  flex: 1;
  display: flex;
  flex-direction: column;
  justify-content: space-between;

  @media screen and (max-width: 900px) {
    justify-content: center;
  }

  @media screen and (max-width: 400px) {
    margin-top: 50px;

    div + div {
      margin-bottom: 0 !important;
    }
  }
`;

export const ResultContent = styled.div`
  h2,
  hr {
    margin-bottom: 10px;
  }

  @media screen and (max-width: 900px) {
    margin-bottom: 50px;
  }
`;
