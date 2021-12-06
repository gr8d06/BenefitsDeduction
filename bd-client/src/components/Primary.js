import Dependant from "./Dependant";

function Primary({ enrolleeList, showDependants }) {
    const { id, first, last, address, enrolledDate, active, policyNumber, primaryId, relation, dependants } = enrolleeList;
    return (
        <div key={id} className="primary">
            <div>Name: {first} {last} </div>
            <div>Id: {id} Enrolled Date: {enrolledDate} Active: {active.toString()}</div>
            <div>Address: {address} Policy Number: {policyNumber} Primary Id: {primaryId} Relation: {relation}</div>
            {
                showDependants === true ?
                    dependants.map(dependant => <Dependant {...dependant} />) : null
            }
        </div>
    );
}

export default Primary;