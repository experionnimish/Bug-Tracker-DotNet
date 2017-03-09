$('.container').on('click', '.panel-heading span.filter', function (e) {
    var $this = $(this),
        $panel = $this.parents('.panel');
    $panel.find('.panel-filter').slideToggle();
    if ($this.css('display') != 'none') {
        $panel.find('.panel-filter input').focus();
    }
});