import React from 'react';
import user from '@testing-library/user-event';
import { render, cleanup, waitForElement, wait } from '@testing-library/react';
import MockAdapter from 'axios-mock-adapter';

import Home from '../../pages/Home';
import api from '../../services/api';

const response = {
  areaCodes: [
    {
      id: 1,
      name: '#1 Area Code',
    },
    {
      id: 2,
      name: '#2 Area Code',
    },
    {
      id: 3,
      name: '#3 Area Code',
    },
  ],
  calls: [
    {
      fromAreaCode: 1,
      toAreaCode: 2,
      pricePerMinute: 2.9,
    },
    {
      fromAreaCode: 2,
      toAreaCode: 1,
      pricePerMinute: 1.5,
    },
  ],
};

const plans: { [key: number]: number } = {
  1: 30,
  2: 60,
  3: 120,
};

const mockAddToast = jest.fn();

jest.mock('../../hooks/toast', () => ({
  useToast: () => ({
    addToast: mockAddToast,
  }),
}));

describe('Home Page', () => {
  afterEach(() => {
    cleanup();
    jest.resetAllMocks();
  });

  it('should be able to calculate the total price of calls between area codes for X minutes', async () => {
    const mockApi = new MockAdapter(api);
    mockApi.onGet('v1/areacodes').reply(200, response.areaCodes);
    mockApi
      .onGet('v1/calls?from-area-code=1&to-area-code=2')
      .reply(200, response.calls[0]);

    const plan = Math.floor(Math.random() * 3 + 1);
    const minutes = Math.floor(Math.random() * 300 + 1);

    const totalWithoutPlan = (minutes * 2.9).toFixed(2);
    let totalWithPlan: string;

    if (minutes > plans[plan])
      totalWithPlan = ((minutes - plans[plan]) * (2.9 * 1.1)).toFixed(2);
    else totalWithPlan = (0).toFixed(2);

    const page = render(<Home />);

    await waitForElement(() => page.getByTestId('Origem'));
    await waitForElement(() => page.getByTestId('Destino'));

    const resultsWithoutPlan = page.getByTestId('results-without-plan');
    const resultsWithPlan = page.getByTestId('results-with-plan');

    user.click(page.getByTestId('origem-select'));
    user.click(page.getByTestId('origem-option-1'));

    user.click(page.getByTestId('destino-select'));
    user.click(page.getByTestId('destino-option-2'));

    user.click(page.getByTestId('planos-select'));
    user.click(page.getByTestId(`planos-option-${plan}`));

    user.type(page.getByTestId('minutes-input'), `${minutes}`);

    user.click(page.getByText('CALCULAR'));

    await waitForElement(() => resultsWithoutPlan);
    await waitForElement(() => resultsWithPlan);

    expect(page.getByText(`R$ ${totalWithoutPlan}`)).not.toBeEmpty();
    expect(page.getByText(`R$ ${totalWithPlan}`)).not.toBeEmpty();
  });

  it('should reset the total price if user change the origin of the call', async () => {
    const mockApi = new MockAdapter(api);
    mockApi.onGet('v1/areacodes').reply(200, response.areaCodes);
    mockApi
      .onGet('v1/calls?from-area-code=1&to-area-code=2')
      .reply(200, response.calls[1]);

    const plan = Math.floor(Math.random() * 3 + 1);
    const minutes = Math.floor(Math.random() * 300 + 1);

    const page = render(<Home />);

    await waitForElement(() => page.getByTestId('Origem'));
    await waitForElement(() => page.getByTestId('Destino'));

    const resultsWithoutPlan = page.getByTestId('results-without-plan');
    const resultsWithPlan = page.getByTestId('results-with-plan');

    user.click(page.getByTestId('origem-select'));
    user.click(page.getByTestId('origem-option-1'));

    user.click(page.getByTestId('destino-select'));
    user.click(page.getByTestId('destino-option-2'));

    user.click(page.getByTestId('planos-select'));
    user.click(page.getByTestId(`planos-option-${plan}`));

    user.type(page.getByTestId('minutes-input'), `${minutes}`);

    user.click(page.getByText('CALCULAR'));

    await waitForElement(() => resultsWithoutPlan);
    await waitForElement(() => resultsWithPlan);

    user.click(page.getByTestId('origem-select'));
    user.click(page.getByTestId('origem-option-2'));

    const totals = page.getAllByText('R$ 0.00');

    expect(totals.length).toBe(2);
  });

  it('should reset the total price if user change the destiny of the call', async () => {
    const mockApi = new MockAdapter(api);
    mockApi.onGet('v1/areacodes').reply(200, response.areaCodes);
    mockApi
      .onGet('v1/calls?from-area-code=1&to-area-code=2')
      .reply(200, response.calls[1]);

    const plan = Math.floor(Math.random() * 3 + 1);
    const minutes = Math.floor(Math.random() * 300 + 1);

    const page = render(<Home />);

    await waitForElement(() => page.getByTestId('Origem'));
    await waitForElement(() => page.getByTestId('Destino'));

    const resultsWithoutPlan = page.getByTestId('results-without-plan');
    const resultsWithPlan = page.getByTestId('results-with-plan');

    user.click(page.getByTestId('origem-select'));
    user.click(page.getByTestId('origem-option-1'));

    user.click(page.getByTestId('destino-select'));
    user.click(page.getByTestId('destino-option-2'));

    user.click(page.getByTestId('planos-select'));
    user.click(page.getByTestId(`planos-option-${plan}`));

    user.type(page.getByTestId('minutes-input'), `${minutes}`);

    user.click(page.getByText('CALCULAR'));

    await waitForElement(() => resultsWithoutPlan);
    await waitForElement(() => resultsWithPlan);

    user.click(page.getByTestId('destino-select'));
    user.click(page.getByTestId('destino-option-3'));

    const totals = page.getAllByText('R$ 0.00');

    expect(totals.length).toBe(2);
  });

  it('should fail to calculate the total price of calls and add error toasts to the DOM', async () => {
    const mockApi = new MockAdapter(api);
    mockApi.onGet('v1/areacodes').reply(200, response.areaCodes);

    const page = render(<Home />);

    await waitForElement(() => page.getByTestId('Origem'));
    await waitForElement(() => page.getByTestId('Destino'));

    user.click(page.getByText('CALCULAR'));

    await wait(() => expect(mockAddToast).toHaveBeenCalledTimes(4));
  });

  it('should fail to calculate the total if user tries to input anything but numbers into the minutes input', async () => {
    const mockApi = new MockAdapter(api);
    mockApi.onGet('v1/areacodes').reply(200, response.areaCodes);

    const plan = Math.floor(Math.random() * 3 + 1);

    const page = render(<Home />);

    await waitForElement(() => page.getByTestId('Origem'));
    await waitForElement(() => page.getByTestId('Destino'));

    user.click(page.getByTestId('origem-select'));
    user.click(page.getByTestId('origem-option-1'));

    user.click(page.getByTestId('destino-select'));
    user.click(page.getByTestId('destino-option-2'));

    user.click(page.getByTestId('planos-select'));
    user.click(page.getByTestId(`planos-option-${plan}`));

    user.type(page.getByTestId('minutes-input'), 'adshajd');

    user.click(page.getByText('CALCULAR'));

    await wait(() => expect(mockAddToast).toHaveBeenCalledTimes(1));
  });
});
