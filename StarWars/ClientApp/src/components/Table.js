import React from "react";
import { Table as BootstrapTable } from "reactstrap";

export function Table(props) {
    return props.data.length > 0 && props.headers.length > 0 ?
        <>
            <h4>{props.title}</h4>
            <BootstrapTable striped bordered hover size="sm">
                <thead>
                    <tr>
                        {props.headers.map((header) => {
                            return <th>{header.split('_').join(' ').toUpperCase()}</th>;
                        })}
                    </tr>
                </thead>
                <tbody>
                    {props.data.map((element) => {
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
        </> : null;
}
