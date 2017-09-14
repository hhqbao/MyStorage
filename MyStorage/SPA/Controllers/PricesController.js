myStoreApp.controller("PricesController", function ($scope, $http) {    
    $scope.priceDtos = [];
    $scope.formValues = {};

    $scope.deletingPrice = {};
    $scope.selectedPrice = {};    

    $scope.$watch("productId", function() {
        $http.get("/Api/Prices?productId=" + $scope.productId).then(function(response) {
            $scope.priceDtos = response.data;
        });
    });

    $scope.views = {
        loadingDialog: false,
        confirmDialog: false,
        AddingPrice: false,
        EdittingPrice: false
    };

    $scope.Save = function () {
        $scope.views.loadingDialog = true;

        var viewModel = {
            ProductId: $scope.productId,
            Unit: $scope.formValues.Unit,
            Value: $scope.formValues.Value
        };

        if ($scope.formValues.Id === 0) {
            //Add New Price to product
            $http.post("/Api/Prices", viewModel).then(function(response) {
                $scope.priceDtos.push(response.data);

                $scope.Cancel();
            });
        } else {
            //Update Price
            viewModel.Id = $scope.formValues.Id;
            $http.put("/Api/Prices", viewModel).then(function() {
                $scope.selectedPrice.Unit = viewModel.Unit;
                $scope.selectedPrice.Value = viewModel.Value;

                $scope.Cancel();
            });
        }
    };

    $scope.Edit = function(priceDto) {
        $scope.selectedPrice = priceDto;
        $scope.formValues.Id = $scope.selectedPrice.Id;
        $scope.formValues.Unit = $scope.selectedPrice.Unit;
        $scope.formValues.Value = $scope.selectedPrice.Value;
        $scope.views.EdittingPrice = true;
    };

    $scope.Create = function () {
        $scope.formValues.Id = 0;
        $scope.views.AddingPrice = true;
    };

    $scope.Delete = function(selectedPrice) {
        $scope.deletingPrice = selectedPrice;

        $scope.showConfirmDialog();
    };

    $scope.ConfirmDelete = function() {
        $scope.views.confirmDialog = false;
        $scope.views.loadingDialog = true;

        $http.delete("/Api/Prices/" + $scope.deletingPrice.Id).then(function() {
            $scope.priceDtos.splice($scope.priceDtos.indexOf($scope.deletingPrice), 1);

            $scope.Cancel();
        });
    };

    $scope.Cancel = function () {
        $scope.formValues = {};
        $scope.selectedPrice = {};        
        $scope.views = {
            loadingDialog: false,
            confirmDialog: false,
            AddingPrice: false,
            EdittingPrice: false
        };
    };

    $scope.showConfirmDialog = function() {
        $scope.views.confirmDialog = true;
    };
});