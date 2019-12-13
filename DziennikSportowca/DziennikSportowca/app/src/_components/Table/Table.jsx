import React, { PureComponent } from "react";

class Table extends PureComponent {
    constructor(props) {
        super(props);

        this.state = {
            tableClassName: this.generateTableClassName(props.tableOptions),
            headClassName: this.generateHeadClassName(props.headOptions)
        };

        this.mapColumns = this.mapColumns.bind(this);
        this.mapRows = this.mapRows.bind(this);
    }

    generateTableClassName(tableOptions) {
        let tableClassName = "table ";

        if (tableOptions) {
            if (tableOptions.striped) tableClassName += "table-striped ";
            if (tableOptions.dark) tableClassName += "table-dark ";
            if (tableOptions.bordered) tableClassName += "table-bordered ";
            if (tableOptions.hover) tableClassName += "table-hover ";
            if (tableOptions.size && !tableOptions.responsive)
                tableClassName += `table-${tableOptions.size}`;
            else if (tableOptions.size && tableOptions.responsive)
                tableClassName += `table-responsive-${tableOptions.size} `;
            else if (!tableOptions.size && tableOptions.responsive)
                tableClassName += `table-responsive `;
        }

        return tableClassName;
    }

    generateHeadClassName(headOptions) {
        let headClassName = "";

        if (headOptions) {
            if (headOptions.dark) headClassName += "thead-dark ";
            else headClassName += "thead-light ";
        }

        return headClassName;
    }

    mapColumns() {
        const { children } = this.props;

        return (
            children &&
            children.map(function(column, index) {
                return React.cloneElement(column);
            })
        );
    }

    mapRows() {
        const { children, items } = this.props;
        const checkItems = items && Array.isArray(items) && items.length > 0;
        let i = 0;

        return (
            checkItems &&
            items.map(function(item, itemIndex) {
                const row = (
                    <tr key={`${i}.${itemIndex}`}>
                        {children &&
                            children.map(function(column, columnIndex) {
                                if (column.props.format) {
                                    return (
                                        <td key={`${i}.${itemIndex}.${columnIndex}`}>
                                            {column.props.format(item)}
                                        </td>
                                    );
                                } else {
                                    return (
                                        <td key={`${i}.${itemIndex}.${columnIndex}`}>
                                            {item[column.props.name]}
                                        </td>
                                    );
                                }
                            })}
                    </tr>
                );
                i++;
                return row;
            })
        );
    }

    render() {
        return (
            <table className={this.state.tableClassName}>
                {this.props.caption && <caption>{this.props.caption}</caption>}
                <thead className={this.state.headClassName}>
                    <tr>{this.mapColumns()}</tr>
                </thead>
                <tbody>{this.mapRows()}</tbody>
            </table>
        );
    }
}

export default Table;
