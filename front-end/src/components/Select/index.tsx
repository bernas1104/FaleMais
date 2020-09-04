import React, {
  useState,
  SelectHTMLAttributes,
  useCallback,
  useRef,
} from 'react';
import { IconBaseProps } from 'react-icons';
import { FiChevronDown } from 'react-icons/fi';

import { Container, Overlay, OptionsContainer } from './styles';

interface SelectOption {
  id: string | number;
  option: string;
}

interface SelectProps extends SelectHTMLAttributes<HTMLSelectElement> {
  icon?: React.ComponentType<IconBaseProps>;
  selectOptions: SelectOption[];
  enabled?: boolean;
  handleSelect: (
    e: React.MouseEvent<HTMLAnchorElement, MouseEvent>,
    option: string,
  ) => void;
}

const Select: React.FC<SelectProps> = ({
  id,
  icon: Icon,
  selectOptions,
  enabled = false,
  value,
  handleSelect,
}) => {
  const selectRef = useRef<HTMLSelectElement>(null);

  const [isFocused, setIsFocused] = useState(false);

  const handleContainerClick = useCallback(() => {
    if (enabled) {
      if (selectRef.current) {
        selectRef.current.focus();
        setIsFocused(!isFocused);
      }
    }
  }, [isFocused, enabled]);

  const handleOverlayClick = useCallback(() => {
    if (selectRef.current) {
      selectRef.current.blur();

      setIsFocused(!isFocused);
    }
  }, [isFocused]);

  return (
    <>
      <Container
        onClick={handleContainerClick}
        selectActive={isFocused}
        isSelected={!!value}
        enabled={enabled}
      >
        {Icon && <Icon size={20} />}
        <span>{value}</span>
        <FiChevronDown size={20} />

        <label htmlFor={id}>{id}</label>
        <select name={id} id={id} ref={selectRef}>
          {selectOptions.map(option => (
            <option key={option.id} value={option.id}>
              {option.option}
            </option>
          ))}
        </select>

        <OptionsContainer selectActive={isFocused}>
          {selectOptions.map(option => (
            <a
              href={`#${option.option}`}
              key={option.id}
              onClick={e => handleSelect(e, option.option)}
            >
              {option.option}
            </a>
          ))}
        </OptionsContainer>
      </Container>

      <Overlay selectActive={isFocused} onClick={handleOverlayClick} />
    </>
  );
};

export default Select;
