import Dependant from "./Dependant";
import CostDisplay from "./CostDisplay";

function Primary({ enrolleeList, showDependants }) {
    const { id, firstName, lastName, address, enrolledDate, isActive, policyNumber, primaryId, relation, dependants } = enrolleeList;
    return (
        <div key={id} className="col-md-12  border border-primary row">
            <div className="border border-warning">
                <div>Name: {firstName} {lastName} </div>
                <div>Id: {id} Enrolled Date: {enrolledDate} Active: {isActive.toString()}</div>
                <div>Address: {address} </div>
                <div>Policy Number: {policyNumber} Primary Id: {primaryId} Relation: {relation}</div>
            </div>
            {
                showDependants === true ?
                    dependants.map(dependant => <Dependant {...dependant} />) : null
            }
            <CostDisplay id={id} monthlyDeduction="100" discountRate="20" />
        </div>
    );
}

export default Primary;