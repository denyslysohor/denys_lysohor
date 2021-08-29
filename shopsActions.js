const ShopsActions = {
	GET_ALL_SHOPS: "shopsGetAll", // GET: /api/Shops
	GET_SHOP: "shopsGetById", //GET: /api/Shops/{id}
	ADD_SHOP: "shopsAdd" //POST: /api/Shops
}
Object.freeze(ShopsActions);

const ShopsActionCreators = {
	getAllShops: function(shops){
		return {
			type: ShopsActions.GET_ALL_SHOPS,
			data: shops
		};
	},
	getShop: function(shop){
		return {
			type: ShopsActions.GET_SHOP,
			data: shop
		};
	}
}
Object.freeze(ShopsActionCreators);

export {ShopsActions, ShopsActionCreators};