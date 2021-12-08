//snippet rfce
import NewEnrolleeForm from "./NewEnrolleeForm";

function Popup(props) {
    const { showInputDialog, setShowInputDialog } = props;
    return (showInputDialog) ? (
        <div className="popup">
            <div className="popup-inner">
                <h3>Enter new enrollee information</h3>
                <NewEnrolleeForm />
                <button className="close-btn" onClick={() => setShowInputDialog(false)}>
                    Close
                </button>
            </div>
        </div>
    ) : "";
}

export default Popup
