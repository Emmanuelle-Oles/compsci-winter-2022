const mysql = require('mysql2/promise');
const utilsAsync = require('../utilitiesAsync.js');
const { isValid2 } = require('./validateUtils.js');

var connection;

async function initialize() {

    connection = await mysql.createConnection({
        host: 'localhost',
        user: 'root',
        port: '10000',
        password: 'pass',
        database: 'pokemon_db'
    });

    const sqlQuery = 'CREATE TABLE IF NOT EXISTS pokemon(id int AUTO_INCREMENT, name VARCHAR(50), type VARCHAR(50), PRIMARY KEY(id))';

    await connection.execute(sqlQuery).then(console.log("Table pokemon created/exists")).catch((error) => {console.error(error)});
}

async function addPokemon(name, type){


    if(isValid2(name, type))
    {
     
        const sqlQuery = 'INSERT INTO pokemon (name, type) VALUES (\"' + name + '\"' + '\" \"' + type + '\"' + ')';

        await connection.execute(sqlQuery).then(console.log("Pokemon added")).catch(console.log("Error"));
        return 
    }
}

module.exports = {
    initialize
}