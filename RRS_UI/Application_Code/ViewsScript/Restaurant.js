
function GetRestaurantDeals() {

    $.ajax({
        type: "POST",
        url: '/Application_Code/Views/frmDeals.aspx/GetRestaurantDeals',
        dataType: "json",
        async: false,
        data: '',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var result = response.d;

            if (result.DealsList_HTML != '') {
                $('#RecordListDiv').html(result.DealsList_HTML);


                /*Mutli slider*/
                $('.dealSlider').slick({
                    slidesToShow: 8,
                    slidesToScroll: 1,
                    autoplay: true,
                    variableWidth: true,
                    autoplaySpeed: 2000
                });


                //jQuery('#RecordList').dataTable({
                //    'paging': true,
                //    'lengthChange': true,
                //    'searching': true,
                //    'ordering': true,
                //    'info': true,
                //    'autoWidth': false
                //});
            }

        },
        failure: function () {

        }
    });
}