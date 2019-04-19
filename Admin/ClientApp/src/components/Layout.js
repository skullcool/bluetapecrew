import React from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

const Layout = ({children}) =>
  <div>
    <NavMenu />
    <Container>
      {children}
    </Container>
  </div>

  export default Layout
