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
} from './styles';
import Select from '../../components/Select';
import Input from '../../components/Input';
import Button from '../../components/Button';
import api from '../../services/api';

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
  // const [inputError, setInputError] = useState(false); --> ToolTip!

  const handleSelectOrigin = useCallback(
    (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>, value: string) => {
      e.preventDefault();
      setOriginAreaCode(value);
    },
    [],
  );

  const handleSelectDestiny = useCallback(
    (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>, value: string) => {
      e.preventDefault();
      setDestinyAreaCode(value);
    },
    [],
  );

  const handleSelectPlan = useCallback(
    (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>, value: string) => {
      e.preventDefault();
      setPlan(value);
    },
    [],
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

  const handlePricesCalculation = useCallback(async () => {
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
        fromAreaCode: Yup.number().min(1).max(100).required(),
        toAreaCode: Yup.number().min(1).max(100).required(),
        minutes: Yup.number().min(1).required(),
        plan: Yup.string()
          .matches(/^FaleMais (30|60|120)$/gi)
          .required(),
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
      console.log(err);
      // TODO TOASTS!
    }
  }, [originAreaCode, destinyAreaCode, plan, minutes]);

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

  return (
    <Container>
      <Calculator>
        <Title>Calculadora FaleMais</Title>

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

            <Button icon={FiPhone} onClick={handlePricesCalculation}>
              {'Calcular'.toUpperCase()}
            </Button>
          </FormInput>

          <Results>
            <h1>Hello, Results!</h1>
            {callPrice.fromAreaCode}
            {callPrice.toAreaCode}
            {callPrice.pricePerMinute &&
              callPrice.pricePerMinute.toPrecision(2)}
          </Results>
        </Form>
      </Calculator>
    </Container>
  );
};

export default Home;
