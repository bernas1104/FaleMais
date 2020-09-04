import React from 'react';

import Home from './pages/Home';
import GlobalStyle from './styles/global';
import AppProvider from './hooks';

function App(): JSX.Element {
  return (
    <AppProvider>
      <Home />
      <GlobalStyle />
    </AppProvider>
  );
}

export default App;
