import React from 'react';
import { render, wait } from '@testing-library/react';
import { FiCalendar } from 'react-icons/fi';

import userEvent from '@testing-library/user-event';
import Select from '../../components/Select';

const mockHandleSelect = jest.fn();
const data: { id: number; value: string }[] = [];

describe('Select Component', () => {
  it('should render the select component without icon', () => {
    const { getByLabelText } = render(
      <Select
        id="Lorem"
        selectOptions={data}
        handleSelect={mockHandleSelect}
      />,
    );

    expect(getByLabelText('Lorem')).toBeTruthy();
  });

  it('should render the select component with icon', () => {
    const { getByLabelText } = render(
      <Select
        id="Lorem"
        selectOptions={data}
        handleSelect={mockHandleSelect}
        icon={FiCalendar}
      />,
    );

    expect(getByLabelText('Lorem')).toBeTruthy();
  });

  it('should do nothing on click, if disabled', async () => {
    const { getByLabelText, getByTestId } = render(
      <Select
        id="Lorem"
        selectOptions={data}
        handleSelect={mockHandleSelect}
        enabled={false}
      />,
    );

    const optionsContainerElement = getByTestId('options-container');

    userEvent.click(getByLabelText('Lorem'));

    await wait(() => {
      expect(optionsContainerElement).toHaveStyle('display: none');
    });
  });

  it('should show the options on click, if enabled', async () => {
    const { getByLabelText, getByTestId } = render(
      <Select
        id="Lorem"
        selectOptions={data}
        handleSelect={mockHandleSelect}
        enabled
      />,
    );

    const optionsContainerElement = getByTestId('options-container');

    userEvent.click(getByLabelText('Lorem'));

    await wait(() => {
      expect(optionsContainerElement).toHaveStyle('display: flex');
    });
  });

  it('should close the options if use click outside the options container', async () => {
    const { getByLabelText, getByTestId } = render(
      <Select
        id="Lorem"
        selectOptions={data}
        handleSelect={mockHandleSelect}
        enabled
      />,
    );

    const overlayElement = getByTestId('overlay');
    const optionsContainerElement = getByTestId('options-container');

    userEvent.click(getByLabelText('Lorem'));
    userEvent.click(overlayElement);

    await wait(() => {
      expect(optionsContainerElement).toHaveStyle('display: none');
    });
  });
});
