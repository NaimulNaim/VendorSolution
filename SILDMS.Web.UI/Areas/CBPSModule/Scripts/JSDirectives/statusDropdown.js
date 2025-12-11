

app.directive("statusDropdown", function () {
    return {
        template: '<div class="form-group">' +
                    ' <label for="Status">Status</label> ' +
                    '<select id="Status" class="form-control" ng-model="ngModel" >' +
                        '<option value="1">Active</option>' +
                        '<option value="0">Inactive</option>' +
                    '</select>' +
                  '</div>',
        replace: true,
        scope: {
            ngModel: '='
        }
    }
});