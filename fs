const { table } = require('console');
const fs = require('fs');
const dir = './files';

let parametros = process.argv.splice(2);

switch (parametros[0]) {
    case 'count':
        contar();
        break;
    case 'size':
        tamanios();
        break;
    case 'length':
        caracteres();
        break;
    case 'search':
        buscar(parametros.splice(1));
        break;
    default:
        console.log(`El comando "${parametros[0]}" no se reconoce. Los comandos validos son: count, size, length, search`); 
        break;
}


function contar(){
    fs.readdir(dir, (err, archivos) => {
        if(err==null){
            console.log(`Cantidad de archivos: ${archivos.length}`);
        }else{
            console.log(`Error: ${err}`);
        }
    });
}
    
function tamanios(){

    fs.writeFileSync('summary.txt','');

    fs.readdir(dir, (err, archivos) => {
        if(err==null){
            archivos.forEach(element => {
                let texto =  `${element} ${buscarTamanioKB(element)} kb\n`;
                fs.appendFileSync('summary.txt', texto)
            });
        }else{
            console.log(`Error: ${err}`);
        }
    });
}

function buscarTamanioKB(archivo){
    let arch = fs.readFileSync(dir + "//" + archivo);
    return arch.byteLength/1024;
}

function caracteres(){
    fs.writeFileSync('summary.txt','');

    fs.readdir(dir, (err, archivos) => {
        if(err==null){
            archivos.forEach(element => {
                let texto =  `${element} ${buscarCaracteres(element)} chars\n`;
                fs.appendFileSync('summary.txt', texto)
            });
        }else{
            console.log(`Error: ${err}`);
        }
    });
}

function buscarCaracteres(archivo){
    let arch = fs.readFileSync(dir + "//" + archivo);
    return arch.toString().length;
}

function buscar(cadenas){
    if(cadenas.length>0){
        fs.readdir(dir, (err, archivos) => {
            if(err==null){
                let filtrado = archivos.filter(x => incluye(x, cadenas[0]));
                table(filtrado);
            }else{
                console.log(`Error: ${err}`);
            }
        });
    }
}

function incluye(archivo, texto){
    let arch = fs.readFileSync(dir + "//" + archivo);
    return arch.toString().includes(texto);
}