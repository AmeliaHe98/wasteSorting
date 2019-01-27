########### Python 2.7 #############
########### Python 3.2 #############
import http.client, urllib.request, urllib.parse, urllib.error, base64

headers = {
    # Request headers
    'Prediction-Key': '11e72bfc042a4fcfb1322f0eacc1ce37',
    'Content-Type': 'application/json'
}

params = urllib.parse.urlencode({
    # Request parameters
    'iterationId': '2'
})
try:
    conn = http.client.HTTPSConnection('southcentralus.api.cognitive.microsoft.com')
    conn.request("POST", "/customvision/v2.0/Prediction/4994269d-d254-41bb-9f9c-4cfbcdbe4a85/url?%s" % params, '{"Url": "http://cdnimg2.webstaurantstore.com/images/products/extra_large/12689/310269.jpg"}', headers)
    response = conn.getresponse()
    data = response.read()
    print(data)
    conn.close()
except Exception as e:
    print("[Errno {0}] {1}".format(e.errno, e.strerror))

####################################
