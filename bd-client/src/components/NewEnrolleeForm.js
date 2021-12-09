import { useState } from "react";

/*function PrimaryIdBox(isPrimary) {
    return (isPrimary) ? (<div><label for="primaryId"> Primary's Id: </label>
        <input for="primaryId" className="form-control" /> </div>) : "";
}*/

function NewEnrolleeForm() {
    
    const [newEnrollee, setNewEnrollee] = useState({firstName:"", lastName:"", address:"", isPrimary:false, primaryId:0, relation:""})

    const handleSubmit = async (e) => {
        e.preventDefault();
       
        await fetch('http://localhost:8888/enrollees',{
            method: 'POST',
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify(newEnrollee)
        })
    }

    return (
        <div className="col-md-12">
            <div className="card card-body bg-light">
                <form onSubmit={handleSubmit}>
                    <div className="row">
                        <label className="form-group col-md-6" for="firstName">First Name:
                            <input 
                                value={newEnrollee.firstName} 
                                for="firstName" 
                                className="form-control" 
                                onChange={e => setNewEnrollee({...newEnrollee, firstName: e.target.value }) }
                            />
                        </label>

                        <label className="form-group col-md-6" for="lastName">Last Name:
                            <input 
                                value={newEnrollee.lastName} 
                                for="lastName" 
                                className="form-control" 
                                onChange={e => setNewEnrollee({...newEnrollee, lastName: e.target.value }) }
                            />
                        </label>
                    </div>

                    <div className="row">
                        <label className="form-group col-md-12" for="address">Address:
                            <input 
                                value={newEnrollee.address} 
                                for="address" 
                                className="form-control" 
                                onChange={e => setNewEnrollee({...newEnrollee, address: e.target.value }) }
                            />
                        </label>
                    </div>

                    <div className="row">
                        <label className="form-group col-md-2 align-self-center" for="isPrimary">Primary Account Holder? &nbsp;
                            <input 
                                value={newEnrollee.isPrimary} 
                                type="checkbox" 
                                className="form-check-input"
                                checked={newEnrollee.isPrimary}
                                onChange={e => setNewEnrollee({...newEnrollee, isPrimary: e.target.checked }) }
                            />
                        </label>

                        {!newEnrollee.isPrimary && 
                        <>
                            <label className="form-group col-md-5" for="primaryId"> Primary's Id: 
                                <input 
                                value={newEnrollee.primaryId} 
                                for="primaryId" 
                                className="form-control" 
                                onChange={e => setNewEnrollee({...newEnrollee, primaryId: e.target.value }) }
                                />
                            </label>

                            <label className="form-group col-md-5" for="relation"> Relation:
                                <input 
                                value={newEnrollee.relation} 
                                for="relation" 
                                className="form-control" 
                                onChange={e => setNewEnrollee({...newEnrollee, relation: e.target.value }) }
                                />
                            </label> 
                        </>
                        }
                    </div>          

                    <button value="Submit" type="submit" class="btn btn-primary">Submit</button>

                </form>
            </div>
        </div>
    );
}

export default NewEnrolleeForm;