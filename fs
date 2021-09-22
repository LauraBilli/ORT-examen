const fs = require('fs');
const dir = './files';

let parametros = process.argv.splice(2);

if(parametros[0] == 'count'){
    contar();
}

function contar(){
    fs.readdir(dir, (err, archivos) => {
        console.log(`Cantidad de archivos: ${archivos.length}`);
        });
}
    