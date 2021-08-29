import {useState, useEffect} from 'react';
import {Link, Redirect} from "react-router-dom";
import ManagerCard from "./ManagerCard";

import {useSelector, useDispatch} from 'react-redux';
import XHR from '../../logic/XHR';
import { ManagersActionCreators } from '../../logic/store/actions/managersActions';
import { JobHistoriesActionCreators } from '../../logic/store/actions/jobHistoriesActions';

function ManagersList(props){
	const [allState,dispatch] = [useSelector(state=>state), useDispatch()];
	const state = allState.managers;
	const jobHistories = allState.jobHistories.list;
	const [page,setPage] = useState(props.page);
	const pageItems = 10;
	const [isLastPage,setIsLastPage] = useState(state.list.length < page*pageItems);
	const [filterEmployed,setFilterEmployed] = useState(undefined);

	useEffect(()=>{
		XHR.sendXHRGetForm(XHR.backendURI+'Managers',{},(data)=>{
			try {
				dispatch(ManagersActionCreators.getAllManagers(JSON.parse(data)));
			} catch (e) {
				alert('Некорректный ответ сервера');
			}
		});
		XHR.sendXHRGetForm(XHR.backendURI+'JobHistories',{},(data)=>{
			try {
				dispatch(JobHistoriesActionCreators.getAllJobHistories(JSON.parse(data)));
			} catch (e) {
				alert('Некорректный ответ сервера');
			}
		});
	},[]);

	const managers = (
		state.list.filter(e => {
			function byShop(){
				if (!props.shop) return true;
				for (let jh of jobHistories) {
					if (jh.shopId === props.shop.id && jh.managerId === e.managerId) return true;
				}
				return false;
			}
			function byEmployed(){
				if (filterEmployed === undefined) return true;
				return e.isEmployee == filterEmployed;
			}
			return byShop() && byEmployed();
		}).slice((page-1) * pageItems, Math.min(page*pageItems, state.list.length))
	);
	
	function gotoPage(newPage){
		setPage(newPage);
		setIsLastPage(state.list.length < newPage*pageItems);
	}
	if (!(page>=1) || (page>1 && (!managers || managers.length===0))){
		gotoPage(1);
		return <Redirect to="./1" />;
	}
	return (
		<div className="managers">
			<button children={"Работа: "+(filterEmployed===undefined?"Любой статус":(filterEmployed?"есть":"нет"))} onClick={()=>{
				switch (filterEmployed) {
					case undefined:
						setFilterEmployed(true);
						gotoPage(1);
						break;
					case true:
						setFilterEmployed(false);
						gotoPage(1);
						break;
					case false:;
					default:
						setFilterEmployed(undefined);
						gotoPage(1);
				}
			}} />
			{managers && managers.length>0 ? (
				<>
					<h2 className="managers__title">Менеджеры</h2>
					{page>1 && !props.onSelect && (
						<Link className="managers__page-link" to={'./'+(page-1)} onClick={()=>{
							setPage(page-1);
							gotoPage(page-1);
						}}>
							<div className="managers__page-link__container">
								Предыдущая страница
							</div>
						</Link>
					)}
					{page>1 && !!props.onSelect && (
						<button className="managers__page-button" onClick={()=>{
							setPage(page-1);
							gotoPage(page-1);
						}}>
							Предыдущая страница
						</button>
					)}
					<ul className="managers__list">
						{managers.map((v,i) => (
							<li key={'mc_'+i} className="managers__list__item" onClick={() => {
								if (!!props.onSelect) {
									props.onSelect(v);
								}
							}}>
								<ManagerCard enableLink={!props.onSelect} id={v.id} firstName={v.firstName} lastName={v.lastName} isEmployee={v.isEmployee} />
							</li>
						))}
					</ul>
					{!isLastPage && !!props.onSelect && (
						<button className="managers__page-button" onClick={()=>{
							setPage(page+1);
							gotoPage(page+1);
						}}>
							Следующая страница
						</button>
					)}
					{!isLastPage && !props.onSelect && (
						<Link className="managers__page-link" to={'./'+(page+1)} onClick={()=>{
							setPage(page+1);
							gotoPage(page+1);
						}}>
							<div className="managers__page-link__container">
								Следующая страница
							</div>
						</Link>
					)}
				</>
			) : (
				<h2 className="managers__title_empty">Нет результатов</h2>
			)}
		</div>
	);
}

export default ManagersList;