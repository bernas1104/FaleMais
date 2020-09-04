import React, { useState, useCallback, useEffect, useMemo } from 'react';
import { FiPhone, FiClock, FiMapPin } from 'react-icons/fi';
import * as Yup from 'yup';

import {
  Container,
  Title,
  Calculator,
  Form,
  FormInput,
  InputRow,
  Results,
  ResultContent,
  HighlightNoPlan,
  HighlightPlan,
} from './styles';
import Select from '../../components/Select';
import Input from '../../components/Input';
import Button from '../../components/Button';
import { useToast } from '../../hooks/ToastContext';
import api from '../../services/api';

import FaleMaisLogo from '../../assets/images/FaleMais.png';

interface AreaCodes {
  id: number;
  name: string;
}

interface CallPrice {
  fromAreaCode: number;
  toAreaCode: number;
  pricePerMinute: number;
}

interface Calculate {
  fromAreaCode: number;
  toAreaCode: number;
  minutes: number;
  plan: string;
}

const Home: React.FC = () => {
  const plans = [
    { id: 1, value: 'FaleMais 30' },
    { id: 2, value: 'FaleMais 60' },
    { id: 3, value: 'FaleMais 120' },
  ];

  const [areaCodes, setAreaCodes] = useState([] as AreaCodes[]);
  const [originAreaCode, setOriginAreaCode] = useState('');
  const [destinyAreaCode, setDestinyAreaCode] = useState('');
  const [plan, setPlan] = useState('');
  const [minutes, setMinutes] = useState('');
  const [callPrice, setCallPrice] = useState({} as CallPrice);

  const handleReset = useCallback(() => {
    setCallPrice({} as CallPrice);
  }, []);

  const handleSelectOrigin = useCallback(
    (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>, value: string) => {
      e.preventDefault();
      setOriginAreaCode(value);
      setDestinyAreaCode('');

      if (callPrice.pricePerMinute) handleReset();
    },
    [callPrice, handleReset],
  );

  const handleSelectDestiny = useCallback(
    (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>, value: string) => {
      e.preventDefault();
      setDestinyAreaCode(value);

      if (callPrice.pricePerMinute) handleReset();
    },
    [callPrice, handleReset],
  );

  const handleSelectPlan = useCallback(
    (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>, value: string) => {
      e.preventDefault();
      setPlan(value);

      if (callPrice.pricePerMinute) handleReset();
    },
    [callPrice, handleReset],
  );

  const handleMinutesInput = useCallback(
    (e: React.ChangeEvent<HTMLInputElement>) => {
      const input = e.target.value;
      const len = e.target.value.length;

      if (
        input === '' ||
        (input.charCodeAt(len - 1) >= 48 && input.charCodeAt(len - 1) <= 57)
      ) {
        setMinutes(input);
      }
    },
    [],
  );

  const { addToast } = useToast();

  const handleFetchPrice = useCallback(async () => {
    try {
      const origin = Number(originAreaCode.split(' - ')[0]);
      const destiny = Number(destinyAreaCode.split(' - ')[0]);
      const totalTime = Number(minutes);

      const data: Calculate = {
        fromAreaCode: origin,
        toAreaCode: destiny,
        minutes: totalTime,
        plan,
      };

      const schema = Yup.object().shape({
        fromAreaCode: Yup.number().min(1, 'Escolha um DDD de origem'),
        toAreaCode: Yup.number().min(1, 'Escolha um DDD de destino'),
        minutes: Yup.number().min(1, 'Defina um total de minutos'),
        plan: Yup.string().matches(
          /^FaleMais (30|60|120)$/gi,
          'Escolha um plano FaleMais',
        ),
      });

      await schema.validate(data, { abortEarly: false });

      const response = await api.get(
        `/v1/calls?from-area-code=${
          originAreaCode.split(' - ')[0]
        }&to-area-code=${destinyAreaCode.split(' - ')[0]}`,
      );

      const { fromAreaCode, toAreaCode, pricePerMinute } = response.data;

      setCallPrice({ fromAreaCode, toAreaCode, pricePerMinute });
    } catch (err) {
      const { errors } = err as Yup.ValidationError;

      errors.forEach(error => {
        addToast({
          title: 'Erro',
          description: error,
        });
      });
    }
  }, [originAreaCode, destinyAreaCode, plan, minutes, addToast]);

  useEffect(() => {
    async function getAreaCodes() {
      const response = await api.get('v1/areacodes');
      setAreaCodes(response.data);
    }

    getAreaCodes();
  }, []);

  const originAreaCodesOptions = useMemo(
    () =>
      areaCodes.map(areaCode => ({
        id: areaCode.id,
        value: `${areaCode.id} - ${areaCode.name}`,
      })),
    [areaCodes],
  );

  const destinyAreaCodeOptions = useMemo(
    () =>
      areaCodes
        .filter(areaCode => {
          const originAreaCodeId = originAreaCode.split(' - ')[0];
          return areaCode.id !== Number(originAreaCodeId);
        })
        .map(areaCode => ({
          id: areaCode.id,
          value: `${areaCode.id} - ${areaCode.name}`,
        })),
    [areaCodes, originAreaCode],
  );

  const calculatePriceWithoutPlan = useMemo(
    () => (Number(minutes) * callPrice.pricePerMinute).toFixed(2),
    [minutes, callPrice],
  );

  const calculatePriceWithPlan = useMemo(() => {
    const planMinutes = Number(plan.split(' ')[1]);

    if (Number(minutes) > planMinutes)
      return (
        (Number(minutes) - planMinutes) *
        (callPrice.pricePerMinute * 1.1)
      ).toFixed(2);

    return (callPrice.pricePerMinute * 0).toFixed(2);
  }, [minutes, callPrice, plan]);

  return (
    <>
      <Container>
        <Calculator>
          <Title>
            <img src={FaleMaisLogo} alt="FaleMais logo" />
            <h1>Calculadora</h1>
          </Title>

          <Form>
            <FormInput>
              <InputRow>
                <Select
                  id="Origem"
                  icon={FiMapPin}
                  selectOptions={originAreaCodesOptions}
                  enabled
                  value={originAreaCode}
                  handleSelect={handleSelectOrigin}
                />
                <Select
                  id="Origem"
                  icon={FiMapPin}
                  selectOptions={destinyAreaCodeOptions}
                  enabled={!!originAreaCode}
                  value={destinyAreaCode}
                  handleSelect={handleSelectDestiny}
                />
              </InputRow>

              <InputRow>
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
                  onChange={e => handleMinutesInput(e)}
                />
              </InputRow>

              <Button icon={FiPhone} onClick={handleFetchPrice}>
                {'Calcular'.toUpperCase()}
              </Button>
            </FormInput>

            <Results>
              {callPrice && (
                <ResultContent>
                  <h2>Sem Plano</h2>
                  <hr />
                  <span>
                    <strong>Total</strong>
                    {` - `}
                    <HighlightNoPlan>
                      {`R$ `}
                      {callPrice.pricePerMinute
                        ? calculatePriceWithoutPlan
                        : (0).toFixed(2)}
                    </HighlightNoPlan>
                  </span>
                </ResultContent>
              )}

              {callPrice && (
                <ResultContent>
                  <h2>{plan || 'FaleMais'}</h2>
                  <hr />
                  <span>
                    <strong>Total</strong>
                    {` - `}
                    <HighlightPlan>
                      {`R$ `}
                      {callPrice.pricePerMinute
                        ? calculatePriceWithPlan
                        : (0).toFixed(2)}
                    </HighlightPlan>
                  </span>
                </ResultContent>
              )}
            </Results>
          </Form>
        </Calculator>
      </Container>
    </>
  );
};

export default Home;
