function Toolbar({ showDependants, setShowDependants, setShowInputDialog }) {
    return (
        <div className="d-flex justify-content-center">
            <div className="m-2">
                <button onClick={() => setShowInputDialog(true)}>Enter New Employee</button>
            </div>

            <div className="m-2">
                <input type="checkbox" className="form-check-input me-1"
                    checked={showDependants}
                    onChange={(event) => { setShowDependants(event.target.checked); }}
                />
                Show Dependants
            </div>
        </div>

    );
}

export default Toolbar;