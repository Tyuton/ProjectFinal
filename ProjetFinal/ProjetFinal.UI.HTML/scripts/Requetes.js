var resultsTitle = "Résultats de ("; //"Résultats de la requête selectionnée (";
////////////////////////////////////////////

$('#search').on('click', function () {
    //TODO filter queries list by Name
    
})


$('.list-group-item').on('click', function () {
    //selected item
    var $this = $(this);
    $('.active').removeClass('active');
    $this.toggleClass('active');

    //update result title & list
    updateResults($this[0]);

    //update description text
    updateDescription($this[0]);
})

function updateResults(selectedItem) {
    //TODO update results list
    var lresultsTitle = resultsTitle + selectedItem.text + ")";
    $('#resultsTitle').text(lresultsTitle);

    //update NbResults $('ul#menu li').length
    var lNbResults = "Nombre d'enregistrements (" + $('ul#resultsList li').length + ")";
    $("#NbResults").text(lNbResults);
}

function updateDescription(selectedItem) {
    var lqueryDescription = "Description (" + selectedItem.text + ")";
    $('#queryDescription').text(lqueryDescription);
}



