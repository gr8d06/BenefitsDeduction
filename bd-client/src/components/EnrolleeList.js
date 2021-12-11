//import { data } from "../CustomerData";
import Primary from "./Primary";
import Toolbar from "./Toolbar";
import { useState, useEffect } from "react";
import Popup from "./Popup";

function EnrolleeList() {

    const [customerData, setCustomerData] = useState([]);
    const [showDependants, setShowDependants] = useState(true);
    const [showInputDialog, setShowInputDialog] = useState(false);
    const [refreshList, setrefreshList] = useState(false);

    useEffect(() => {
        fetchEnrolleeData();
        setrefreshList(false);
    }, [refreshList])

    const fetchEnrolleeData = async () => {
        try {
            const response = await fetch("http://localhost:8888/enrollees");
            const data = await response.json();
            setCustomerData(data);
        }
        catch (e) {
            console.log(e);
        }
    }

    return (
        <div>
            <Toolbar showDependants={showDependants} setShowDependants={setShowDependants} showInputDialog={showInputDialog} setShowInputDialog={setShowInputDialog} />
            <div key="mainEnrolleeList" className="enrolleeList  d-grid gap-3">
                {customerData.map(enrolleeList => <Primary enrolleeList={enrolleeList} setCustomerData={setCustomerData} showDependants={showDependants} />)}
            </div>
            <Popup showInputDialog={showInputDialog} setShowInputDialog={setShowInputDialog} setrefreshList={setrefreshList} />
        </div>
    );
}

export default EnrolleeList;