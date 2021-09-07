import React from "react";
import { Table as BootstrapTable } from "reactstrap";

export function Table(props) {

    return props.data.length > 0 && props.headers.length > 0 ?
        <>
            <h4>{props.title}</h4>
            <BootstrapTable striped bordered hover size="sm">
                <thead>
                    <tr>
                        {props.headers.map((header, index) => {
                            return <th key= {index} >{header.split('_').join(' ').toUpperCase()}</th>;
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
                                <td key={propIdx}>{element[props.headers[propIdx]]}</td>
                            );
                        }
                        return <tr key={index}>{cells}</tr>;
                    })}
                </tbody>
            </BootstrapTable>
        </> : null;
}
