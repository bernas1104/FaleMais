import React from 'react';
import { render } from '@testing-library/react';
import { FiCalendar } from 'react-icons/fi';

import Button from '../../components/Button';

describe('Button Component', () => {
  it('should render the component without icon', () => {
    const { getByText } = render(<Button>Anything</Button>);

    expect(getByText('Anything')).toBeTruthy();
  });

  it('should render the component with icon', () => {
    const { getByText } = render(<Button icon={FiCalendar}>Anything</Button>);

    expect(getByText('Anything')).toBeTruthy();
  });
});
