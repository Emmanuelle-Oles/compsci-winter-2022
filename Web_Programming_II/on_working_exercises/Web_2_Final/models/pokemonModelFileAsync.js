// const utils = require('../utilities'); // old 
const utilsAsync = require('../utilitiesAsync.js');
// const db = './data/pokemonDatabase.json';
var db;
const validate = require('./validateUtils');


/**
 * Adds a pokemon to the database with specified name and type.
 */
async function addPokemon(name, type) {
    const pokemonData = await utilsAsync.readFromJsonFile(db, name);
    pokemonData.push({"name": name, "type": type});
    await utilsAsync.writeToJsonFile(db, pokemonData);
    return true;
}


/**
 * Adds a validated pokemon to the database.
 * @param {*} name Name of the pokemon.
 * @param {*} type Type of the pokemon.
 * @returns If name and/or type are invalid, null. If the pokemon is valid, 
 * the pokemon added.
 */
async function addPokemonValid1(name, type){

    if(!validate.isValid1(name, type))
        return null;
    
    await addPokemon(name, type);

    return {"name": name, "type": type};
}



/**
 * Adds valid pokemon to the database.
 * @param {*} name Name of pokemon.
 * @param {*} type Type of pokemon.
 * @returns If pokemon is invalid, null. If the pokemon is valid, 
 * the pokemon added. 
 */
async function addPokemonValid2(name, type){
    if(!validate.isValid2(name,type))
        return null;

    await addPokemon(name, type);
    return {"name": name, "type": type};
}

/**
 * Finds pokemon in the database using the specified name.
 * @param {*} name Name of pokemon.
 * @returns If pokemon is invalid, null. If the pokemon is valid,
 * the pokemon found.
 */
async function findByName(name){

    if(!validate.isValid2(name,"Normal")) //hacky hack we might not need
        return null;


    // getting the data from db
    const pokemonData = await utilsAsync.readFromJsonFile(db);

    var pokemonFound = pokemonData.find( (pokemon) => { return pokemon.name === name;} );

    if(pokemonFound)
        return pokemonFound;
    else
        return null;

}


/**
 * Replaces the name and type of a pokemon in the database using the specified name.
 * @param {*} originalName The name of the original pokemon.
 * @param {*} newName The name of the new pokemon.
 * @param {*} newType The type of the new pokemon.
 * @returns If the replacement fails, null. If the replacement is successful,
 * true.
 */
async function replacePokemon(originalName, newName, newType){

    if(!validate.isValid2(originalName, "Normal"))
        return false;

    const pokemonData = await utilsAsync.readFromJsonFile(db);

    var pokemonFoundIndex = pokemonData.findIndex( (pokemon) =>  pokemon.name == originalName );

    if(pokemonFoundIndex != -1)
    {

        pokemonData[pokemonFoundIndex].name = newName;
        pokemonData[pokemonFoundIndex].type = newType;

        await utils.writeToJsonFile(db, pokemonData);
        
        return true;

    }
    else
    {
        return false;
    }
}

/**
 * Deletes specified pokemon from database;
 * There's some bugs here pls fix it emma.  
 * @param {*} name The name of pokemon.
 * @returns If the removal was not successful, false. If the removal was successful, true.
 */
async function deletePokemon(name){
    if(!validate.isValid2(name, "Normal"))
        return null;

    const pokemonData = await utilsAsync.readFromJsonFile(db);
    const ONE_ITEM = 1;

    var pokemonFoundIndex = pokemonData.findIndex( (pokemon) =>  pokemon.name == name );

    if(pokemonFoundIndex != -1)
    {
        // console.log(pokemonData);
        pokemonData.splice(pokemonFoundIndex, ONE_ITEM );
        // console.log(pokemonData);
        return true;
    }
    else
    {
        return false;   
    }
}

/**
 * Initializes the database. If the reset 
 * @param {*} dbFilename 
 * @param {*} resetFlag 
 */
async function initialize(dbFilename, resetFlag)
{

    db = dbFilename;
    var emptyDB = "[]";

    if(resetFlag)
    {
        await utilsAsync.writeToJsonFile(emptyDB);
    }
    else
    {
        try
        {  
            var result = await utilsAsync.readFromJsonFile(db);
            if(result)
            {
                console.log("Initializing file-base database to use existing file " + db);
            }
            else
            {
                throw new Error("no file");
            }
        }
        catch
        {
            await utilsAsync.writeToJsonFile(db, emptyDB);
            console.log("Initializing file-base database to use newly created file " + db);
        }
    }

}

/**
 * To have access to the functions.
 */

module.exports = {
    addPokemon,
    addPokemonValid1,
    addPokemonValid2,
    findByName,
    replacePokemon,
    deletePokemon,
    initialize
}