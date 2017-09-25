//Requetes

//Highlight de la requête selectionnée
$('.query').on('click', myClickQuery);
function myClickQuery() {
    var $this = $(this);
    if ($this.hasClass('query') == true) {
        if ($this.hasClass('active') == true) {
            $this.removeClass('active');
            $('#glyphicon').remove();
        }
            //remove active et les glyphicon de la sélection précédente avant de l'ajouter à la sélection actuelle
        else {
            $('.active').removeClass('active');
            $('#glyphicon').remove();
            $(this).toggleClass('active');
            $(this).append('<div id="glyphicon" class="glyphicon"><span id="span1" class="glyphicon glyphicon-trash"></span><span id="span2" class="glyphicon glyphicon-cog"></span></div>');

                //Appel AJAX
                $.get(
                    "http://localhost:51006/addNewQuery/_ListeURL?id=" + $this.id,
                    function (data) {
                        //data is result of _ListeURL action
                        //... //TODO
                        $('#UrlList').html(data)

                    });
        }
    }
};

//Clic sur le glyphicon engrenage : modifier le nom de la requête
$('#span2').on('click', function () {
    $this.empty();
    $this.text = "";
    document.getElementsByClassName('active')[0].innerHTML = '<textarea id="newQuery"></textarea>';
    var t = document.getElementById('newQuery');
    t.style.color = "black";
    t.text = $this.text;
    t.focus();
    //t.style.color = "black";

    var test = document.getElementsByClassName('active')[0];
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
            //test.replaceWith(a);
            $(test).replaceWith(a);
        }
    });
});

//Clic sur glyphicon poubelle : supprimmer la requête
$('#span1').on('click', function () {

    $('#QueryList .active').remove();
});



//clic bouton : ajouter une nouvelle requête
$('#addQuery').on('click', function () {

    var liste = $('#QueryList');
    var t = document.createElement('textarea');
    t.style.color = "black";
    liste.append(t);
    t.focus();

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
});

//URLS

//Highlight de l'URL selectionnee
$('.url').on('click', myClickURL);
function myClickURL() {
    var $this = $(this);
    if ($this.hasClass('url') == true) {
        if ($this.hasClass('active') == true) {
            $this.removeClass('active');
            $('#glyphicon').remove();
        }
            //remove active et les glyphicon de la sélection précédente avant de l'ajouter à la sélection actuelle
        else {
            $('.active').removeClass('active');
            $('#glyphicon').remove();
            $this.toggleClass('active');
            $this.append('<div id="glyphicon" class="glyphicon"><span id="span1" class="glyphicon glyphicon-trash"></span><span id="span2" class="glyphicon glyphicon-cog"></span></div>');
        }
    }

    //Clic sur le glyphicon rouage : modifier le nom de l'URL
    $('#span2').on('click', function () {
        $this.empty();

        var t = document.createElement('textarea');
        $this.text = "";
        $this.append(t);
        t.style.color = "black";
        t.text = $this.text;
        t.focus();

        $(t).keyup(function (e) {
            var code = e.which;
            if (code == 13) e.preventDefault();
            if (code == 13) {
                var liste = $('#UrlList');
                var value = $('textarea').val();
                value = value.substring(0, value.length - 1);
                var a = document.createElement('a');
                a.classList.add('list-group-item');
                a.classList.add('url');
                a.name = 'url';
                a.innerText = value;
                a.onclick = myClickURL;
                $($this).replaceWith(a);
            }
        });
    });

    //Clic sur glyphicon poubelle : supprimmer la URL
    $('#span1').on('click', function () {

        $('#UrlList .active').remove();
    });
}

//clic bouton : ajouter une nouvelle url
$('#addURL').on('click', function () {
    var liste = $('#UrlList');
    var t = document.createElement('textarea');
    t.style.color = "black";
    liste.append(t);
    t.focus();

    $(t).keyup(function (e) {
        var code = e.which;
        if (code == 13) e.preventDefault();
        if (code == 13) {
            var value = $('textarea').val();
            value = value.substring(0, value.length - 1);
            var a = document.createElement('a');
            a.classList.add('list-group-item');
            a.classList.add('url');
            a.name = 'url';
            a.innerText = value;
            a.onclick = myClickURL;
            $(t).replaceWith(a);
        }
    });
});

//Selectors

//Highlight de l'URL selectionnee
$('.selector').on('click', myClickSelector);
function myClickSelector() {
    var $this = $(this);
    if ($this.hasClass('selector') == true) {
        if ($this.hasClass('active') == true) {
            $this.removeClass('active');
            $('#glyphicon').remove();
        }
            //remove active et les glyphicon de la sélection précédente avant de l'ajouter à la sélection actuelle
        else {
            $('.active').removeClass('active');
            $('#glyphicon').remove();
            $this.toggleClass('active');
            $this.append('<div id="glyphicon" class="glyphicon"><span id="span1" class="glyphicon glyphicon-trash"></span><span id="span2" class="glyphicon glyphicon-cog"></span></div>');
        }
    }

    //Clic sur le glyphicon rouage : modifier le nom de l'URL
    $('#span2').on('click', function () {
        $this.empty();

        var t = document.createElement('textarea');
        $this.text = "";
        $this.append(t);
        t.style.color = "black";
        t.text = $this.text;
        t.focus();

        $(t).keyup(function (e) {
            var code = e.which;
            if (code == 13) e.preventDefault();
            if (code == 13) {
                var liste = $('#SelectorsList');
                var value = $('textarea').val();
                value = value.substring(0, value.length - 1);
                var a = document.createElement('a');
                a.classList.add('list-group-item');
                a.classList.add('selector');
                a.name = 'selector';
                a.innerText = value;
                a.onclick = myClickSelector;
                $($this).replaceWith(a);
            }
        });
    });

    //Clic sur glyphicon poubelle : supprimmer la URL
    $('#span1').on('click', function () {

        $('#SelectorsList .active').remove();
    });
}

//clic bouton : ajouter une nouvelle url
$('#addSelector').on('click', function () {
    var liste = $('#SelectorsList');
    var t = document.createElement('textarea');
    t.style.color = "black";
    liste.append(t);
    t.focus();

    $(t).keyup(function (e) {
        var code = e.which;
        if (code == 13) e.preventDefault();
        if (code == 13) {
            var value = $('textarea').val();
            value = value.substring(0, value.length - 1);
            var a = document.createElement('a');
            a.classList.add('list-group-item');
            a.classList.add('selector');
            a.name = 'selector';
            a.innerText = value;
            a.onclick = myClickSelector;
            $(t).replaceWith(a);
        }
    });
});
