const fs = require('fs');
const dir = './files';

let parametros = process.argv.splice(2);

if(parametros[0] == 'count'){
    contar();
}else{
    if(parametros[0] == 'size'){
        tamanios();
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
            let texto =  `${element} ${buscarTamanio(element)} kb\n`;
            fs.appendFileSync('summary.txt', texto)
        });

    });

}

function buscarTamanio(archivo){
    let arch = fs.readFileSync(dir + "//" + archivo);
    return arch.byteLength;
}