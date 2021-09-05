import React from "react";
import { Table as BootstrapTable } from "reactstrap";

export function Table(props) {
    return (
        <>
            <h3>{props.title}</h3>
            <BootstrapTable striped bordered hover>
                <thead>
                    <tr>
                        {props.headers.map((header) => {
                            return <th>{header}</th>;
                        })}
                    </tr>
                </thead>
                <tbody>
                    {props.data.map((element, index) => {
                        let cells = [];
                        for (
                            let propIdx = 0;
                            propIdx < props.headers.length;
                            propIdx++
                        ) {
                            cells.push(
                                <td>{element[props.headers[propIdx]]}</td>
                            );
                        }
                        return <tr>{cells}</tr>;
                    })}
                </tbody>
            </BootstrapTable>
        </>
    );
}
