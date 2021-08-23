const XHR = {
	backendURI: "http://192.168.0.127:5000/",
	initXHR: function(){
		var xhr = null;
		if (!!window.XMLHttpRequest) {
			xhr = new window.XMLHttpRequest();
		} else if (!!window.ActiveXObject) {
			xhr = window.ActiveXObject("Microsoft.XMLHTTP");
		}
		return xhr;
	},
	initCommonXHR: function(uri,method,onXHRSuccess,onXHRFail){
		var xhr = XHR.initXHR();
		
		if (!xhr) return null;
		
		xhr.open(method,uri,true);
		xhr.onreadystatechange = function(){
			if (xhr.readyState === 4) {
				if (xhr.status === 200) {
					if (!!onXHRSuccess)
						onXHRSuccess(xhr.responseText);
				} else {
					if (!!onXHRFail)
						onXHRFail(xhr.status, xhr.responseText);
				}
			}
		}
		return xhr;
	},
	sendXHRForm: function(uri,method,args,onXHRSuccess,onXHRFail){
		var xhr = XHR.initCommonXHR(uri, method || "GET", onXHRSuccess, onXHRFail);
		if (!xhr) return null;
		//тип контента запроса
		xhr.setRequestHeader('Content-Type','application/x-www-form-urlencoded');
		//формирование запроса
		var data = "";
		for (var arg in args) {
			if (!!args[arg]) {
				data += arg+"="+args[arg]+"&";
			} else if (!!arg) {
				data += arg+"&";
			}
		}
		if (data[data.length-1] == '&')
			data = data.substring(0,data.length-1);
		xhr.send(data);
	},
	sendXHRGetForm: function(uri,args,onXHRSuccess,onXHRFail){
		XHR.sendXHRForm(uri,"GET",args,onXHRSuccess,onXHRFail);
	},
	sendXHRPostForm: function(uri,args,onXHRSuccess,onXHRFail){
		XHR.sendXHRForm(uri,"POST",args,onXHRSuccess,onXHRFail);
	},
	sendXHRJSON: function(uri,method,obj,onXHRSuccess,onXHRFail){
		var xhr = XHR.initCommonXHR(uri, method || "POST", onXHRSuccess, onXHRFail);
		if (!xhr) return null;
		xhr.setRequestHeader('Content-Type','application/json;charset=UTF-8');
		xhr.send(JSON.stringify(obj));
	},
	sendXHRPostJSON: function(uri,obj,onXHRSuccess,onXHRFail){
		XHR.sendXHRJSON(uri,"POST",obj,onXHRSuccess,onXHRFail);
	}
};
Object.freeze(XHR);
export default XHR;