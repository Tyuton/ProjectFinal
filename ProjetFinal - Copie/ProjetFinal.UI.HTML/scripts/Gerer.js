$('.list-group-item').on('click', function () {
    var $this = $(this);
    //$this += '<span class="glyphicon glyphicon-trash">';

    $('.active').removeClass('active');
    $('span').remove();
    $this.toggleClass('active');
    $this.append('<div id="test"><span class="glyphicon glyphicon-trash"></span><span class="glyphicon glyphicon-cog"></span></div>')

    $('#2').show();

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

$('#test').on('click', function () {
    alert('ça marche!');
});

