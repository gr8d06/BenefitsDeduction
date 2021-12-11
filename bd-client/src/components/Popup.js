//snippet rfce
import NewEnrolleeForm from "./NewEnrolleeForm";

function Popup(props) {
    const { showInputDialog, setShowInputDialog, setrefreshList } = props;
    return (showInputDialog) ? (
        <div className="popup">
            <div className="popup-inner">
                <h3>Enter new enrollee information</h3>
                <h6>Currently, form has no validation. For demo only. </h6>
                <NewEnrolleeForm setrefreshList={setrefreshList} setShowInputDialog={setShowInputDialog} />
                <button className="btn btn-primary close-btn" onClick={() => setShowInputDialog(false)}>
                    Close
                </button>
            </div>
        </div>
    ) : "";
}

export default Popup
