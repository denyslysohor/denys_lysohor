import { Link } from "react-router-dom";

import { LogotypeBlock } from "./logotypeBlock";

export function NavBar(props) {
  return (
    <nav className={!!props.footer ? "App__nav" : "App__nav header"}>
      <ul>
        {!props.footer && (
          <li className="App-icon-wrapper">
            <Link to="/">
              <LogotypeBlock />
            </Link>
          </li>
        )}
        <li>
          <Link to="/registration">Registration form</Link>
        </li>
        <li>
          <Link to="/Game">Judge game</Link>
        </li>
        <li>
          <Link to="/Cars/">Cars marks</Link>
        </li>
      </ul>
      {!!props.footer && <div className="footer__info">D.L. (c) 2021</div>}
    </nav>
  );
}
