import React from 'react'

function CostDisplay(props) {
    const { id, monthlyDeduction: totalMonthlyDeduction } = props;
    return (
        <div key={id} className="border border-primary col-md-6" >
            <div className="fs-2">Total Monthly Deduction: {totalMonthlyDeduction}</div>
        </div>
    )
}

export default CostDisplay
