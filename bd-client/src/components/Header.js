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
                        Hello User &nbsp;&nbsp;
                        <span>
                            <a href="#">sign-out</a>
                        </span>

                    </div>
                </div>
        </div>
    );
}

export default Header;