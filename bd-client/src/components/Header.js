import mainLogo from '../mainLogo.svg';

function Header() {
    return (
        <div className="row align-items-center">
                <div className="d-flex justify-content-between">
                    <div>
                        <img src={mainLogo} className="mainLogo" alt="mainLogo" />
                    </div>
                    <div>
                        <h4 className="header-title">
                            Your Employee Benefits Landing Page!
                        </h4>
                    </div>
                    <div>
                        Hello User 
                    </div>
                </div>
        </div>
    );
}

export default Header;