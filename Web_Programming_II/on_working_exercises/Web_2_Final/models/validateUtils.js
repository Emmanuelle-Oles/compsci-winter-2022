const validator = require('validator');
/**
 * Validates the specified name and type.
 * @param {*} name Name of the pokemon.
 * @param {*} type Type of the pokemon.
 * @returns If the name and/or type are invalid, returns false. If the name and type are valid, true.
 */
 function isValid1(name, type) {

    const typePokemon = ["normal", "grass", "fire", "water", "psychic"];
    if((name != ""))
    {
        for(let i = 0; i < typePokemon.length; i++)
        {
            if(typePokemon[i].toLowerCase() == type.toLowerCase())
            {
                return true;
            }
        }

        return false;
    }
    else
        return false;

}

/**
 * Validates specified name and type of pokemon.
 * @param {*} name Name of the pokemon.
 * @param {*} type Type of the pokemon.
 * @returns If name and/or type are valid, true. If name and type are not valid, false.
 */
 function isValid2(name, type) {

    const typePokemon = ["normal", "grass", "fire", "water", "psychic"];

    if(validator.isAlpha(name))
    {
        for(let i = 0; i < typePokemon.length; i++)
        {
            if(typePokemon[i].toLowerCase() == type.toLowerCase())
            {
                return true;
            }
        }
        return false;
    }
    else
    {
        return false;
    }
}

module.exports = {
    isValid1,
    isValid2
}