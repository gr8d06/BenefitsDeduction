import React from 'react'

function CostDisplay(props) {
    const { id, monthlyDeduction, discountRate } = props;
    return (
        <div key={id} className="border border-primary col-md-6" >
            <div className="fs-2">Monthly Deduction: {monthlyDeduction}</div>
            <div className="fs-3">Discount Applied: {discountRate}%</div>
        </div>
    )
}

export default CostDisplay
