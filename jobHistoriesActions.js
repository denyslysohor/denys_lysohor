const JobHistoriesActions = {
	GET_ALL_JOB_HISTORIES: "jobhistsGetAll", // GET: /api/JobHistories
	GET_JOB_HISTORY: "jobhistsGetById", //GET: /api/JobHistories/{id}
	EMPLOY: "jobhistsEmploy", //POST: /api/JobHistories
	UNEMPLOY: "jobhistsUnemploy" //POST: /api/JobHistories
}
Object.freeze(JobHistoriesActions);

const JobHistoriesActionCreators = {
	getAllJobHistories: function(jobHists){
		return {
			type: JobHistoriesActions.GET_ALL_JOB_HISTORIES,
			data: jobHists
		};
	},
	getJobHistory: function(jobHist){
		return {
			type: JobHistoriesActions.GET_JOB_HISTORY,
			data: jobHist
		};
	},
	employ: function(jobHist){
		return {
			type: JobHistoriesActions.EMPLOY,
			data: jobHist
		};
	},
	unemploy: function(jobHist){
		return {
			type: JobHistoriesActions.UNEMPLOY,
			data: jobHist
		}
	}
}
Object.freeze(JobHistoriesActionCreators);

export {JobHistoriesActions, JobHistoriesActionCreators};