import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './components/NavMenu';
import { HeroDashboard } from './components/HeroDashboard';

export default class App extends Component {

    constructor(props) {
        super(props);
      }

    render() {
        return (
            <div>
                <NavMenu title="Star Wars Hero Information" />
                <Container>                  
                    <HeroDashboard />
                </Container>
            </div>
        );
    }
}