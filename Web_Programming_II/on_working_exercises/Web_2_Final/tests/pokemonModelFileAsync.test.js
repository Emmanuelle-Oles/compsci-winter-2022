// const { test, expect } = require('@jest/globals');
const model = require('../models/pokemonModelFileAsync');
const utilsAsync = require('../utilitiesAsync');

// const db = './data/pokemonDatabase.json'; // Since this will be used by utilities.js, need '.', not '..’
const db = './data/pokemonDatabaseDummy.json';


/* Data to be used to generate random pokemon for testing */

const pokemonData = [
{ name: 'Bulbasaur', type: 'Grass' },
{ name: 'Charmander', type: 'Fire' },
{ name: 'Squirtle', type: 'Water' },
{ name: 'Pikachu', type: 'Electric' },
{ name: 'Pidgeotto', type: 'Psychic' },
{ name: 'Koffing', type: 'Normal' }

]




/** Since a Pokemon can only be added to the DB once, we have to slice from the array. */

const generatePokemonData = () => {
    const index = Math.floor((Math.random() * pokemonData.length));
    return pokemonData.slice(index, index+1)[0];
}

/* Make sure the database is empty before each test.  This runs before each test.  See https://jestjs.io/docs/api */

beforeEach(async () => {

    try {

        await model.initialize(db, true);
        // await utilsAsync.writeToJsonFile(db, []);

     } catch (err) {}

});


/** Testing function addPokemon with a success case  */
test("Validate function addPokemon [Success]", async () => {
    
    const { name, type } = generatePokemonData();

    await model.addPokemon(name, type); // here we dont need to return anything here bc it 
                                             // updating database and at the end of the day we want
                                             // to compare our database to see if it pass the test

    const result = await utilsAsync.readFromJsonFile(db);
    console.log(result);
    console.log(result[0].name);
    console.log(name.toLowerCase());
    
    expect(Array.isArray(result)).toBe(true);
    expect(result.length).toBe(1); // this is to ensure that only one thing is returned is one result

    expect(result[0].name.toLowerCase() == name.toLowerCase()).toBe(true);
    expect(result[0].type.toLowerCase() == type.toLowerCase()).toBe(true);
    
})

/**  */
test("Validate function addPokemon [Success]", async () => {
    
    const { name, type } = generatePokemonData();

    await model.addPokemonValid2(name, type); // here we dont need to return anything here bc it 
                                             // updating database and at the end of the day we want
                                             // to compare our database to see if it pass the test

    const result = await utilsAsync.readFromJsonFile(db);
    // console.log(result);
    // console.log(result[0].name);
    // console.log(name.toLowerCase());
    
    expect(Array.isArray(result)).toBe(true);
    expect(result.length).toBe(1); // this is to ensure that only one thing is returned is one result

    expect(result[0].name.toLowerCase() == name.toLowerCase()).toBe(true);
    expect(result[0].type.toLowerCase() == type.toLowerCase()).toBe(true);
    
})

/** Testing function addPokemon with a test a failure case using an invalid type.  */
test("Validate function addPokemon using invalid name [Failure]", async () => {
    

    const name = "Pikach0";
    const type = "grass";

    await model.addPokemonValid2(name, type); // here we dont need to return anything here bc it 
                                                                            // updating database and at the end of the day we want
                                                                            // to compare our database to see if it pass the test

    const result = await utilsAsync.readFromJsonFile(db);
    // console.log(result);
    // console.log(result[0].name);
    console.log(name.toLowerCase());
    
    expect(Array.isArray(result)).toBe(true);
    expect(result.length).toBe(1); // this is to ensure that only one thing is returned is one result

    expect(result[0].name.toLowerCase() == name.toLowerCase()).toBe(true);
    expect(result[0].type.toLowerCase() == type.toLowerCase()).toBe(true);
    
})

/** Testing function addPokemon with a test a failure case using an invalid type.  */
test("Validate function addPokemon using invalid type [Failure]", async () => {
    
    const name = "Pikachu";
    const type = "p$ychic"
    await model.addPokemonValid2(name, type); // here we dont need to return anything here bc it 
                                             // updating database and at the end of the day we want
                                             // to compare our database to see if it pass the test

    const result = await utilsAsync.readFromJsonFile(db);

    // console.log(result);
    // console.log(result[0].name);

    console.log(name.toLowerCase());
    
    expect(Array.isArray(result)).toBe(true);
    expect(result.length).toBe(1); // this is to ensure that only one thing is returned is one result

    expect(result[0].name.toLowerCase() == name.toLowerCase()).toBe(true);
    expect(result[0].type.toLowerCase() == type.toLowerCase()).toBe(true);
    
})


test("Validate function findByName [Success]", async () => {

    const { name, type } = generatePokemonData();

    await model.findByName(name, type);

    const result = await utilsAsync.readFromJsonFile(db);

    expect(Array.isArray(result)).toBe(true);
    expect(result.length).toBe(1); 

    expect(result[0].name.toLowerCase() == name.toLowerCase().toBe(true));

})