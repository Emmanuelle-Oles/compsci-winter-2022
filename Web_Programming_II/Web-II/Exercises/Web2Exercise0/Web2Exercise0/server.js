'use strict';
var http = require('http');
//sometimes you need to charge the port 1339 
var port = process.env.PORT || 1337;

/**
 * Returns a message to output to the web page
 * */
function myMessage() {

    const tempC = 13;
    const tempF = temperatureConverter(tempC);
    let message = "the weather is great.\n";
    message += "it is " + tempF;
    return tempF;
}

/**
 * Convert from celcius to fahrenheit. 
*/
function temperatureConverter(tempC) {

    let scale = 9 / 5;
    let increment = 32;
    let fahren = scale * tempC + increment;
    return fahren;

}

http.createServer(function (req, res) {
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    res.write(myMessage());
    res.end('Hello World from Emma\n');
}).listen(port);

