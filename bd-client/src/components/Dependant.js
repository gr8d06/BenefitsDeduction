function Dependant(props) {
    const { id, firstName, lastName, enrolledDate, isActive, relation } = props;
    return (
        <div key={id} className="col-md-6 border border-success">
            <div>Name: {firstName} {lastName} </div>
            <div>Id: {id}</div>
            <div>Enrolled Date: {new Date(enrolledDate).toLocaleDateString("en-US")}</div>
            <div>Active: {isActive.toString()}</div>
            <div>Relation: {relation}</div>
        </div>
    );
}

export default Dependant;