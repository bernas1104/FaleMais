import React from 'react';
import { FiAlertTriangle, FiX } from 'react-icons/fi';

import { Container, Content } from './styles';
import { ToastMessage } from '../../../hooks/ToastContext';

interface ToastProps {
  message: ToastMessage;
  style: Record<string, unknown>;
}

const Toast: React.FC<ToastProps> = ({ message, style }) => {
  return (
    <Container style={style}>
      <FiAlertTriangle size={20} color="#f5f5f5" />
      <Content>
        <strong>{message.title}</strong>
        {message.description && <p>{message.description}</p>}
      </Content>

      <button type="button">
        <FiX size={20} color="#f5f5f5" />
      </button>
    </Container>
  );
};

export default Toast;
