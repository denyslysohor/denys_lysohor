import { useEffect, useRef, useState } from "react";
import { Members } from "../logic/members.js";
export function BossPanel(props) {
  if (!props.member) return <div className="error" children="Нет данных" />;
  const member = props.member;
  const [subordinates, setSubordinates] = useState(
    Members.getSubordinates(member)
  );

  const isInitialMount = useRef(true);
  const freezeUpdate = useRef(false);
  const updateSubordinates = () => {
    setSubordinates(Members.getSubordinates(member));
  };
  useEffect(() => {
    if (isInitialMount.current) {
      isInitialMount.current = false;
    } else if (!freezeUpdate.current) {
      freezeUpdate.current = true;
      updateSubordinates();
    } else {
      freezeUpdate.current = false;
    }
  });

  return (
    <div className="boss">
      <div className="boss__employees">
        <h3>Управление подчиненными</h3>
        <ul className="boss__employees__list">
          {subordinates.map((m, i) => (
            <li key={i} className="boss__employees__list__employee">
              <span className="boss__employees__list__employee__name">
                {m.name}
              </span>
              <div
                className="boss__employees__list__employee__fire"
                title="Уволить"
                onClick={() => {
                  Members.unemploy(m);
                  updateSubordinates();
                }}
              />
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}
