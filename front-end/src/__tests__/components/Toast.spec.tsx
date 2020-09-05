import React from 'react';
import { render, wait } from '@testing-library/react';

import userEvent from '@testing-library/user-event';
import ToastContainer from '../../components/ToastContainer';

const message: { id: string; title: string; description?: string }[] = [
  {
    id: '1',
    title: 'Erro',
    description: 'Lorem ipsum',
  },
];

jest.useFakeTimers();

const mockRemoveToast = jest.fn();

jest.mock('../../hooks/toast', () => ({
  useToast: () => ({
    removeToast: mockRemoveToast,
  }),
}));

describe('ToastContainer Component', () => {
  it('should render Toast component', () => {
    const { getByTestId } = render(<ToastContainer messages={message} />);
    expect(getByTestId('toast-container')).toBeTruthy();
  });

  it('should remove the toast automatically after 3 seconds', async () => {
    render(<ToastContainer messages={message} />);

    jest.advanceTimersByTime(3000);

    await wait(() => {
      expect(mockRemoveToast).toHaveBeenCalled();
    });
  });

  it('should remove the toast if user clicks on the close button', async () => {
    const { getByTestId } = render(<ToastContainer messages={message} />);

    userEvent.click(getByTestId('toast-close-btn'));

    await wait(() => {
      expect(mockRemoveToast).toHaveBeenCalled();
    });
  });
});
