
const fs = require('fs');

/**
 * Reading Json data from a file.
 * @param {any} filename
 */

function readFromJsonFile(filename) {
    var rawText = fs.readFileSync(filename);
    var parsedJson = JSON.parse(rawText.toString());
    return parsedJson;
}
/**
 * Writing to Json data 
 * @param {any} filename
 * @param {any} data
 */
function writeToJsonFile(filename, data) {
    var stringToWrite = JSON.stringify(data);
    fs.writeFileSync(filename, stringToWrite);
}


module.exports = {
    readFromJsonFile,
    writeToJsonFile,
};
