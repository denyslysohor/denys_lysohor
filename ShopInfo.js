import {useState, useEffect} from 'react';
import {Link} from 'react-router-dom';
import XHR from '../../logic/XHR';
import {useDispatch,useSelector} from 'react-redux';
import { ManagersActionCreators } from '../../logic/store/actions/managersActions';
import { ShopsActionCreators } from '../../logic/store/actions/shopsActions';
import ManagersList from '../managers/ManagersList';

function ShopInfo(props){
	const [state,dispatch] = [useSelector(state=>state), useDispatch()];
	const shopId = props.shopId;
	const [shop, setShop] = useState(null);
	const [managers, setManagers] = useState([]);
	useEffect(()=>{
		XHR.sendXHRGetForm(XHR.backendURI+'Managers/',{},(data)=>{
			dispatch(ManagersActionCreators.getAllManagers(JSON.parse(data)));
			let managers = state.managers.list.filter(v=>v.shopId === shopId);
			setManagers(managers);
		},(status,data)=>{
			if (status) alert('Не удалось загрузить данные. Код ошибки: '+status+(data?'\n'+data:''));
			else alert('Не удалось связаться с сервером');
		});
		XHR.sendXHRGetForm(XHR.backendURI+'Shops/'+shopId,{},(data)=>{
			dispatch(ShopsActionCreators.getShop(JSON.parse(data)));
			console.log(state.shops.viewing);
			setShop(state.shops.list[state.jobHistories.viewing]);
		},(status,data)=>{
			if (status) alert('Не удалось загрузить данные. Код ошибки: '+status+(data?'\n'+data:''));
			else alert('Не удалось связаться с сервером');
		});
	},[]);
	return (
		<div className="shop-info">
			{shop?
			<>
				<h2 className="shop-info__name">{shop.name}</h2>
				<p className="shop-info__address">{shop.address}</p>
				<p><Link to={"/Employment/"+shopId}>Нанять менеджера в магазин</Link></p>
				{managers && managers.length>0 && (
					<div className="shop-info__managers">
						{/*<h3 className="shop-info__managers__title">Менеджеры:</h3>
						<ul className="shop-info__managers__list">
							{managers.map((v,i) => <li className="shop-info__managers__list__item" key={'sli_'+i}>{JSON.stringify(v)}</li>)}
						</ul>*/}
						<ManagersList page={1} shop={shopId} />
					</div>
				)}
			</> :
			<p className="loading">...</p>
			}
		</div>
	);
}

export default ShopInfo;