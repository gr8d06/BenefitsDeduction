function Toolbar({ showDependants, setShowDependants, showInputDialog, setShowInputDialog }) {

    return (
        <section className="toolbar">
            <div className="container">
                <div className="justify-content-between">
                    <ul className="toolrow d-flex flex-column flex-lg-row">
                        <li className="d-flex flex-column flex-md-row">
                            <b>Show Dependants &nbsp;&nbsp;</b>

                            <input
                                type="checkbox"
                                checked={showDependants}
                                onChange={(event) => { setShowDependants(event.target.checked); }}
                            />
                        </li>
                        <li>
                            <button onClick={() => setShowInputDialog(true)}>Enter New Employee</button>
                        </li>
                    </ul>
                </div>
            </div>
        </section>
    );
}

export default Toolbar;