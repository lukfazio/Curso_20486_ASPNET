$.validator.setDefaults({
    highlight: (element) => {
        $(element).closest('div.mb-3').find('input,label,select,textarea').addClass('is-invalid');
    },
    unhighlight: (element) => {
        $(element).closest('div.mb-3').find('input,label,select,textarea').removeClass('is-invalid');
    }
})
