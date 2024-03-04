let _id = 0;
let _myModal;
let _tipo;
let _url

function excluir(id, nome, tipo, url) {

    const body = `${tipo} ${nome}`;
    document.getElementById("modalBody-desc").textContent = body;
    _myModal = new bootstrap.Modal(document.getElementById('excluirModal'), {
        keyboard: false
    });

    _id = id;
    _tipo = tipo;
    _url = url + '/';

    _myModal.show();
}

function confirmDel() {
    fetch(_url + _id, { method: 'delete' })
        .then((response) => {
            _myModal.hide();
            //console.log(response);
            let mensagem = { error: false, msg: '' };
            response.text().then(text => {
                console.log(text);

                switch (response.status) {
                    case 204:
                        mensagem.error = false;
                        mensagem.msg = text ? text : `${_tipo} Excluído!`;
                        break;
                    case 400:
                        mensagem.error = true;
                        mensagem.msg = text ? text : `${_tipo} não existe!`;
                        break;
                    default:
                        mensagem.error = true;
                        mensagem.msg = text ? text : "Erro ao tentar excluir!";
                        break;
                }

                if (mensagem.error) {
                    toastr.error(mensagem.msg, "Erro!");
                }
                else {
                    toastr.success(mensagem.msg, "Sucesso!");
                    document.getElementById('item-' + _id).remove();
                }
            });
        });
}