import { useState } from "react";

{/*function PrimaryIdBox(isPrimary) {
    return (isPrimary) ? (<div><label for="primaryId"> Primary's Id: </label>
        <input for="primaryId" className="form-control" /> </div>) : "";
}*/}

function NewEnrolleeForm() {

    const [isPrimary, setisPrimary] = useState(false)

    return (
        <div className="col-md-12">
            <div className="card card-body bg-light">
                <form method="post">
                    <div className="row">
                        <div className="form-group col-md-6">
                            <label for="firstName">First Name:</label>
                            <input for="firstNAme" className="form-control" />
                        </div>

                        <div className="form-group col-md-6">
                            <label for="lastName">Last Name:</label>
                            <input for="lastName" className="form-control" />
                        </div>
                    </div>

                    <div className="row">
                        <div className="form-group col-md-12">
                            <label for="address">Address:</label>
                            <input for="address" className="form-control" />
                        </div>
                    </div>

                    <div className="row">
                        <div className="form-group col-md-2 align-self-center">
                            <label for="isPrimary">Primary Account Holder? &nbsp;</label>
                            <input type="checkbox" className="form-check-input"
                                checked={isPrimary}
                                onChange={(event) => { setisPrimary(event.target.checked); }}
                            />
                        </div>

                        <div className="form-group col-md-5">
                            {/*<PrimaryIdBox isPrimary={isPrimary} />*/}
                            <label for="primaryId"> Primary's Id: </label>
                            <input for="primaryId" className="form-control" />
                        </div>

                        <div className="form-group col-md-5">
                            <label for="relation"> Relation: </label>
                            <input for="relation" className="form-control" />
                        </div>
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