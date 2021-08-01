import { Link } from "react-router-dom";
import { Members } from "../logic/members.js";
export function Member(props) {
  if (!props.member) return <div className="error" children="Нет данных" />;
  const member = props.member;
  return (
    <div className="boss">
      <div className="boss__main">
        <div className="boss__main__name" children={member.name} />
        <Link
          to="/boss"
          className="boss__main__control-button"
          children="Начальник"
        />
      </div>
      <div className="boss__employees">
        <ul className="boss__employees__list">
          {Members.getSubordinates(member).map((m, i) => (
            <li key={i} className="boss__employees__list__employee">
              {m.name}
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}
