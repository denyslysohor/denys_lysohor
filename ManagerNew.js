import {useState} from "react";
import {useDispatch} from 'react-redux';

function ManagerNew(props){
	const dispatch = useDispatch();
	const [nameValue, setNameValue] = useState("");
	const [surnameValue, setSurnameValue] = useState("");
	return (
		<div className="manager-new">
			<h3 className="manager-new__title">Добавить менеджера</h3>
			<input type="text" className="manager-new__input" value={nameValue} onInput={(e)=>{setNameValue(e.target.value);}} placeholder="Имя" />
			<input type="text" className="manager-new__input" value={surnameValue} onInput={(e)=>{setSurnameValue(e.target.value)}} placeholder="Фамилия" />
			<button className="manager-new__submit" onClick={() => {
				if (!!props.onSubmit) {
					props.onSubmit({
						"name": nameValue,
						"surname": surnameValue
					});
				}
			}}>
				Добавить
			</button>
		</div>
	);
}

export default ManagerNew;