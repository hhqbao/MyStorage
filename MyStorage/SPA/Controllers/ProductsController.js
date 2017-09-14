myStoreApp.controller("ProductsController",
    function ($scope, $http) {
        $scope.views = {
            productList: false,
            productForm: false,
            confirmDialog: false,
            loadingDialog: true
        };

        $scope.filter = {            
            CategoryDtos: [],
            SelectedCategory: {}
        };

        $scope.products = [];

        $scope.formValues = {            
            Name: "",            
            selectedCategory: {},
            selectedType: {}
        };

        $scope.selectedProduct = {};

        $scope.supplierDtos = [];

        $scope.categoryDtos = [
            { Id: 0, Name: "Select Category" }
        ];        

        $http.get("/Api/Products").then(function (response) {
            $scope.products = response.data;
            $scope.views.loadingDialog = false;
            $scope.views.productList = true;            
        });

        $http.get("/Api/Suppliers").then(function (response) {
            $scope.supplierDtos = $.extend(true, [], response.data);            
        });

        $http.get("/Api/Categories").then(function (response) {
            $scope.filter.CategoryDtos = $.extend(true, [], response.data);
            $scope.filter.SelectedCategory = $scope.filter.CategoryDtos[0];
            $scope.categoryDtos = $.merge($scope.categoryDtos, response.data);
        });

        $scope.categorySelectionChange = function () {
            if ($scope.formValues.selectedCategory.CategoryTypes.length > 0) {
                $scope.formValues.selectedType = $scope.formValues.selectedCategory.CategoryTypes[0];
            } else {
                $scope.formValues.selectedType = null;
            }
        };

        $scope.Create = function () {
            $scope.formTitle = "Add New Product";
            $scope.formValues.Id = 0;                      
            $scope.formValues.Name = "";                        
            $scope.formValues.selectedCategory = $scope.categoryDtos[0];
            $scope.views = {
                productList: false,
                productForm: true
            };
        };

        $scope.Edit = function (product) {
            $scope.selectedProduct = product;
            $scope.formValues.Id = product.Id;            
            $scope.formValues.Name = product.Name;                        
            $scope.formValues.selectedCategory = $scope.findElement($scope.categoryDtos, product.Category.Id);

            if (product.CategoryType != null)
                $scope.formValues.selectedType = $scope
                    .findElement($scope.formValues.selectedCategory.CategoryTypes, product.CategoryType.Id);
            else {
                $scope.formValues.selectedType = null;
            }

            $scope.showForm();
        };

        $scope.Delete = function (product) {
            $scope.selectedProduct = product;

            $scope.showDialog();
        };

        $scope.ConfirmDelete = function () {
            $scope.views.confirmDialog = false;
            $scope.views.loadingDialog = true;

            var viewModel = {
                Id: $scope.selectedProduct.Id
            };

            $http.delete("/Api/Products/" + viewModel.Id).then(function() {
                $scope.products.splice($scope.products.indexOf($scope.selectedProduct), 1);

                $scope.views.loadingDialog = false;
                $scope.Cancel();
            });
        };

        $scope.Cancel = function () {
            $scope.formValues = {};
            $scope.selectedProduct = {};
            $scope.views = {
                productList: true,
                productForm: false,
                confirmDialog: false
            };
        };

        $scope.saveProduct = function () {
            $scope.views.loadingDialog = true;

            var viewModel = {                
                Name: $scope.formValues.Name,                               
                CategoryId: $scope.formValues.selectedCategory.Id
            };

            if ($scope.formValues.selectedCategory.CategoryTypes.length > 0)
                viewModel.CategoryTypeId = $scope.formValues.selectedType.Id;
            else
                viewModel.CategoryTypeId = null;

            if ($scope.formValues.Id === 0) {
                //Create new product
                $http.post("/Api/Products", viewModel).then(function (response) {                    
                    response.data.Category = $scope.formValues.selectedCategory;

                    if ($scope.formValues.selectedType != null) {
                        response.data.CategoryTypeId = $scope.formValues.selectedType.Id;
                        response.data.CategoryType = $scope.formValues.selectedType;
                    }

                    $scope.products.push(response.data);
                    $scope.views.loadingDialog = false;
                    $scope.showList();
                });
            } else {
                //Update product
                viewModel.Id = $scope.formValues.Id;
                $http.put("/Api/Products", viewModel).then(function () {                    
                    $scope.selectedProduct.Name = viewModel.Name;                    
                    $scope.selectedProduct.Category = $scope.formValues.selectedCategory;
                    $scope.selectedProduct.CategoryType = $scope.formValues.selectedType;
                    $scope.selectedProduct.CategoryTypeId = viewModel.CategoryTypeId;

                    $scope.views.loadingDialog = false;
                    $scope.showList();
                });
            }
        };

        $scope.showList = function () {
            $scope.views = {
                productList: true,
                productForm: false
            };
        };

        $scope.showForm = function () {
            $scope.views = {
                productList: false,
                productForm: true
            };
        };

        $scope.showDialog = function () {
            $scope.views.confirmDialog = true;
        };

        $scope.findElement = function (inputArray, inputValue) {
            if (inputArray != null && inputArray.length > 0) {
                for (var i = 0; i < inputArray.length; i++) {
                    if (inputArray[i].Id === inputValue) {
                        return inputArray[i];
                    }
                }
            }

            return null;
        };               
    });