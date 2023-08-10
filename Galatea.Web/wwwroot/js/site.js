function statistics() {   
    $('#statistics_btn').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        
        if ($('#statistics_box').hasClass('d-none')) {
            $.get('https://localhost:7088/api/statistics', function (data) {
                $('#total_publications').text(data.totalPublications + " Публикации");
                $('#total_users').text(data.totalUsers + " Потребители");

                $('#statistics_box').removeClass('d-none');

                $('#statistics_btn').text('Скрий статистика');
                $('#statistics_btn').removeClass('btn-primary');
                $('#statistics_btn').addClass('btn-danger');
            });
        } else {
            $('#statistics_box').addClass('d-none');

            $('#statistics_btn').text('Покажи статистика');
            $('#statistics_btn').removeClass('btn-danger');
            $('#statistics_btn').addClass('btn-primary');
        }
    });
}
