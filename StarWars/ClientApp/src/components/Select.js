import React from "react";
import { FormGroup, Label, Input } from 'reactstrap';

export function Select(props) {

    return (
        <FormGroup>
            <Label for={props.id}>{props.label}</Label>
            <Input type="select" id={props.id} onChange={props.onChange}>           
                    {props.options.map((option) => {
                        return <option selected={props.value === option.label} key={option.value}>{option.label}</option>;
                    })};        
            </Input>
        </FormGroup>
    );
}