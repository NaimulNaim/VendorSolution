app.controller("LocationSetupController", ["$scope", "$http", function ($scope, $http) {

    //#region Variables Declaration

    $scope.loading = false;
    $scope.editFlag = 0;
    $scope.initBoxLocation = function () {
        $scope.boxLocation = {
            BoxLocationID: "",
            UDLocationName: "",
            LocationName: "",
            Building: "",
            Floor: "",
            Room: "",
            OthersAddress: "",
            Remarks: "",
        };
    };
    $scope.initBoxLocation();
    $scope.pagingInfo = {
        page: 1,
        itemsPerPage: 10,
        sortBy: null,
        reverse: false,
        search: null,
        totalItems: 0
    };

    //#endregion Variables Declaration

    //#region Load Data

    $scope.getBoxLocations = function () {
        $scope.loading = true;
        $http.get("/CBPSModule/LocationSetup/GetBoxLocations", {
            params: {
                page: $scope.pagingInfo.page, itemsPerPage: $scope.pagingInfo.itemsPerPage, sortBy: $scope.pagingInfo.sortBy, reverse: $scope.pagingInfo.reverse,
                search: $scope.pagingInfo.search
            }
        })
            .then(
            function (response) {
                $scope.boxLocationList = [];
                $scope.boxLocationDisplayCollection = [];

                $scope.boxLocationList = response.data.locations;
                $scope.boxLocationDisplayCollection = [].concat($scope.boxLocationList);
               // $scope.pagingInfo.totalItems = $scope.boxLocationList[0].TotalPages;
                $scope.loading = false;
            },
            function () {
                $scope.locationList = [];
                $scope.loading = false;
            }
            );
    };

    $scope.getBoxLocations();

    $scope.loadLocation = function () {

        $http.get("/CBPSModule/LocationSetup/GetAllLocations")
            .then(
            function (response) {
                $scope.locationList = [];
                $scope.locationList = response.data.result;
            },
            function () {
                $scope.locationList = [];
                $scope.loading = false;
            }
            );
    };

    $scope.loadBuilding = function (locationId) {
        if (locationId) {
            $http.get("/CBPSModule/LocationSetup/GetAllBuildingByLocation", { params: { "locationId": locationId } })
                .then(
                function (response) {
                    $scope.buildingList = [];
                    $scope.buildingList = response.data.result;
                },
                function () {
                    $scope.buildingList = [];
                    $scope.loading = false;
                }
                );
        }
    };

    $scope.loadFloor = function (buildingId) {
        if (buildingId) {
            $http.get("/CBPSModule/LocationSetup/GetAllFloorByBuilding", { params: { "buildingId": buildingId } })
                .then(
                function (response) {
                    $scope.floorList = [];
                    $scope.floorList = response.data.result;
                },
                function () {
                    $scope.floorList = [];
                    $scope.loading = false;
                }
                );
        }
    };

    $scope.loadRoom = function (floorId) {
        if (floorId) {
            $http.get("/CBPSModule/LocationSetup/GetAllRoomByFloor", { params: { "floorId": floorId } })
                .then(
                function (response) {
                    $scope.roomList = [];
                    $scope.roomList = response.data.result;
                },
                function () {
                    $scope.roomList = [];
                    $scope.loading = false;
                }
                );
        }
    };

    $scope.sort = function (sortBy) {
        if (sortBy === $scope.pagingInfo.sortBy) {
            $scope.pagingInfo.reverse = !$scope.pagingInfo.reverse;
        } else {
            $scope.pagingInfo.sortBy = sortBy;
            $scope.pagingInfo.reverse = false;
        }
        $scope.pagingInfo.page = 1;
        $scope.getBoxLocations();
    };

    $scope.wildSearch = function () {
        if ($scope.pagingInfo.search.length > 2 || $scope.pagingInfo.search.length === 0) {
            $scope.pagingInfo.page = 1;
            $scope.pagingInfo.sortBy = null;
            $scope.pagingInfo.reverse = false;
            $scope.getBoxLocations();
        }
    }


    //#endregion Load Data

    //#region Open/Close Modal

    $scope.addNew = function () {
       
        $scope.initBoxLocation();
        $scope.loadLocation();
        $("#locationEntryModal").modal("show");
    }

    $scope.editLocation = function (row) {
        $scope.loading = true;
        $scope.initBoxLocation();
        $scope.boxLocation.BoxLocationID = row.BoxLocationID;
        $scope.boxLocation.UDLocationName = row.UDLocationName;
        $scope.loadLocation();
        $scope.boxLocation.LocationName = row.LocationName;
        $scope.loadBuilding(row.LocationName);
        $scope.boxLocation.Building = row.Building;
        $scope.loadFloor(row.Building);
        $scope.boxLocation.Floor = row.Floor;
        $scope.loadRoom(row.Floor);
        $scope.boxLocation.Room = row.Room;
        $scope.boxLocation.OthersAddress = row.OthersAddress;
        $scope.boxLocation.Remarks = row.Remarks;
        $scope.loading = false;
        $scope.editFlag = 1;
        $("#locationEntryModal").modal("show");
    };

    //#endregion

    //#region Set Data

    $scope.setLocation = function () {
        if ($scope.boxLocation) {
            $http.post("/CBPSModule/LocationSetup/SetLocation/", JSON.stringify(convArrToObj($scope.boxLocation)))
                .success(function (data) {
                    if (data._respStatus.ErrorCode === "S201" || data._respStatus.ErrorCode === "S202") {
                        $scope.loading = false;
                        $scope.getBoxLocations();
                        $('#locationEntryModal').modal('hide');
                        toastr.success(data._respStatus.Message);

                    } else if (data._respStatus.ErrorCode === "E707") {
                        $scope.loading = false;
                        $('#locationEntryModal').modal('hide');
                        toastr.error('Location with same combination exists');

                    } else if (data._respStatus.ErrorCode === "E708") {
                        $scope.loading = false;
                        $('#locationEntryModal').modal('hide');
                        toastr.error('Location with same user defined location exists');
                    } else {
                        $scope.loading = false;
                        $('#locationEntryModal').modal('hide');
                        toastr.error(data._respStatus.Message);
                    }
                })
                .error(function () {
                    $scope.loading = false;
                    $('#locationEntryModal').modal('hide');
                    toastr.error('Save/Update Failed.');
                });
        }
    };



    //#endregion Set Data


}]);