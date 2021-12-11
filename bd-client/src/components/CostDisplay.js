import React from 'react'

function CostDisplay(props) {
    const { id, totalMonthlyDeduction } = props;
    return (
        <div key={id} className="border border-primary col-md-6" >
            <div className="fs-2">Total Monthly Deduction: {totalMonthlyDeduction.toFixed(2)}</div>
        </div>
    )
}

export default CostDisplay
