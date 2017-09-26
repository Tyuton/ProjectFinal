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
            $('#QueryList > a').removeClass('active');
            $('#glyphicon').remove();
            $(this).toggleClass('active');
            $(this).append('<div id="glyphicon" class="glyphicon"><span id="span1" class="glyphicon glyphicon-trash"></span><span id="span2" class="glyphicon glyphicon-cog"></span></div>');
            // alert($this[0].id);
            //Appel AJAX
            $.get(
                "http://localhost:51006/addNewQuery/_ListeURL?id=" + $this[0].id,
                function (data) {
                    //data is result of _ListeURL action
                    //... //TODO
                    $('#UrlList').html(data)
                    $('.url').on('click', myClickURL);


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
            a.classList.add('newquery');
            a.id = $.guid;
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
            $('#UrlList > a').removeClass('active');
            $('#glyphicon').remove();
            $this.toggleClass('active');
            $this.append('<div id="glyphicon" class="glyphicon"><span id="span1" class="glyphicon glyphicon-trash"></span><span id="span2" class="glyphicon glyphicon-cog"></span></div>');
            //alert($this[0].id);
            //Appel AJAX
            $.get(
                "http://localhost:51006/addNewQuery/_ListeSelector?id=" + $this[0].id,
                function (data) {
                    //data is result of _ListeURL action
                    //... //TODO
                    $('#SelectorsList').html(data)
                    $('.selector').on('click', myClickSelector);

                });


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
            a.classList.add('newurl');
            a.name = 'url';
            a.id = $.guid;
            a.innerText = value;
            a.onclick = myClickURL;
            $(t).replaceWith(a);
        }
    });
});

//Selectors

//Highlight du Selector selectionne
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
            $('#SelectorsList > a').removeClass('active');
            $('#glyphicon').remove();
            $this.toggleClass('active');
            $this.append('<div id="glyphicon" class="glyphicon"><span id="span1" class="glyphicon glyphicon-trash"></span><span id="span2" class="glyphicon glyphicon-cog"></span></div>');

        }
    }

    //Clic sur le glyphicon rouage : modifier le nom du selector
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

    //Clic sur glyphicon poubelle : supprimmer le selecteur
    $('#span1').on('click', function () {

        $('#SelectorsList .active').remove();
    });
}

//clic bouton : ajouter un nouveau selecteur
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
            a.classList.add('newselector');
            a.name = 'selector';
            a.id = $.guid;
            a.innerText = value;
            a.onclick = myClickSelector;
            $(t).replaceWith(a);
        }
    });
});

$('#Result').on('click', function () {
    var selector = $('.selector.active');
    if (selector.length > 0) {
        alert('étrange');
        //Appel AJAX
        $.get(
            "http://localhost:51006/addNewQuery/_DisplayData?id=" + selector[0].id,
            function (data) {
                //data is result of _ListeURL action
                //... //TODO
                $('#Data').html(data)

            });

    }
    else {
        alert("Aucun sélecteur n'est sélectionné");
    }
});

$('#Execute').on('click', function () {

    var query = $('.query.active');
    if (query.length > 0) {
        $.get(
          "http://localhost:51006/addNewQuery/ExectuteQuery?id=" + query[0].id,
          function (data) {
              //data is result of _ListeURL action
              //... //TODO
              //$('#Data').html(data)
              alert(data);
          }).fail(function (a, b, c) {
              alert('Error');
          });

    }
    else {
        alert("Aucune requête n'est sélectionnée");
    }

});

$('#Save').on('click', function () {

    var qjson = {};
    var ujson = {};
    var sjson = {};



    var newQuery = $('.newquery');
    if (newQuery != null)
    newQuery.each(
        $('.newurl')


        );


    var newURL = $('.newurl');
    var newSelector = $('.newselector');
    if (newQuery.length > 0) {
        $.get(
            "http://localhost:51006/addNewQuery/SaveNewQuery?Qid="
            + newQuery[0].id + "&QName=" + newQuery[0].text
            + "Uid=" + newURL[0].id + "&UName=" + newURL[0].text
            + "Sid=" + newSelector[0].id + "&SName=" + newSelector[0].text,
            function NewSelectorJS(id, value) {
                this.id = newSelector.id,
                this.value = newSelector.text
            }
            //function NewPageJS (id, URL, ListeSelectors) {
            //    this.id = newURL.id,
            //    this.URL = newURL.text
            //    this.ListeSelectors = 
            //}
            )
    }
    alert("En cours d'implémentation");




});