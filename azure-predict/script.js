angular.module("app",[])
.directive("returnFiles", function() {
  return {
    require: "ngModel",
    link: postLink
  };
  function postLink(scope, elem, attrs, ngModel) {
    elem.on("change", function(event) {
      ngModel.$setViewValue(elem[0].files);
    });
  }
})
.controller("ctrl", function($scope, $http) {
  var url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v2.0/Prediction/b02c1152-2060-43be-b687-c02945327bd2/image?iterationId=84347cf4-1f8f-4808-bd9e-80e2c340b444";
  var config = {
    headers: { 'Content-type': 'application/octet-stream', 
	'Prediction-Key':'e0ce1a50ac584286810648dcb87d986a'}
  };
  $scope.upload = function(files) {
    var promise = $http.post(url,files[0],config);
    promise.then(function(response){
      $scope.result="Success "+JSON.stringify(response.data);
    }).catch(function(errorResponse) {
      $scope.result="Error "+errorRespone.status;
    });
  };
})