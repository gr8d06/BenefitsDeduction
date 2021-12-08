function Toolbar({ showDependants, setShowDependants, setShowInputDialog }) {
    return (
        <div className="row align-items-start">
                <ul className="list-group">
                    <li className="col-s-3 list-group-item">
                        <button onClick={() => setShowInputDialog(true)}>Enter New Employee</button>
                    </li>
                    <li className="col-s-3 list-group-item">
                        <label>Show Dependants &nbsp;</label>
                        <input type="checkbox"
                            checked={showDependants}
                            onChange={(event) => { setShowDependants(event.target.checked); }}
                        />
                    </li>
                </ul>
            </div>
        
    );
}

export default Toolbar;