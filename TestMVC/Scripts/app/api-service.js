'use strict';
(function () {
    var app = angular.module('mainApp');

	// The ApiService is a generic service that can be injected in local APIService that needs to call an WebAPI on the server
	//
	// This service only have one method called 'call'
    app.factory('ApiService', ['$http', '$log', function ($http, $log) {

		return {

			// Call method
			// serviceName (REQUIRED): string containing the ApiController name on the server
			// method (REQUIRED): string containing the method name of the service
			// params (OPTIONAL): an object that contains parameters and value for each parameter where class member must match each parameter name
			// data (OPTIONAL): data is used to send complex data to the server, this is useful when you need to send large data that could exceed the URL maximum length
			call: function (serviceName, method, params, data) {

				//Add the JSON_CALLBACK to the params
				//The client script requires that we specify the callback to send data to. AngularJs has its own callback pattern,
				//so it would follow that it has a pattern to handle Jsonp callbacks. It does. The callback is always called JSON_CALLBACK
   				var jsonParams = angular.merge({}, {json_callback:'JSON_CALLBACK'}, params);

				//Create Options needed to do a JSONP request
   				var options = {
   					url: 'api/' + serviceName + '/' + method,		//Build the url of the API
   					params: jsonParams,								//Add params send to the function plus the JSON_CALLBACK
   					cache: false,									//Always force the browser to not use the cache
   					format: 'jsonp'									//Specify the request format ar JSONP
   				}

				//If data is provided, we add it to the options class and change the method to POST
   				if (data !== undefined) {
   					options.method = 'POST';
   					options.data = angular.toJson(data);			//Encode data to JSON
   				}

   				return $http(options).then(function successCallback(response) {
                    // this callback will be called asynchronously
                    // when the response is available
   				    return response.data;
                }, function errorCallback(response) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.

                    console.log('Error:' + response.data.ExceptionMessage);
                });
   			}
        };
    }]);
})();
