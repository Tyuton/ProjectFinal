// Amin Cherbal
// TODO Récupérer la liste des urls en Ajax

$('.query').on('click', function (sender) { ajaxGetURLs($(this)[0]); });

function ajaxGetURLs(selectedItem) { //selectedItem is a query
    var q = selectedItem.text;
    $.ajax({
        url: "testfiles/" + q + ".json", // simulation du serveur par des fichiers json
        success: function (result) {
            BuildURLsList(result);
        },
        error: function (result) {
            myClickQuery();
        }
    });
}

function BuildURLsList(listURLs) {   //  listURLs est un array d'urls
    //vider la liste des urls
    $('#UrlList > a').remove();

    //update urls   
    $.each(listURLs, function (i, val) {
        $("<a/>", {
            "class": "list-group-item url",
            text: val,
            click: ajaxGetSelectors
        }).appendTo("#UrlList");
    });
    //select first
    
    //if ($('#UrlList > a').length) {
    //    $('#UrlList > a')[0].toggleClass('active');
    //}

}


// TODO Récupérer la liste des selecteurs en Ajax
//$('.url').on('click', function (sender) { ajaxGetSelectors($(this)[0]); });

function ajaxGetSelectors() { //selectedItem is an selector    
    var selectedItem = $(this)[0]
    var url = "testfiles/" + selectedItem.text + ".json";
    $.ajax({
        url:  url, // simulation du serveur par des fichiers 
        success: function (result) {
            BuildSelectorsList(result);
        },
        error: function (result) {
            alert(result.responseText);
            BuildSelectorsList(result);
            myClickQuery();
        },

    });
}

function BuildSelectorsList(listSelectors) {   //  listURLs est un array d'urls
    //vider la liste des selecteurs
    $('#SelectorsList > a').remove();

    //update selecteurs   
    $.each(listSelectors, function (i, val) {
        $("<a/>", {
            "class": "list-group-item selector",
            text: val,
            click: myClickQuery
        }).appendTo("#SelectorsList");
    });
    //select first

}

function myClick2() {
    alert(2);
}

//A chaque click sur une Requete, il faut détruire puis reconstruire la liste des Pages associées à cette requêtes.
//Pareil pour la liste des sélecteurs

//function getAllPages() {
//    $.ajax({
//        type: "GET",
//        url

//    });
//}