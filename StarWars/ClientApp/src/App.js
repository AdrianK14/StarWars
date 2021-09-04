import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { Route } from 'react-router';
import { NavMenu } from './components/NavMenu';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <div>
                <NavMenu title="Star Wars Hero Information" />
                <Container>
                    <h2>Hello world!</h2>
                </Container>
            </div>
        );
    }
}
