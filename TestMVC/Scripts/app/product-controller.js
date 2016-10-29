'use strict';

(function () {
    var app = angular.module('mainApp');

    app.controller('ProductController', ['$scope', '$log', 'ProductService', function ($scope, $log, productService) {
        var _that = this;

        this.isLoading = false;
        this.products = [];

        this.UpdateAction = "api/product/"
        this.selectedProduct = { ProductID: 0, Name: 'None' };

        //Retrieve all the list for the products
        this.getProductList = function () {

            _that.isLoading = true;
            var rollReturn = productService.getProductList().then(function (data) {
                //Use data into the push
                _that.products = data;

                _that.isLoading = false;
                return data;
            });
        };

        //Retrieve a product using the Id
        this.getProduct = function (productId) {

            var rollReturn = productService.getProduct(productId).then(function (data) {
                //Use data into the push
                _that.selectedProduct = data;

                _that.UpdateAction = "api/product/" + data.ProductID;
                return data;
            });
        };

        //Init       
        this.initialize = function () {
            _that.getProductList();
        };
    }]);
}());
