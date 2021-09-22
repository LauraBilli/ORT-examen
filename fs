const fs = require('fs');
const dir = './files';

let parametros = process.argv.splice(2);

if(parametros[0] == 'count'){
    contar();
}else{
    if(parametros[0] == 'size'){
        tamanios();
    }else{
        if(parametros[0] == 'length'){
            caracteres();
        }
    }
}

function contar(){
    fs.readdir(dir, (err, archivos) => {
        console.log(`Cantidad de archivos: ${archivos.length}`);
        });
}
    
function tamanios(){

    fs.writeFileSync('summary.txt','');

    fs.readdir(dir, (err, archivos) => {
        archivos.forEach(element => {
            let texto =  `${element} ${buscarTamanioKB(element)} kb\n`;
            fs.appendFileSync('summary.txt', texto)
        });

    });
}

function buscarTamanioKB(archivo){
    let arch = fs.readFileSync(dir + "//" + archivo);
    return arch.byteLength/1024;
}

function caracteres(){
    fs.writeFileSync('summary.txt','');

    fs.readdir(dir, (err, archivos) => {
        archivos.forEach(element => {
            let texto =  `${element} ${buscarCaracteres(element)} chars\n`;
            fs.appendFileSync('summary.txt', texto)
        });

    });
}

function buscarCaracteres(archivo){
    let arch = fs.readFileSync(dir + "//" + archivo);
    return arch.toString().length;
}