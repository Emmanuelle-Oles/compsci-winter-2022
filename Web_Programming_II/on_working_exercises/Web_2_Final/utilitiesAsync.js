const fs = require('fs');
const fsPromises = fs.promises;
 
/**
 
*  Read JSON data from given file and return it.
* 
* @param {any} filename
*/
async function readFromJsonFile(filename) {
    try 
    {
        const rawText =  await fsPromises.readFile(filename);
        const parsedJson = JSON.parse(rawText.toString());
        return parsedJson;
        
    }
    catch (error) 
    {
        // by default we return undefined -> we need to fix it 
        console.log(error);
        //option 1 -> throw to main to handle it 
        // throw error;

        //option 2 -> return what would fix the error : this causes addPokemon to be "successful"
        // is this a good idea? ,,, no
        
        return [];

        
        
    }
}
 
/**
*  Write the given data to the given file in Json format.
* @param {any} filename
* @param {any} data
*/
async function writeToJsonFile(filename, data) {
    try
    {
        const stringToWrite = JSON.stringify(data);
        await fsPromises.writeFile(filename, stringToWrite);
        
    } 
    catch (error)
    {
        console.log(error)
        
    }

}
 
module.exports = {
   readFromJsonFile,
   writeToJsonFile
}
