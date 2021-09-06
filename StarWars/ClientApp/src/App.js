import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { TitleBar } from './components/TitleBar';
import { HeroDashboard } from './components/HeroDashboard';
import { Select } from "./components/Select";
import "./App.css";

export default class App extends Component {

    constructor(props) {
        super(props);
        this.state = {
            heroName: "Luke Skywalker"
        }
    }

    selectOptions = [
        { label: "Luke Skywalker", value: 1 },
        { label: "C-3PO", value: 2 },
        { label: "R2-D2", value: 3 },
        { label: "Darth Vader", value: 4 },
        { label: "Owen Lars", value: 5 },
        { label: "Beru Whitesun lars", value: 6 },
        { label: "R5-D4", value: 7 },
        { label: "Biggs Darklighter", value: 8 },
        { label: "Obi-Wan Kenobi", value: 9 },
    ];

    onHeroChange = (event) => {
        this.setState({ heroName: event.target.value });
    };

    render() {
        return (
            <div>
                <TitleBar title="Star Wars Hero Information" />
                <Container>
                    <div className="div-container">
                        <Select
                            label="Choose hero:"
                            id="hero"
                            value={this.state.heroName}
                            options={this.selectOptions}
                            onChange={this.onHeroChange}
                        />
                    </div>
                    <div className="div-container">
                        <HeroDashboard hero={this.state.heroName} />
                    </div>
                </Container>
            </div>
        );
    }
}