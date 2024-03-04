document.querySelector('nav a').classList.remove('active');

const menu_home = document.getElementById("menu_home");
const menu_about = document.getElementById("menu_about");
const menu_cliente = document.getElementById("menu_cliente");

let url = window.location.href;
let split = url.split('/');
let rota = split[split.length - 1];
if (!isNaN(rota)) {
    rota = split[split.length - 2];
}


switch (rota.toLowerCase()) {
    case 'adicionar':
    case 'editar':
    case 'excluir':
    case 'clientes':
        menu_cliente.classList.add('active');
        break;
    case 'about':
        menu_about.classList.add('active');
        break;
    default:
        menu_home.classList.add('active');
        break;
}
