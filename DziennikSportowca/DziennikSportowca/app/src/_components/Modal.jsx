import React, { PureComponent } from "react";
import Button from "./Button";

function closeModal(modalName) {
    $(`#${modalName}`).modal("hide");
}

class Modal extends PureComponent {
    constructor(props) {
        super(props);

        this.onClose = this.onClose.bind(this);
    }

    onClose() {
        closeModal(this.props.name);
    }

    componentWillReceiveProps(nextProps) {
        if (!nextProps.show) {
            closeModal(this.props.name);
        }
    }

    render() {
        const {
            name,
            show,
            header,
            body,
            footer,
            withHeaderCloseButton,
            withoutFooter
        } = this.props;

        return (
            <div
                className={`modal fade ${show ? "show" : ""}`}
                id={name}
                tabindex="-1"
                role="dialog"
                aria-labelledby={`${name}Label`}
                aria-hidden={show ? "true" : "false"}
                style={{ display: show ? "block" : "none" }}
            >
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id={`${name}Label`}>
                                {header}
                            </h5>
                            {withHeaderCloseButton && (
                                <Button
                                    onClick={this.onClose}
                                    customClassName="close"
                                    modal
                                    ariaLabel="Close"
                                >
                                    <span aria-hidden="true">&times;</span>
                                </Button>
                            )}
                        </div>
                        <div className="modal-body">{body}</div>
                        {!withoutFooter && (
                            <div className="modal-footer">
                                {footer ? (
                                    footer
                                ) : (
                                    <React.Fragment>
                                        <Button modal onClick={this.onClose} type="danger">
                                            Close
                                        </Button>
                                    </React.Fragment>
                                )}
                            </div>
                        )}
                    </div>
                </div>
            </div>
        );
    }
}

Modal.defaultProps = {
    withHeaderCloseButton: true
};

export default Modal;
