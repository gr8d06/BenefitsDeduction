import React from 'react'
//snippet rfce

function Popup(props) {
    const { showInputDialog, setShowInputDialog } = props;
    return (showInputDialog) ? (
        <div className="popup">
            <div className="popup-inner">
                <h3>new employee popup</h3>
                <button className="close-btn" onClick={() => setShowInputDialog(false)}>
                    Close
                </button>
            </div>
        </div>
    ) : "";
}

export default Popup
