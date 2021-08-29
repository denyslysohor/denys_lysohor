import {useState, useEffect} from 'react';
import {Link} from "react-router-dom";

function ManagerCard(props){
	const [currentJobPlace, setCurrentJobPlace] = useState(null);
	useEffect(()=>{
		//xhr запрос: достать место работы => setCurrentJobPlace()
	}, []);
	function info(props){
		return (
			<div className="manager-card__container">
				<h3 className="manager-card__container__name">{props.firstName+' '+props.lastName}</h3>
				{!!props.isEmployee ? <p className="manager-card__container__status">Работает{!!currentJobPlace && <> в {currentJobPlace}</>}</p> : <p className="manager-card__container__status_inactive">Не работает</p>}
			</div>
		);
	}
	return (
		!!props.enableLink ? (
			<Link className="manager-card" to={'/Manager/'+props.id} children={info(props)} />
		) : (
			<div className="manager-card" children={info(props)} />
		)
	);
}

export default ManagerCard;