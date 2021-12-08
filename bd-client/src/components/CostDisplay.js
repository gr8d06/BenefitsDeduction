import React from 'react'

function CostDisplay(props) {
    const { id, monthlyDeduction, discountRate } = props;
    return (
        <div key={id} className="border" >
            <div>Monthly Deduction: {monthlyDeduction}</div>
            <div>Discount Applied: {discountRate}</div>
        </div>
    )
}

export default CostDisplay
