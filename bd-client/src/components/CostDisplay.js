import React from 'react'

function CostDisplay(props) {
    const { id, totalMonthlyDeduction } = props;
    const currencySymbol = "$"; //Could differ depending on the locale
    return (
        <div key={id} className="border border-primary col-md-6" >
            <div className="fs-2">Total Monthly Deduction: {currencySymbol}{totalMonthlyDeduction.toFixed(2)}</div>
        </div>
    )
}

export default CostDisplay
