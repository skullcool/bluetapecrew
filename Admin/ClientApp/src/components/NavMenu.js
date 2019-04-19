import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap'
import { Link } from 'react-router-dom'
import './NavMenu.css'

export class NavMenu extends Component {
  constructor (props) {
    super(props);

    this.state = {
      collapsed: true
    };
    this.toggleNavbar = this.toggleNavbar.bind(this);
  }

  toggleNavbar = () =>
    this.setState({
      collapsed: !this.state.collapsed
    });

  render = () =>
    <header>
      <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
        <Container>
          <NavbarBrand tag={Link} to="/categories" style={styles.brandLink}>Categories</NavbarBrand>
          <NavbarBrand tag={Link} to="/" style={styles.brandLink}>Products</NavbarBrand>
          <NavbarBrand tag={Link} to="/settings" style={styles.brandLink}>Settings</NavbarBrand>
          <NavbarBrand tag={Link} to="/users" style={styles.brandLink}>Users</NavbarBrand>
          <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="https://bluetapecrew.com" target="_blank">Site</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/counter">Logout</NavLink>
              </NavItem>
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
}

const styles = {
  brandLink: {
    paddingRight: 15
  }
}