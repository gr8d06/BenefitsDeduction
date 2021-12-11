import Dependant from "./Dependant";
import CostDisplay from "./CostDisplay";

function Primary({ enrolleeList, showDependants }) {
    const { id, firstName, lastName, address, enrolledDate, isActive, policyNumber, dependantsList } = enrolleeList;

    let combinedDeduction = 0;

    return (
        <div key={id} className="col-md-12  border border-primary row">
            <div className="border border-warning col-md-6">
                <div>Name: {firstName} {lastName} </div>
                <div>Id: {id}</div>
                <div>Enrolled Date: {new Date(enrolledDate).toLocaleDateString("en-US")} </div>
                <div>Active: {isActive.toString()}</div>
                <div>Address: {address} </div>
                <div>Policy Number: {policyNumber}</div>
            </div>
            <CostDisplay id={id} totalMonthlyDeduction="100" />
            {
                showDependants === true ?
                    dependantsList.map(dependant => <Dependant {...dependant} />) : null
            }
        </div>
    );
}

export default Primary;