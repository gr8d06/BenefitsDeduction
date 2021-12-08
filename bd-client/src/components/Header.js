import mainLogo from '../mainLogo.svg';

function Header() {
    return (
        <div className="padT4 padB4">
            <div className="container mobile-container">
                <div className="d-flex justify-content-between">
                    <div>
                        <img src={mainLogo} className="mainLogo" alt="mainLogo" />
                    </div>
                    <div className="light">
                        <h4 className="header-title">
                            Your Employee Benefits Landing Page!
                        </h4>
                    </div>
                    <div className="text-dark">
                        Hello User &nbsp;&nbsp;
                        <span>
                            <a href="#">sign-out</a>
                        </span>

                    </div>
                </div>
            </div>
        </div>
    );
}

export default Header;