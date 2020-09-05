// import React from 'react';
import { renderHook } from '@testing-library/react-hooks';
import { act } from 'react-test-renderer';

import { useToast, ToastProvider } from '../../hooks/toast';

describe('Toast Hook', () => {
  it('should not render hook outside ToastProvider wraper', () => {
    const { result } = renderHook(() => useToast());
    expect(result.current).toEqual({});
  });

  it('should add a toast', async () => {
    const { result } = renderHook(() => useToast(), {
      wrapper: ToastProvider,
    });

    act(() => {
      result.current.addToast({ title: 'Error', description: 'Lorem ipsum' });
    });

    expect(result.current.messages).toEqual(
      expect.arrayContaining([
        expect.objectContaining({
          title: 'Error',
          description: 'Lorem ipsum',
        }),
      ]),
    );
  });

  it('should remove a toast', async () => {
    const { result } = renderHook(() => useToast(), {
      wrapper: ToastProvider,
    });

    act(() => {
      result.current.addToast({ title: 'Error', description: 'Lorem ipsum' });
    });
    const { id } = result.current.messages[0];

    act(() => {
      result.current.removeToast(id);
    });

    expect(result.current.messages).toEqual(expect.arrayContaining([]));
  });
});
