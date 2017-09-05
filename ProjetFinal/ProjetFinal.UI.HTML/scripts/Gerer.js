$('.list-group-item').on('click', function () {
    var $this = $(this);
    //$this += '<span class="glyphicon glyphicon-trash">';

    $('.active').removeClass('active glyphicon glyphicon-trash');
    $this.toggleClass('active glyphicon glyphicon-trash');

    showModifySelectedItem($this[0]);
});

function showModifySelectedItem(selectedItem) {
    var item = selectedItem.text;
    if (selectedItem.name == 'url') {
        $('#currentURL').text(item);
        //$('.textURL').show();
    }
    if (selectedItem.name == 'selector') {
        $('#currentSelector').text(item);
        //$('.textSelector').show();
    }
    if (selectedItem.name == 'query') {
        $('#currentQuery').text(item);
        //$('.textQuery').show();
    }
    //$('.hidden').hide();
}

$('#addQuery').on('click', function () {
    $('.textQuery').show();
    var $this = $('#QueryList');
    var value = $('#currentQuery').val();
    
    if (!(value == null || value == '')) {
        //$this.append('<a href="#" class="list-group-item query" name="query">' + value + '</a>');
        $this.append('<a href="#" class="list-group-item query" name="query">' + value + '</a>');
    }

    $('#currentQuery').html('');
    
    
});

