function NewEnrolleeForm() {
    return (
        <div className="col-md6 col-md-offset-3">
            <div className="card card-body bg-light">
                <form method="post">
                    <div className="form-group">
                        <label for="firstName">First Name:</label>
                        <input for="firstNAme" className="form-control" />
                    </div>

                    <div className="form-group">
                        <label for="lastName">Last Name:</label>
                        <input for="lastName" className="form-control" />
                    </div>

                    <div className="form-group">
                        <label for="address">Address:</label>
                        <input for="address" className="form-control" />
                    </div>

                    <div>
                        <p></p>
                        <input type="submit" value="Submit" className="btn btn-primary" />
                    </div>
                </form>
            </div>
        </div>
    );
}

export default NewEnrolleeForm;