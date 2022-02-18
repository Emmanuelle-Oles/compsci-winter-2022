const utils = require('../utilities');
const db = './data/pokemonDatabase.json';
const validate = require('./validateUtils');

/**
 * Adds a pokemon to the database with specified name and type.
 */
function addPokemon(name, type) {
    const pokemonData = utils.readFromJsonFile(db, name);
    pokemonData.push({"name": name, "type": type});
    utils.writeToJsonFile(db, pokemonData);
}


/**
 * Adds a validated pokemon to the database.
 * @param {*} name Name of the pokemon.
 * @param {*} type Type of the pokemon.
 * @returns If name and/or type are invalid, null. If the pokemon is valid, 
 * the pokemon added.
 */
function addPokemonValid1(name, type){

    if(!validate.isValid1(name, type))
        return null;
    
    addPokemon(name, type);

    return {"name": name, "type": type};
}



/**
 * Adds valid pokemon to the database.
 * @param {*} name Name of pokemon.
 * @param {*} type Type of pokemon.
 * @returns If pokemon is invalid, null. If the pokemon is valid, 
 * the pokemon added. 
 */
function addPokemonValid2(name, type){
    if(!validate.isValid2(name,type))
        return null;

    addPokemon(name, type);
    return {"name": name, "type": type};
}

/**
 * Finds pokemon in the database using the specified name.
 * @param {*} name Name of pokemon.
 * @returns If pokemon is invalid, null. If the pokemon is valid,
 * the pokemon found.
 */
function findByName(name){

    if(!validate.isValid2(name,"Normal")) //hacky hack we might not need
        return null;


    // getting the data from db
    const pokemonData = utils.readFromJsonFile(db);

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
function replacePokemon(originalName, newName, newType){

    if(!validate.isValid2(originalName, "Normal"))
        return false;

    const pokemonData = utils.readFromJsonFile(db);

    var pokemonFoundIndex = pokemonData.findIndex( (pokemon) =>  pokemon.name == originalName );

    if(pokemonFoundIndex != -1)
    {

        pokemonData[pokemonFoundIndex].name = newName;
        pokemonData[pokemonFoundIndex].type = newType;

        utils.writeToJsonFile(db, pokemonData);
        
        return true;

    }
    else
    {
        return false;
    }
}

/**
 * 
 * @param {*} name The name of pokemon.
 * @returns If the removal was not successful, false. If the removal was successful, true.
 */
function deletePokemon(name){
    if(!validate.isValid2(name, "Normal"))
        return null;

    const pokemonData = utils.readFromJsonFile(db);
    const ONE_ITEM = 1;

    var pokemonFoundIndex = pokemonData.findIndex( (pokemon) =>  pokemon.name == name );

    if(pokemonFoundIndex != -1)
    {
        console.log(pokemonData);
        pokemonData.splice(pokemonFoundIndex, ONE_ITEM );
        console.log(pokemonData);
        return true;
    }
    else
    {
        return false;   
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
    deletePokemon
}