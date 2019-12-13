import React, { Component } from "react";

class TabsContainer extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedIndex: undefined
        };

        this.mapItemsToTabs = this.mapItemsToTabs.bind(this);
        this.onTabSelect = this.onTabSelect.bind(this);
    }

    componentWillMount() {
        this.setState({ selectedIndex: this.props.defaultIndex });
    }

    onTabSelect(selectedIndex) {
        this.setState({ selectedIndex });
    }

    mapItemsToTabs() {
        const { children, id } = this.props;
        const { selectedIndex } = this.state;
        let content = [];
        let tabs = [];

        children.map((item, index) => {
            content.push(
                <div
                    key={`${id}.${item.props.index}`}
                    className={`tab-pane fade ${
                        item.props.index == selectedIndex ? "show active" : ""
                    }`}
                    role="tabpanel"
                    id={item.props.id}
                    aria-labelledby={`${item.props.id}-tab`}
                >
                    {item.props.children}
                </div>
            );

            tabs.push(
                <li className="nav-item" onClick={() => this.onTabSelect(item.props.index)}>
                    <a
                        className={`nav-link ${item.props.index == selectedIndex ? "active" : ""}`}
                        data-toggle="tab"
                        role="tab"
                        id={item.props.id}
                        href={`#${item.props.id}`}
                        aria-controls={item.props.id}
                        aria-selected={item.props.index == selectedIndex}
                    >
                        {item.props.name}
                    </a>
                </li>
            );
        });

        return (
            <div>
                <ul className="nav nav-tabs" role="tablist" id={id}>
                    {tabs}
                </ul>
                <div className="tab-content" id={`${id}Content`}>
                    {content}
                </div>
            </div>
        );
    }

    render() {
        return this.mapItemsToTabs();
    }
}

export default TabsContainer;
