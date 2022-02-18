const fs = require('fs');
 
/**
 
*  Read JSON data from given file and return it.
* 
* @param {any} filename
*/
function readFromJsonFile(filename) {
   try
   {
      const rawText = fs.readFileSync(filename);
      const parsedJson = JSON.parse(rawText.toString());
      return parsedJson;
   }
   catch (error)
   {
      console.log(error);
   }
}
 
/**
*  Write the given data to the given file in Json format.
* @param {any} filename
* @param {any} data
*/
function writeToJsonFile(filename, data) {
   try
   {
      const stringToWrite = JSON.stringify(data);
      fs.writeFileSync(filename, stringToWrite);
   }
   catch(error)
   {
      console.log(error);
   }

}
 
module.exports = {
   readFromJsonFile,
   writeToJsonFile
}
