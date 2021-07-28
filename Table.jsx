import {useState} from "react";

let tableRowNumber = [0, 1];
let tableColumnNumber = [0, 1];

export const Table = () => {
    const [row, setRow] = useState(2);
    const [column, setColumn] = useState(2);

    const AddRow = (event) => {
        event.preventDefault();
        tableRowNumber.splice(event.target.id, 0, row + 1);
        setRow(row + 1);
    }

    const AddColumn = (event) => {
        event.preventDefault();
        tableColumnNumber.splice(event.target.id, 0, column + 1);
        setColumn(column + 1);
    }

    const ColumnDelClick = (event) => {
        event.preventDefault();
        const deletedIndex = tableColumnNumber.splice(event.target.id, 1);

        if (deletedIndex.length === 1) {
            tableColumnNumber.splice(event.target.id, 0);
        }
        setColumn(column - 1);
    }

    const RowDelClick = (event) => {
        event.preventDefault();
        const deletedIndex = tableRowNumber.splice(event.target.id, 1);

        if (deletedIndex.length === 1) {
            tableRowNumber.splice(event.target.id, 0);
        }
        setRow(row - 1);
    }

    return (
        <div>
            <div style ={{marginBottom: '10px', marginLeft: '15px'}}>
                <input type="checkbox" id="inserting" name="inserting" value="Ins" />
                    <label htmlFor="inserting">Добавление</label>
            </div>
            <table style={{marginLeft: '15px'}}>
                <thead>
                <tr onClick={ColumnDelClick} style={{cursor: 'pointer'}}>
                    {tableColumnNumber.map((column, index) => {
                        return (
                            <th id={index} key={column} style={{width: '100px'}}>Column {column + 1}</th>
                        )
                    })}
                </tr>
                </thead>
                <tbody>
                {tableColumnNumber.map((column) => {
                    return (
                        <td key={column}>
                            {tableRowNumber.map((row, index) => {
                                return (
                                    <tr id={index} key={row} onClick={RowDelClick}
                                        style={{cursor: 'pointer'}}>Row{row + 1}</tr>
                                )
                            })}
                        </td>
                    )
                })}
                </tbody>
            </table>
            <button onClick={AddRow} style={{marginLeft: '15px', marginTop: '40px'}}>Add Row</button>
            <button onClick={AddColumn} style={{marginLeft: '10px'}}>Add Column</button>
        </div>
    )

}