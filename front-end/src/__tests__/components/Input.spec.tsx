import React from 'react';
import { render, fireEvent, wait } from '@testing-library/react';
import user from '@testing-library/user-event';
import { FiCalendar } from 'react-icons/fi';

import Input from '../../components/Input';

describe('Input Component', () => {
  it('should render an input component without icon', () => {
    const { getByLabelText } = render(<Input fieldName="Lorem ipsum" />);

    expect(getByLabelText('Lorem ipsum')).toBeTruthy();
  });

  it('should render an input component with icon', () => {
    const { getByLabelText } = render(
      <Input fieldName="Lorem ipsum" icon={FiCalendar} />,
    );

    expect(getByLabelText('Lorem ipsum')).toBeTruthy();
  });

  it('should move the label to top-left on focus', async () => {
    const { getByTestId } = render(
      <Input fieldName="Lorem ipsum" icon={FiCalendar} />,
    );

    const inputElement = getByTestId('input-field');
    const labelElement = getByTestId('Lorem ipsum');

    fireEvent.focus(inputElement);

    await wait(() => {
      expect(labelElement).toHaveStyle('top: -8px;');
      expect(labelElement).toHaveStyle('left: 10px;');
    });
  });

  it('should return label to original position on blur', async () => {
    const { getByTestId } = render(
      <Input fieldName="Lorem ipsum" icon={FiCalendar} />,
    );

    const inputElement = getByTestId('input-field');
    const labelElement = getByTestId('Lorem ipsum');

    fireEvent.blur(inputElement);

    await wait(() => {
      expect(labelElement).toHaveStyle('top: 13px;');
      expect(labelElement).toHaveStyle('left: 40px;');
    });
  });

  it('should keep label on top-left if input filled', async () => {
    const { getByTestId } = render(
      <Input fieldName="Lorem ipsum" icon={FiCalendar} />,
    );

    const inputElement = getByTestId('input-field');
    const labelElement = getByTestId('Lorem ipsum');

    user.type(inputElement, 'Anything');
    fireEvent.blur(inputElement);

    await wait(() => {
      expect(labelElement).toHaveStyle('top: -8px;');
      expect(labelElement).toHaveStyle('left: 10px;');
    });
  });
});
