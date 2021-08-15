import { BrowserRouter as Router, Switch, Route } from "react-router-dom";

import logo from "./logo.svg";
import "./App.css";
import Judge from "./components/judge";
import { Registration } from "./components/registration";
import { CarsPage } from "./components/carsPage";

import { NavBar } from "./components/navbar";
import { WeatherWidget } from "./components/weatherWidget.js";

function App() {
  return (
    <div className="App">
      <Router basename="/">
        <NavBar />
        <main className="App__main">
          <div className="App__subpage-wrapper">
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
          </div>
          <div className="App__weather-widget-wrapper">
            <WeatherWidget />
          </div>
        </main>
        <NavBar footer={true} />
      </Router>
    </div>
  );
}

export default App;
