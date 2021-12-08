function Dependant(props) {
    const { id, first, last, enrolledDate, active, relation } = props;
    return (
        <div key={id} className="col-md-6 border border-success">
            <div>Name: {first} {last} </div>
            <div>Id: {id}</div>
            <div>Enrolled Date: {enrolledDate}</div>
            <div>Active: {active}</div>
            <div>Relation: {relation}</div>
        </div>
    );
}

export default Dependant;