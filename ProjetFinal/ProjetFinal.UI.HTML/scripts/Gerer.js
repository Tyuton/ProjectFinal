$('.list-group-item').on('click', myClickQuery);

function myClickQuery() {
    var $this = $(this);
    //$this += '<span class="glyphicon glyphicon-trash">';

    $('.active').removeClass('active');
    $('#glyphicon').remove();

    $this.toggleClass('active');

    $this.append('<div id="glyphicon"><span id="span1" class="glyphicon glyphicon-trash"></span><span id="span2" class="glyphicon glyphicon-cog"></span></div>')

    $('#span2').on('click', function () {
        //alert('ça marche! span 1');
        $this.empty();
        var t = document.createElement('textarea');
        t.style.color = "black";
        t.text = $this.text;
        $this.text = "";
        $this.append(t);
        t.focus();
        $(t).keyup(function (e) {
            var code = e.which;
            if (code == 13) e.preventDefault();
            if (code == 13) {
                var liste = $('#QueryList');
                var value = $('textarea').val();
                value = value.substring(0, value.length - 1);
                var a = document.createElement('a'); 
                a.classList.add('list-group-item');
                a.classList.add('query');
                a.name = 'query';
                a.innerText = value;
                a.onclick = myClickQuery;
                $($this).replaceWith(a);
            }
        });
    });   
    showModifySelectedItem($this[0]);

    $('#span1').on('click', function () {
        $('#QueryList').remove(this);
        //$(this).replaceWith();
    });
}



$('#addQuery').on('click', function () {
    //var $this = $(this);
    var liste = $('#QueryList');
    var t = document.createElement('textarea')
    t.style.color = "black";
    liste.append(t);
    t.focus();
    //var $this = t;
    //$this.text = t.text;
    //$this.text = "";
    $(t).keyup(function (e) {
        var code = e.which;
        if (code == 13) e.preventDefault();
        if (code == 13) {              
            var value = $('textarea').val();
            value = value.substring(0, value.length - 1);
            var a = document.createElement('a');
            a.classList.add('list-group-item');
            a.classList.add('query');
            a.name = 'query';
            a.innerText = value;
            a.onclick = myClickQuery;
            $(t).replaceWith(a);
        }
    });
            showModifySelectedItem(t);
});


function showModifySelectedItem(selectedItem) {
    var item = selectedItem.text;
    $('#selectedQuery').css("visibility", "hidden");
    $('#selectedURL').css("visibility", "hidden");

    if (selectedItem.name == 'url') {
        $('#currentURL').text(item);
        $('#selectedURL').css("visibility", "visible");
    }
    if (selectedItem.name == 'selector') {
        $('#currentSelector').text(item);
        //$('.textSelector').show();
    }
    if (selectedItem.name == 'query') {
        $('#currentQuery').text(item);
        $('#selectedQuery').css("visibility", "visible");
    }

}
//$('#span2').on('click', myTest);

//function myTest() {

//    var t = document.createElement('textarea');
//    t.style.color = "black";
//    t.text = $this.text;
//    $this.text = "";
//    $this.append(t);
//    t.focus();
//    $(t).keyup(function (e) {
//        var code = e.which;
//        if (code == 13) e.preventDefault();
//        if (code == 13) {
//            var liste = $('#QueryList');
//            var value = $('textarea').val();
//            value.replace("\n", "");
//            var a = ($($this).replaceWith('<a href="#" class="list-group-item query" name="query">' + value + '</a>'));
//            a.onclick = myClickQuery;
//        }
//    });
//}






//$('#addQuery').on('click', function () {
//    $('#queryTextArea').css("visibility", "visible");
//});

//$('#addURL').on('click', function () {
//    $('#urlTextArea').css("visibility", "visible");
//});


//$('#okAddQuery').on('click',function () {
//   $('.textQuery').show();
//    var liste = $('#QueryList');
//   var value = $('#addQueryField').val();

//    if (!(value == null || value == '')) {
//    $this.append('<a href="#" class="list-group-item query" name="query">' + value + '</a>');
//    liste.append('<a href="#" class="list-group-item query" name="query">' + value + '</a>');
//    var last = $('#QueryList >.query')[$('#QueryList >.query').length - 1];
//    last.onclick = myClick;
//    }

//    $('#addQueryField').html('');
//    $('#queryTextArea').css("visibility", "hidden");
//});

$('#okAddURL').on('click', function () {
    $('.textURL').show();
    var liste = $('#UrlList');
    var value = $('#addURLField').val();

    if (!(value == null || value == '')) {
        //$this.append('<a href="#" class="list-group-item query" name="query">' + value + '</a>');
        liste.append('<a href="#" class="list-group-item url" name="url">' + value + '</a>');
        var last = $('#UrlList >.url')[$('#UrlList >.url').length - 1];
        last.onclick = myClick;
    }

    $('#addURLField').html('');
    $('#urlTextArea').css("visibility", "hidden");
});

//$('#test').on('click', function (sender) {
//    alert('ça marche!');
//});

