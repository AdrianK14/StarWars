import React, { Component } from "react";
import { Container, Navbar, NavbarBrand } from "reactstrap";
import "./TitleBar.css";

export class TitleBar extends Component {
    render() {
        return (
            <header>
                <Navbar
                    className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
                    light
                >
                    <Container>
                        <NavbarBrand to="/">{this.props.title}</NavbarBrand>
                    </Container>
                </Navbar>
            </header>
        );
    }
}
