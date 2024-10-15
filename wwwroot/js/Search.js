
$(document).ready(function () {
    $('#searchButton').click(function () {
        var data = $('#searchString').val();
        console.log(data);
        $.get('/Home/SearchByAjax', { inputData: data }, function (result) {
            $('#SearchResult').html(result).fadeIn('slow');
        });
    })
});