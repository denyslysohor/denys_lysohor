import { BrowserRouter as Router, Link, Route, Switch } from "react-router-dom";

import "./styles.scss";
import { Members } from "./logic/members.js";
import { Member } from "./components/Member.js";
import { BossPanel } from "./components/BossPanel.js";
import { useState } from "react";

export default function App() {
  const [myMemberIndex, setMyMemberIndex] = useState(0);

  const [members, setMembers] = useState(Members.members);
  const updateMembers = () => {
    setMembers(Members.members);
  };
  Members.unemployListeners.push(updateMembers);

  return (
    <div className="App">
      <Router>
        <div style={{ marginBottom: "0.5em" }}>
          <label>
            Управлять от имени:&nbsp;
            <select
              onChange={(e) => {
                setMyMemberIndex(
                  e.target.children[e.target.selectedIndex].value
                );
              }}
            >
              {members.map((v, i) => (
                <option key={`boss_opt_${i}`} value={i}>
                  {v.name}
                </option>
              ))}
            </select>
          </label>
        </div>
        <hr />
        <Switch>
          <Route path="/boss" exact>
            <div>
              <Link to="/">На главную</Link>
            </div>
            <BossPanel member={Members.members[myMemberIndex]} />
          </Route>
          <Route path="/" exact>
            <Member member={Members.members[myMemberIndex]} />
          </Route>
        </Switch>
      </Router>
    </div>
  );
}
