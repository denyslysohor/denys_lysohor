import XHR from "../../logic/XHR";
import {useSelector, useDispatch} from 'react-redux';
import { JobHistoriesActionCreators } from "../../logic/store/actions/jobHistoriesActions";
import {useHistory} from 'react-router-dom';
import {useState,useEffect} from 'react';
import { ManagersActionCreators } from "../../logic/store/actions/managersActions";

function ManagerUnemployment(props){ //manager
	const [state,dispatch] = [useSelector(state=>state),useDispatch()];
	const managerId = props.managerId;
	const [manager,setManager] = useState(null);
	useEffect(()=>{
		XHR.sendXHRGetForm(XHR.backendURI+'Managers/'+managerId,{},(data)=>{
			let mgr = JSON.parse(data);
			dispatch(ManagersActionCreators.getManager(mgr));
			setManager(mgr);
		},(status,data)=>{
			if (status) alert('Не удалось загрузить данные. Код ошибки: '+status+(data?'\n'+data:''));
			else alert('Не удалось связаться с сервером');
		})
	},[]);
	const history = useHistory();
	function submit(managerId){
		let activeJob = state.jobHistories.list.filter(e=>(!e.finish && e.managerId === managerId));
		if (!activeJob || activeJob.length === 0) {
			alert("Увольнение невозможно: менеджер не работает");
			return;
		}
		activeJob[0].finishDate = new Date();
		XHR.sendXHRPostJSON(XHR.backendURI+'JobHistories', activeJob[0], (data)=>{
			dispatch(JobHistoriesActionCreators.unemploy(activeJob[0]));
			history.push('/Manager/'+managerId);
		}, (status,data) => {
			if (status) alert('Не удалось завершить увольнение. Код ошибки: '+status+(data?'\n'+data:''));
			else alert('Не удалось связаться с сервером');
		});
	}
	return (
		<div className="manager-unemployment">
			<p className="manager-unemployment__text">Вы подтверждаете увольнение менеджера {manager?manager.firstName+' '+manager.lastName:'...'}?</p>
			<button className="manager-unemployment__ok-button" onClick={()=>{submit(managerId)}}>Да</button>
		</div>
	);
}

export default ManagerUnemployment;