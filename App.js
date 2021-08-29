import { BrowserRouter as Router, Switch, Route, Redirect, Link, matchPath, useHistory } from "react-router-dom";
import {useSelector, useDispatch} from 'react-redux';
import XHR from '../logic/XHR.js';

import ManagerNew from "./managers/ManagerNew";
import ManagersList from "./managers/ManagersList";
import ManagerUnemployment from "./managers/ManagerUnemployment";
import ManagerEmployment from "./managers/ManagerEmployment";
import ManagerInfo from "./managers/ManagerInfo";

import ShopInfo from "./shops/ShopInfo";
import ShopsList from "./shops/ShopsList";
import { ShopsActionCreators } from "../logic/store/actions/shopsActions.js";
import { ManagersActionCreators } from "../logic/store/actions/managersActions.js";

function App() {
	const [state, dispatch] = [useSelector(state=>state), useDispatch()];
	const history = useHistory();
	return (
		<Router basename="/">
			<nav className="app__header-links">
				<ul className="app__header-links__list">
					<li className="app__header-links__list__item">
						<Link to="/Shops">Магазины</Link>
					</li>
					<li className="app__header-links__list__item">
						<Link to="/Managers">Менеджеры</Link>
					</li>
					<li className="app__header-links__list__item">
						<Link to="/AddManager">Добавить менеджера</Link>
					</li>
				</ul>
			</nav>
			<hr/>
			<Switch>
				<Route path="/Shops/" exact>
					<Redirect to="/Shops/1" />
				</Route>
				<Route path="/Shops/:page">
					{
						(()=>{
							let mp = matchPath(window.location.pathname,{
								path:"/Shops/:page",
								exact:true,
								strict:false
							});
							if (!mp || isNaN(mp.params.page)) mp={params:{page:0}};
							return (
								<ShopsList key={'sl_p'+mp.params.page} page={parseInt(mp.params.page)} />
							);
						})()
					}
				</Route>
				<Route path="/Shop" exact>
					<Redirect to="/Shops/" />
				</Route>
				<Route path="/Shop/:id">
					{
						(()=>{
							let mp = matchPath(window.location.pathname,{
								path:"/Shop/:id",
								exact:true,
								strict:false
							});
							if (!mp || isNaN(mp.params.id)) return (
								<Redirect to="/Shops/1" />
							);
							return (
								<ShopInfo shopId={parseInt(mp.params.id)} />
							);
						})()
					}
				</Route>
				<Route path="/AddManager">
					<ManagerNew onSubmit={(data)=>{
						let obj = {
							//TODO: требуется id новой записи в ответ [от сервера] на переданный объект менеджера
							id:null, //временно
							firstName: data.name,
							lastName: data.surname,
							isEmployee: false
						};
						XHR.sendXHRPostJSON(XHR.backendURI+'Managers/',obj,(data)=>{
							//obj.id = JSON.parse(data).id;
							dispatch(ManagersActionCreators.addManager(obj));
							history.push('/Shops/');
						},(status,data)=>{
							if (status) alert('Ошибка: '+data+'\nКод: '+status);
							else alert('Не удалось соединиться с сервером.'+(data ? '\nОшибка: '+data : ''));
						});
					}} />
				</Route>
				<Route path="/Managers/" exact>
					<Redirect to="/Managers/1" />
				</Route>
				<Route path="/Managers/:page">
					{
						(()=>{
							let mp = matchPath(window.location.pathname,{
								path:"/Managers/:page",
								exact:true,
								strict:false
							});
							if (!mp || isNaN(mp.params.page)) mp={params:{page:0}};
							return (
								<ManagersList page={1} shop={null} />
							);
						})()
					}
				</Route>
				<Route path="/Manager" exact>
					<Redirect to="/Managers" />
				</Route>
				<Route path="/Manager/:id">
					{
						(()=>{
							let mp = matchPath(window.location.pathname,{
								path:"/Manager/:id",
								exact:true,
								strict:false
							});
							if (!mp || isNaN(mp.params.id)) return (
								<Redirect to="/Managers/" />
							);
							return (
								<ManagerInfo managerId={parseInt(mp.params.id)} />
							);
						})()
					}
				</Route>
				<Route path="/Employment/:sid">
					{
						(()=>{
							let mp = matchPath(window.location.pathname,{
								path:"/Employment/:sid",
								exact:true,
								strict:false
							});
							if (!mp || isNaN(mp.params.sid)) return (
								<Redirect to="/Shops/" />
							);
							return (
								<ManagerEmployment shopId={parseInt(mp.params.sid)} />
							);
						})()
					}
				</Route>
				<Route path="/Unemployment/:mid">
					{
						(()=>{
							let mp = matchPath(window.location.pathname,{
								path:"/Unemployment/:mid",
								exact:true,
								strict:false
							});
							if (!mp || isNaN(mp.params.mid)) return (
								<Redirect to="/Managers/" />
							);
							return (
								<ManagerUnemployment managerId={parseInt(mp.params.mid)} />
							);
						})()
					}
				</Route>
				<Route path="/" exact>
					<Redirect to="/Shops/" />
				</Route>
			</Switch>
		</Router>
	);
}

export default App;


/*
TODO: стили
*/

/*
BackEnd: Есть магазины, Менеджеры.
Менеджер - может работать только в одном магазине в одно время. Менеджер имеет историю работы в магазинах. Менеджер может нигде не работать, как вообще (еще не приступал к работе) так и в данный момент.

Реализовать функционал:
• Просмотр всех Магазинов.
• Добавление нового менеджера.
• Увольнение менеджера из магазина.
• Устройство менеджера на работу в магазин. 
• Просмотр менеджера, где видно его текущий статус, и историю

Получение менеджеров: С Пагинацией, и фильтрами (upd: на клиенте):
• Фильтры : По магазинам статусу сотрудника, и по отрезку времени. 
• Если фильтры пустые - то показывать всех.

UI: для каждой операции должна быть своя "страница" (Link).
*/