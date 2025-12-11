app.service('ownerByCompanyService', ['$http', function ($http) {
    var svm = this;
    
    svm.callFunc = function () {
        $http.get('/CBPSModule/BillProcessStage/GetOwnerByCompany')
               .success(function (response) {
                   return response.result;
                   //console.log(svm.result);
            })
               .error(function () { });
        
    }

}]);