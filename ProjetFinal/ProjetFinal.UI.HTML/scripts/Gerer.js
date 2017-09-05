
function myClick () {
    var $this = $(this);
    //$this += '<span class="glyphicon glyphicon-trash">';

    $('.active').removeClass('active');
    $('#test').remove();
    $this.toggleClass('active');
    $this.append('<div id="test"><span id="span1" class="glyphicon glyphicon-trash"></span><span id="span2" class="glyphicon glyphicon-cog"></span></div>')
    $('#span1').on('click',function (sender) {
       + alert('ça marche! span 1');
    });
    $('#span2').on('click', function (sender) {
        alert('ça marche! span 2');
    });

    $('#2').show();

    showModifySelectedItem($this[0]);
}

$('.list-group-item').on('click', myClick);

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
    var liste = $('#QueryList');
    var value = $('#currentQuery').val();
    
    if (!(value == null || value == '')) {
        //$this.append('<a href="#" class="list-group-item query" name="query">' + value + '</a>');
        liste.append('<a href="#" class="list-group-item query" name="query">' + value + '</a>');
        var last = $('#QueryList >.query')[$('#QueryList >.query').length - 1];
        last.onclick = myClick;
    }

    $('#currentQuery').html('');       
});


//$('#test').on('click', function (sender) {
//    alert('ça marche!');
//});

