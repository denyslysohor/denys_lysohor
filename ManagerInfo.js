import {useState, useEffect} from 'react';
import XHR from '../../logic/XHR';
import "./ManagerInfo.scss";
import {Link} from 'react-router-dom';

import {useSelector,useDispatch} from 'react-redux';
import { ManagersActionCreators } from '../../logic/store/actions/managersActions';
import { JobHistoriesActionCreators } from '../../logic/store/actions/jobHistoriesActions';

function ManagerInfo(props){
	const [state,dispatch] = [useSelector(state=>state), useDispatch()];
	
	const managerId = props.managerId;
	const [manager,setManager] = useState(null);
	const [jobHistory, setJobHistory] = useState(null);

	useEffect(()=>{
		XHR.sendXHRGetForm(XHR.backendURI+'JobHistories',{},(data)=>{
			dispatch(JobHistoriesActionCreators.getAllJobHistories(JSON.parse(data)));
			let managerHists = state.jobHistories.list.filter(v=>v.managerId === managerId);
			setJobHistory(managerHists);
		},(status,data)=>{
			if (status) alert('Не удалось загрузить данные. Код ошибки: '+status+(data?'\n'+data:''));
			else alert('Не удалось связаться с сервером');
		});
		XHR.sendXHRGetForm(XHR.backendURI+'Managers/'+managerId,{},(data)=>{
			dispatch(ManagersActionCreators.getManager(JSON.parse(data)));
			console.log(state.jobHistories.viewing);
			setManager(state.jobHistories.list[state.jobHistories.viewing]);
		},(status,data)=>{
			if (status) alert('Не удалось загрузить данные. Код ошибки: '+status+(data?'\n'+data:''));
			else alert('Не удалось связаться с сервером');
		});
	},[]);
	return (
		<div className="manager">
			{
				manager ?
				<>
					<h2 className="manager__name">{manager.firstName+' '+manager.lastName}</h2>
					{!!manager.isEmployee ? <p className="manager__status">Работает</p> : <p className="manager__status_inactive">Не работает</p>}
					{jobHistory && jobHistory.length>0 && <div className="manager__jobs-history">
						<h3 className="manager__jobs-history__title">Прошлые места работы:</h3>
						<ul className="manager__jobs-history__list">
							{jobHistory.map((v,i) => <li className="manager__jobs-history__list__item" key={'pjp_'+i}>
								<Link to={"/Shop/"+v.shopId}>Магазин #{v.shopId}</Link> (с {v.start}{v.finish?'по '+v.finish:''})
							</li>)}
						</ul>
					</div>}
				</> :
				<p className="loading">...</p>
			}
		</div>
	);
}

export default ManagerInfo;