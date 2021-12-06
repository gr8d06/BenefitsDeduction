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





        /*
                <header className="row" style={{ border: "solid black 2px" }}>
                    <div className="col-md-3 " style={{ border: "solid blue 2px", paddingTop: "10px" }}>
                        <img src={mainLogo} className="mainLogo" alt="mainLogo" />
                    </div>
        
                    <div className="col-md-9 mt-5 subtitle" style={{ border: "solid red 2px", float: "left" }}>
                        Welcome to your new benefits landing page!
                    </div>
                </header>
        */
    );
}

export default Header;