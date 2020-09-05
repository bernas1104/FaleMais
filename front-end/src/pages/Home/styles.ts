import styled from 'styled-components';

export const Container = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;
  justify-content: center;
  background: #ff8e4c;

  padding: 100px 10%;
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
  background: #f5f5f5;

  padding: 30px 0 50px;

  box-shadow: 0px 5px 10px 5px rgba(0, 0, 0, 0.2);
`;

export const Title = styled.div`
  margin: 20px 0;

  display: flex;
  flex-direction: row;
  align-items: flex-end;
  justify-content: center;

  img {
    width: 100%;
    height: auto;
    max-width: 400px;
  }

  h1 {
    margin: 0 0 13px 0;
  }

  @media screen and (max-width: 660px) {
    flex-direction: column;
    align-items: center;

    h1 {
      margin: 0;
      flex: 1 !important;
    }
  }
`;

export const Form = styled.div`
  padding: 20px;
  display: flex;
  background: #f5f5f5;
  flex-direction: row;
  justify-content: center;

  @media screen and (max-width: 460px) {
    flex-direction: column !important;
  }
`;

export const FormInput = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;
  padding-right: 10px;
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
  padding-left: 10px;
  flex: 1;
  display: flex;
  flex-direction: column;
  justify-content: space-between;

  @media screen and (max-width: 900px) {
    justify-content: center;
  }

  @media screen and (max-width: 460px) {
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

export const HighlightNoPlan = styled.span`
  color: #e8143a;
  font-weight: 400;
`;

export const HighlightPlan = styled.span`
  color: #779e00;
  font-weight: 400;
`;
