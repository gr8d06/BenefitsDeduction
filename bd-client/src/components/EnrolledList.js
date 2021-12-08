import { data } from "../CustomerData";
import Primary from "./Primary";
import Toolbar from "./Toolbar";
import { useState } from "react";
import Popup from "./Popup";

function EnrolledList() {

    const [customerData, setCustomerData] = useState(data);
    const [showDependants, setShowDependants] = useState(true);
    const [showInputDialog, setShowInputDialog] = useState(false);

    return (
        <div>
            <Toolbar showDependants={showDependants} setShowDependants={setShowDependants} showInputDialog={showInputDialog} setShowInputDialog={setShowInputDialog} />
            <div className="enrolleeList  d-grid gap-3">
                {customerData.map(enrolleeList => <Primary enrolleeList={enrolleeList} setCustomerData={setCustomerData} showDependants={showDependants} />)}
            </div>
            <Popup showInputDialog={showInputDialog} setShowInputDialog={setShowInputDialog} />
        </div>
    );
}

export default EnrolledList;