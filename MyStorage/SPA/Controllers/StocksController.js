myStoreApp.controller("StocksController", function ($scope, $http) {
    $scope.views = {
        stockList: false,
        stockForm: false,
        confirmDialog: false,
        changingQuantity: false,
        loadingDialog: true
    };

    $scope.testing = "ABD";

    $scope.supplierParams = {
        suppliers: [],
        selectedSupplier: {}
    };

    $scope.productParams = {
        products: [],
        searchProductName: ""
    };

    $scope.stockParams = {        
        selectedStock: {}
    };

    $scope.formParams = {
        title: "",
        Id: 0,
        selectedSupplier: {},
        selectedProduct: {},
        stockCode: "",
        barCode: "",
        quantity: 0
    };

    $http.get("/Api/Suppliers").then(function (suppliers) {
        $scope.supplierParams.suppliers = suppliers.data;
        $scope.supplierParams.selectedSupplier = $scope.supplierParams.suppliers[0];

        $scope.showSupplierList();
        $scope.serverSentEvents();
    });

    //Private functions
    function AddNewStock(viewModel) {
        $scope.showLoadingPanel();

        $http.post("/Api/Stocks", viewModel).then(function (response) {
            response.data.Product = {
                Id: $scope.formParams.selectedProduct.Id,
                Name: $scope.formParams.selectedProduct.Name
            };
            $scope.supplierParams.selectedSupplier.Stocks.push(response.data);
            $scope.cancel();
        });
    };

    function UpdateStock(viewModel) {
        $scope.showLoadingPanel();
        viewModel.Id = $scope.formParams.Id;

        $http.put("/Api/Stocks/" + viewModel.Id, viewModel).then(function () {
            $scope.stockParams.selectedStock.ProductId = viewModel.ProductId;
            $scope.stockParams.selectedStock.StockCode = viewModel.StockCode;
            $scope.stockParams.selectedStock.BarCode = viewModel.BarCode;
            $scope.stockParams.selectedStock.Quantity = viewModel.Quantity;
            $scope.stockParams.selectedStock.Product.Id = $scope.formParams.selectedProduct.Id;
            $scope.stockParams.selectedStock.Product.Name = $scope.formParams.selectedProduct.Name;

            $scope.cancel();
        });
    };

    function ProcessChanges(changes) {                
        for (var i = 0; i < changes.length; i++) {
            ApplyChange(changes[i]);
        }        
    };

    function ApplyChange(change) {
        for (var i = 0; i < $scope.supplierParams.suppliers.length; i++) {
            if (change.SupplierId === $scope.supplierParams.suppliers[i].Id) {
                var supplier = $scope.supplierParams.suppliers[i];

                for (var j = 0; j < supplier.Stocks.length; j++) {
                    if (change.ProductId === supplier.Stocks[j].ProductId) {
                        supplier.Stocks[j].Quantity = change.NewQuantity;
                        $scope.$apply();

                        break;
                    }
                }

                break;
            }
        }
    };
    ///////////////////

    //Public functions    
    $scope.addNewStock = function () {
        $scope.formParams = {
            title: "Add New Stock",
            Id: 0,
            selectedSupplier: $scope.supplierParams.selectedSupplier,
            selectedProduct: null,
            stockCode: "",
            barCode: "",
            quantity: 0
        };

        $scope.showStockForm();
    };

    $scope.editStock = function (stock) {
        $scope.stockParams.selectedStock = stock;
        $scope.formParams = {
            title: "Edit Stock",
            Id: stock.Id,
            selectedSupplier: $scope.supplierParams.selectedSupplier,
            selectedProduct: stock.Product,
            stockCode: stock.StockCode,
            barCode: stock.BarCode,
            quantity: stock.Quantity
        };

        $scope.productParams = {
            products: [],
            searchProductName: stock.Product.Name
        };

        $scope.showStockForm();
    };

    $scope.editQuantity = function(stock) {
        $scope.showQuantityPanel();        

        $scope.stockParams.selectedStock = stock;
        $scope.stockParams.tempQuantity = stock.Quantity;
    };

    $scope.deleteStock = function(stock) {
        $scope.stockParams.selectedStock = stock;

        $scope.showConfirmDialog();
    };

    $scope.trackSearchProductName = function () {
        $scope.formParams.selectedProduct = null;
        $scope.productParams.products = [];

        if ($scope.productParams.searchProductName.length >= 4) {
            $http.get("/Api/Products?name=" + $scope.productParams.searchProductName).then(function (products) {
                $scope.productParams.products = products.data;
            });
        }
    };

    $scope.selectProduct = function (product) {
        $scope.formParams.selectedProduct = product;
        $scope.productParams.searchProductName = product.Name;
    };

    $scope.notInStock = function (product) {
        for (var i = 0; i < $scope.formParams.selectedSupplier.Stocks.length; i++) {
            if (product.Id === $scope.formParams.selectedSupplier.Stocks[i].Product.Id)
                return false;
        }

        return true;
    };

    $scope.submit = function () {
        var viewModel = {
            SupplierId: $scope.formParams.selectedSupplier.Id,
            ProductId: $scope.formParams.selectedProduct.Id,
            StockCode: $scope.formParams.stockCode,
            BarCode: $scope.formParams.barCode,
            Quantity: $scope.formParams.quantity
        };

        if ($scope.formParams.Id === 0)
            AddNewStock(viewModel);
        else
            UpdateStock(viewModel);
    };

    $scope.submitNewQuantity = function() {
        $scope.showLoadingPanel();

        var stockId = $scope.stockParams.selectedStock.Id;
        var quantity = $scope.stockParams.tempQuantity;

        $http.put("/Api/Stocks?stockId=" + stockId + "&quantity=" + quantity + "&sendMessage=false").then(function() {
            $scope.stockParams.selectedStock.Quantity = quantity;

            $scope.cancel();
        });
    };

    $scope.submitReport = function () {
        $scope.showLoadingPanel();

        var stockId = $scope.stockParams.selectedStock.Id;
        var quantity = $scope.stockParams.tempQuantity;

        $http.put("/Api/Stocks?stockId=" + stockId + "&quantity=" + quantity + "&sendMessage=true").then(function () {
            $scope.stockParams.selectedStock.Quantity = quantity;

            $scope.cancel();
        });
    };

    $scope.confirmDelete = function () {
        $scope.showLoadingPanel();

        $http.delete("/Api/Stocks/" + $scope.stockParams.selectedStock.Id).then(function() {
            $scope.supplierParams
                .selectedSupplier.Stocks
                .splice($scope.supplierParams.selectedSupplier.Stocks.indexOf($scope.stockParams.selectedStock), 1);

            $scope.cancel();
        });
    };

    $scope.cancel = function () {
        $scope.formParams = {
            title: "",
            Id: 0,
            selectedSupplier: {},
            selectedProduct: {},
            stockCode: "",
            barCode: "",
            quantity: 0
        };

        $scope.stockParams = {
            selectedStock: {}
        };

        $scope.productParams = {
            products: [],
            searchProductName: ""
        };

        $scope.showSupplierList();
    };

    $scope.showSupplierList = function () {
        $scope.views = {
            stockList: true,
            stockForm: false,
            confirmDialog: false,
            loadingDialog: false
        };
    };

    $scope.showStockForm = function () {
        $scope.views = {
            stockList: false,
            stockForm: true,
            confirmDialog: false,
            loadingDialog: false
        };
    };

    $scope.showLoadingPanel = function () {
        $scope.views = {
            stockList: true,
            stockForm: false,
            confirmDialog: false,
            loadingDialog: true
        };
    };

    $scope.showConfirmDialog = function () {
        $scope.views = {
            stockList: true,
            stockForm: false,
            confirmDialog: true,
            loadingDialog: false
        };
    };

    $scope.showQuantityPanel = function() {
        $scope.views.changingQuantity = true;
    };

    $scope.getButtonClass = function(quantity) {
        if (quantity <= 3)
            return "btn-danger";

        if (quantity > 3 && quantity <= 7)
            return "btn-warning";

        return "btn-success";
    };

    $scope.getTextClass = function(quantity) {
        if (quantity <= 3)
            return "text-danger";

        if (quantity > 3 && quantity <= 7)
            return "text-warning";

        return "text-success";
    };

    $scope.quantityBtnClick = function(value) {
        $scope.stockParams.tempQuantity += value;
    };

    $scope.serverSentEvents = function() {
        $scope.source = new EventSource("/Stocks/UpdateEvent");        

        $scope.source.onmessage = function (event) {            
            var result = JSON.parse(event.data);

            if (result.length > 0) {
                ProcessChanges(result);
            } 
        };        
    };

    $scope.getProgressBarClass = function (quantity) {
        if (quantity <= 3)
            return "progress-bar-danger";

        if (quantity > 3 && quantity <= 7)
            return "progress-bar-warning";

        return "progress-bar-success";
    };
})