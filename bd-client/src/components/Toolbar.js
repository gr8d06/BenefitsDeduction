function Toolbar({ showDependants, setShowDependants, showInputDialog, setShowInputDialog }) {
    return (
        <div className="secondary-nav-container container">
            <div className="row">
                <ul className="list-group">
                    <li className="col-s-3 list-group-item">
                        <label>Show Dependants &nbsp;</label>
                        <input type="checkbox"
                            checked={showDependants}
                            onChange={(event) => { setShowDependants(event.target.checked); }}
                        />
                    </li>
                    <li className="col-s-3 list-group-item">
                        <button onClick={() => setShowInputDialog(true)}>Enter New Employee</button>
                    </li>
                </ul>
            </div>
        </div>
    );
}

export default Toolbar;