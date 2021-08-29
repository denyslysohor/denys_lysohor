const ManagersActions = {
	GET_ALL_MANAGERS: "mgrGetAll", // GET: /api/Managers
	GET_MANAGER: "mgrGetById", //GET: /api/Managers/{id}
	ADD_MANAGER: "mgrAdd" //POST: /api/Managers
}
Object.freeze(ManagersActions);

const ManagersActionCreators = {
	getAllManagers: function(mgrs){
		return {
			type: ManagersActions.GET_ALL_MANAGERS,
			data: mgrs
		};
	},
	getManager: function(mgr){
		return {
			type: ManagersActions.GET_MANAGER,
			data: mgr
		};
	},
	addManager: function(mgr){
		return {
			type: ManagersActions.ADD_MANAGER,
			data: mgr
		};
	}
}
Object.freeze(ManagersActionCreators);

export {ManagersActions, ManagersActionCreators};