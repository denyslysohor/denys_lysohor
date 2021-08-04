import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

import "./App.css";
import Judge from "./judge";
import { Registration } from "./registration";
import { CarsPage } from "./carsPage";

function App() {
  return (
    <div className="App">
      <Router basename="/">
        <nav className="App__nav">
          <ul>
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
          <hr />
        </nav>
        <Switch>
          <Route path="/Game" exact>
            <Judge />
          </Route>
          <Route path="/registration" exact>
            <Registration />
          </Route>
          <Route path="/Cars/">
            <CarsPage />
          </Route>
        </Switch>
      </Router>
    </div>
  );
}

export default App;
