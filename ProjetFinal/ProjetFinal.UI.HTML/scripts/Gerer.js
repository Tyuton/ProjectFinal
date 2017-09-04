$('.list-group-item').click(function () {
    var $this = $(this);
    $('.active').removeClass('active');
    $this.toggleClass('active');  
});

$('.active').

