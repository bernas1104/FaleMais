import React, { ButtonHTMLAttributes } from 'react';
import { IconBaseProps } from 'react-icons';

import { Container } from './styles';

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
  icon?: React.ComponentType<IconBaseProps>;
  buttonIconColor?: string;
}

const Button: React.FC<ButtonProps> = ({
  children,
  icon: Icon,
  buttonIconColor,
  ...rest
}) => {
  return (
    <Container>
      <button type="button" {...rest}>
        {Icon && <Icon size={20} color={buttonIconColor} />}
        <span>{children}</span>
      </button>
    </Container>
  );
};

export default Button;
