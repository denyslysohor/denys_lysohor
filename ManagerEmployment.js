import {useState} from "react";
import {useDispatch} from 'react-redux';
import {useHistory} from 'react-router-dom';
import { JobHistoriesActionCreators } from "../../logic/store/actions/jobHistoriesActions";
import XHR from "../../logic/XHR";

import ShopsList from "../shops/ShopsList";
import ManagersList from "./ManagersList";

function ManagerEmployment(props){
	//props: shop (ui; db: .id)
	//state: manager (ui; db: .id), mgrSelectMode
	const shopId = props.shopId;
	const dispatch = useDispatch();
	const [manager, setManager] = useState(props.manager || null);
	const [mgrSelectMode, setMgrSelectMode] = useState(false);
	function submit(shopId, managerId){
		let obj = {
			managerId: managerId,
			shopId: shopId,
			start: new Date(),
			finish: null
		};
		XHR.sendXHRPostJSON(XHR.backendURI+'JobHistories',obj,(data)=>{
			obj.id = null; //ВРЕМЕННО (требуется ответ от сервера с id новой записи)
			dispatch(JobHistoriesActionCreators.employ(obj));
			useHistory.push('/Shop/'+shopId);
		},(status,data)=>{
			if (status) alert('Не удалось завершить операцию. Код ошибки: '+status+(data?'\n'+data:''));
			else alert('Не удалось связаться с сервером');
		});
	}
	return (
		<div className="manager-employment">
			{mgrSelectMode ? (
				<>
					<button className="manager-employment__spoiler" onClick={()=>{setMgrSelectMode(false);}}>
						Назад
					</button>
					<ManagersList className="manager-employment__manager-list" onSelect={(manager)=>{
						setManager(manager);
						setMgrSelectMode(false);
					}} />
					<br/>
				</>
			) : (
				<>
					<button className="manager-employment__spoiler" onClick={()=>{setMgrSelectMode(true);}}>
						{manager ? manager.firstName+' '+manager.lastName : <i>Выберите менеджера</i>}
					</button>
					{
						manager && <button className="manager-employment__submit" onClick={()=>{submit(shopId,manager.id);}}>OK</button>
					}
				</>
			)}
		</div>
	);
}

export default ManagerEmployment;