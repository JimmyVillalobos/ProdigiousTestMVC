'use strict';
(function () {
    var app = angular.module('mainApp');

    app.factory('ProductService', ['ApiService', function (apiService) {

        return {
            getProductList: function (userId) {
                return apiService.call('Product', '');
            },

            getProduct: function (productId) {
                return apiService.call('Product', productId);
            }
        };
    }]);
})();
