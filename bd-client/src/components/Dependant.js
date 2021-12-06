function Dependant(props) {
    const { id, first, last, enrolledDate, active, relation } = props;
    return (
        <div key={id} className="dependant">
            <div>Name: {first} {last} </div>
            <div>Id: {id}</div>
            <div>Enrolled Date: {enrolledDate}</div>
            <div>Active: {active.toString()}</div>
            <div>Relation: {relation}</div>
        </div>
    );
}

export default Dependant;