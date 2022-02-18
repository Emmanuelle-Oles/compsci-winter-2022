'use strict';
var http = require('http');
var port = 1337;
// const model = require('./models/pokemonModelFileSync');
const model = require('./models/pokemonModelFileAsync');
// const dbfilename = require('./data/pokemonDatabaseDummy.json')
const dbfilename = './data/pokemonDatabaseDummy.json';
const pokemonMySql = require('./models/pokemonModelMySql');

http.createServer(async function (req, res) {


    res.writeHead(200, {'Content-type': 'text/plain'});

    // docker container 
    await pokemonMySql.initialize();
    await model.initialize(dbfilename, false);
    await model.addPokemon("Eevee", "Psychic");


    // Successful attempt at addPokemonValid1
    const name1a = "Emma";
    const type1a = "Water";

    var resultValid1a = await model.addPokemonValid1(name1a, type1a);

    if(resultValid1a)
    {
        res.write("Successfully added pokemon " + name1a + " of type " + type1a);

    }
    else
    {
        res.write("Failed to add pokemon " + name1a + "of type " + type1a);
    }

    res.write("\n");

    //Unsuccessful attempt at addPokemonValid1
    const name1b = "aly";
    const type1b = "alien";

    var resultValid1b = await model.addPokemonValid1(name1b, type1b);

    if (resultValid1b) {
        res.write("Successfully added pokemon " + name1b + " of type " + type1b);
    }
    else {
        res.write("Failed to add pokemon " + name1b + " of type " + type1b);
    }

    res.write("\n");
    res.write("\n");

    //Successful attempt at addPokemonValid2
    const name2a = "Anna";
    const type2a = "fire";

    var resultValid2a = await model.addPokemonValid2(name2a, type2a);

    if(resultValid2a)
    {
        res.write("Successfully added pokemon " + name2a + " of type " + type2a);

    }
    else
    {
        res.write("Failed to add pokemon " + name2a + " of type " + type2a);
    }

    res.write("\n");


    // Unsuccessful attempt at addPokemonValid2
    const name2b = "Em1234a";
    const type2b = "water";

    var resultValid2b = await model.addPokemonValid2(name2b, type2b);

    if(resultValid2b)
    {
        res.write("Successfully added pokemon " + name2b + " of type " + type2b);

    }
    else
    {
        res.write("Failed to add pokemon " + name2b + " of type " + type2b);
    }
    
    res.write("\n");
    res.write("\n");

    // Successful attempt at findByName
    const name3a = "Emma";
    const type3a = "water";

    var resultValid3a = await model.findByName(name3a);

    if(resultValid3a)
    {
        res.write("Successfully found pokemon " + name3a + " of type " + type3a);

    }
    else
    {
        res.write("Failed to find pokemon " + name3a + " of type " + type3a);
    }

    // Unsuccessful attempt at findByName
    res.write("\n");

    const name3b = "Oleg";
    const type3b = "water";

    var resultValid3b = await model.findByName(name3b);

    if(resultValid3b)
    {
        res.write("Successfully added pokemon " + name3b + " of type " + type3b);

    }
    else
    {
        res.write("Failed to add pokemon " + name3b + " of type " + type3b);
    }

    res.write("\n");
    res.write("\n");
    
    // Successful attempt at ReplacePokemon
    const orginalName4a = "Emma";
    const newName4a = "Pola";
    const newType4a = "fire";

    var resultValid4a = await model.replacePokemon(orginalName4a, newName4a, newType4a)

    if(resultValid4a)
    {
        res.write("Successfully replaced pokemon " + orginalName4a + " new pokemon "+ newName4a + " of type " + newType4a);

    }
    else
    {
        res.write("Failed to replace pokemon " + orginalName4a + " new pokemon "+ newName4a + " of type " + newType4a);
    }
    
    res.write("\n");

    // Unsuccessful attempt at replacePokemon

    const orginalName4b = "sarah";
    const newName4b = "polina";
    const newType4b = "normal";

    var resultValid4b = await model.replacePokemon(orginalName4a, newName4a, newType4b);

    if(resultValid4b)
    {
        res.write("Successfully replaced pokemon " + orginalName4b + " new pokemon "+ newName4b + " of type " + newType4b);

    }
    else
    {
        res.write("Failed to replace pokemon " + orginalName4b + " new pokemon "+ newName4b + " of type " + newType4b);
    }
    
    res.write("\n");
    res.write("\n");

    // Successful attempt at deletePokemon
    const orginalName5a = "Anna";

    var resultValid5a = await model.deletePokemon(orginalName5a);

    if(resultValid5a)
    {
        res.write("Successfully deleted pokemon " + orginalName5a );

    }
    else
    {
        res.write("Failed to delete pokemon " + orginalName5a);
    }
    
    res.write("\n");
    

    // Successful attempt at deletePokemon
    const orginalName5b = "E122mma";

    var resultValid5b = await model.deletePokemon(orginalName5b);

    if(resultValid5b)
    {
        res.write("Successfully deleted pokemon " + orginalName5b );

    }
    else
    {
        res.write("Failed to delete pokemon " + orginalName5b);
    }

    res.write("\n");
    res.end("Bye World :)");


}).listen(port);