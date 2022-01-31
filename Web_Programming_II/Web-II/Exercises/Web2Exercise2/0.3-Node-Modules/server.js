'use strict';
var http = require('http');
var port = process.env.PORT || 1339;
const fs = require('fs');
const utils = require('./utilities');

function converterCtoF(celcius) {
    const scale = 9 / 5;
    const increment = 32;
    const fahren = scale * celcius + increment;
    return fahren;

}

http.createServer(function (req, res) {
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    //res.write(myMessage());
    useUtils();
    writeToFile();
    res.write("\n\n" + readFromFile() + "\n\n");
    res.end("Hello World from Emmanuelle\n");
}).listen(port);



function writeToFile() {
    fs.writeToFileSync("core-modules.txt", "this is my data");
}

function readToFile() {
    var content = fs.readFileSync("core-modules.txt");
    return (content.toString());
}

function useUtils(){
    var pokemonData = utils.readFromJsonFile('pokemon.json');
    console.log(pokemonData);
    pokemonData[0].nickname = "grass";
    utils.writeToJsonFile('pokemon.json', pokemonData);
}