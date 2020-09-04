import React, { useState, useCallback } from 'react';
import { FiPhone, FiClock, FiMapPin } from 'react-icons/fi';

import { Container, Title, Calculator, Form, Results, FormRow } from './styles';
import Select from '../../components/Select';
import Input from '../../components/Input';
import Button from '../../components/Button';

const Home: React.FC = () => {
  const plans = [
    { id: 1, option: 'FaleMais 30' },
    { id: 2, option: 'FaleMais 60' },
    { id: 3, option: 'FaleMais 120' },
  ];

  const [originAreaCode, setOriginAreaCode] = useState('');
  const [destinyAreaCode, setDestinyAreaCode] = useState('');
  const [plan, setPlan] = useState('');
  const [minutes, setMinutes] = useState('');

  const handleSelectOrigin = useCallback(
    (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>, option: string) => {
      e.preventDefault();
      setOriginAreaCode(option);
    },
    [],
  );

  const handleSelectDestiny = useCallback(
    (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>, option: string) => {
      e.preventDefault();
      setDestinyAreaCode(option);
    },
    [],
  );

  const handleSelectPlan = useCallback(
    (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>, option: string) => {
      e.preventDefault();
      setPlan(option);
    },
    [],
  );

  return (
    <Container>
      <Title>Calculadora FaleMais</Title>

      <Calculator>
        <Form>
          <FormRow>
            <Select
              id="Origem"
              icon={FiMapPin}
              selectOptions={[
                { id: 1, option: 'Hello' },
                { id: 2, option: 'World' },
              ]}
              enabled
              value={originAreaCode}
              handleSelect={handleSelectOrigin}
            />
            <Select
              id="Origem"
              icon={FiMapPin}
              selectOptions={[
                { id: 1, option: 'Hello' },
                { id: 2, option: 'World' },
              ]}
              enabled={!!originAreaCode}
              value={destinyAreaCode}
              handleSelect={handleSelectDestiny}
            />
          </FormRow>

          <FormRow>
            <Select
              id="Planos"
              icon={FiMapPin}
              selectOptions={plans}
              enabled
              value={plan}
              handleSelect={handleSelectPlan}
            />
            <Input
              icon={FiClock}
              fieldName="Minutos"
              value={minutes}
              onChange={e => setMinutes(e.target.value)}
            />
          </FormRow>

          <Button icon={FiPhone}>{'Calcular'.toUpperCase()}</Button>
        </Form>
        <Results />
      </Calculator>
    </Container>
  );
};

export default Home;
