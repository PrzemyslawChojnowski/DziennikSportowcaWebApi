/* eslint-disable react/prop-types */
/* eslint-disable react/no-multi-comp */

import React, { Component } from 'react';
import { Field } from 'redux-form';

export default function asReduxFormsField(defaultProps) {
    return ControlledComponent => {
        const renderComponent = ({input, meta, ...others}) => React.createElement(ControlledComponent, {...input, meta, ...others});
    
        return class ReduxFormWrapper extends Component {
            render() {
                const { name, id, ...other} = this.props;
    
                let validate = undefined;
                let warn = undefined;
                if(!other.isReadOnly) {
                    if(other.validate) {
                        validate = defaultProps && defaultProps.validate ? [...defaultProps.validate, ...other.validate] : other.validate;
                    } else {
                        validate = defaultProps ? defaultProps.validate : undefined;
                    }
    
                    if(other.warn) {
                        warn = defaultProps && defaultProps.warn ? [...defaultProps.warn, ...other.warn] : other.warn;
                    } else {
                        warn = defaultProps ? defaultProps.warn : undefined;
                    }
                }
    
                return (
                    <Field 
                        name={name} 
                        id={id} 
                        component={renderComponent} 
                        {...other} 
                        {...defaultProps} 
                        validate={validate} 
                        warn={warn} 
                    />
                );
            }
        };
    };
}