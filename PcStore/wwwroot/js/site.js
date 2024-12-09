$(function () {
    if ($('div.alert').length) {
        setTimeout(() => {
            $('div.alert').fadeOut();
        },2000)
    }
});
