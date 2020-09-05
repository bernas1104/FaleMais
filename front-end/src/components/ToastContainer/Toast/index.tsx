import React, { useEffect } from 'react';
import { FiAlertTriangle, FiX } from 'react-icons/fi';

import { Container, Content } from './styles';
import { ToastMessage, useToast } from '../../../hooks/toast';

interface ToastProps {
  message: ToastMessage;
  style: Record<string, unknown>;
}

const Toast: React.FC<ToastProps> = ({ message, style }) => {
  const { removeToast } = useToast();

  useEffect(() => {
    const timer = setTimeout(() => {
      removeToast(message.id);
    }, 3000);

    return () => {
      clearTimeout(timer);
    };
  }, [removeToast, message.id]);

  return (
    <Container style={style}>
      <FiAlertTriangle size={20} color="#f5f5f5" />
      <Content>
        <strong>{message.title}</strong>
        {message.description && <p>{message.description}</p>}
      </Content>

      <button type="button" onClick={() => removeToast(message.id)}>
        <FiX size={20} color="#f5f5f5" />
      </button>
    </Container>
  );
};

export default Toast;
