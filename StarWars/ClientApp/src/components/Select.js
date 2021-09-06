import React from "react";
import { FormGroup, Label, Input } from 'reactstrap';

export function Select(props) {

    return (
        <FormGroup>
            <Label for={props.id}>{props.label}</Label>
            <Input value={props.value} type="select" id={props.id} onChange={props.onChange}>
                {props.options.map((option) => {
                    return <option key={option.value}>{option.label}</option>;
                })};
            </Input>
        </FormGroup>
    );
}