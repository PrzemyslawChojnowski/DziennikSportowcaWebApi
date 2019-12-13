import React from "react";
import asReduxFormsField from "./asReduxFormsField";
import { Input } from "reactstrap";

import langs from "../Consts/langs.pl";

//imports
import NumericBox from "../../_components/Forms/NumericBox";
import TextBox from "../../_components/Forms/TextBox";
import SelectBox from "../../_components/Forms/SelectBox";

//redux-form fields
const ReduxNumericBoxField = asReduxFormsField()(NumericBox);
const ReduxTextBoxField = asReduxFormsField()(TextBox);
const ReduxSelectBoxField = asReduxFormsField()(SelectBox);

//reactstrap redux-form fields
const ReduxInputField = asReduxFormsField()(Input);

//exports
export const InputField = props => (
    <ReduxInputField placeholder={langs.fields.TypeAValue} {...props} />
);
export const NumericBoxField = props => (
    <ReduxNumericBoxField placeholder={langs.fields.TypeAValue} {...props} />
);
export const TextBoxField = props => (
    <ReduxTextBoxField placeholder={langs.fields.TypeAValue} {...props} />
);
export const SelectBoxField = props => (
    <ReduxSelectBoxField placeholder={langs.fields.SelectAValue} {...props} />
);
