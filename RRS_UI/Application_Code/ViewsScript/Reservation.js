
function GetAllReservations() {

    $.ajax({
        type: "POST",
        url: '/Application_Code/Views/frmReservations.aspx/GetAllReservations',
        dataType: "json",
        async: false,
        data: '',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var result = response.d;

            if (result.List_HTML != '') {
                $('#RecordListDiv').html(result.List_HTML);

                jQuery('#RecordList').dataTable({
                    'paging': true,
                    'lengthChange': true,
                    'searching': true,
                    'ordering': true,
                    'info': true,
                    'autoWidth': false
                });
            }

        },
        failure: function () {

        }
    });
}


function Load_ReservationReport() {
 //   var StatusIDs = '' //$("#sel-02").val();//$("#sel-02").select2("val");

    //$.each($("#sel-02").val(), function (index, value) {
    //    if (StatusIDs == '') {
    //        StatusIDs = value;
    //    } else {
    //        StatusIDs = StatusIDs + ',' + value
    //    }
    //});

    var StatusIDs = $("#sel-02").val();
    var CountryID = $("#ddlCountry").select2("val");
    var DealID = $("#ddlDeals").select2("val");
    var startDate = $('#startdate').val();
    var endDate = $('#enddate').val();

    $.ajax({
        type: "POST",
        url: '/Application_Code/Views/frmReservations.aspx/Filter_ReservationReport',
        dataType: "json",
        async: false,
        data: '{StatusID: "' + StatusIDs + '",DealID: "' + DealID + '",CountryID: "' + CountryID + '",startDate:"' + startDate + '",endDate:"' + endDate  + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var result = response.d;

            if (result.List_HTML != '') {
                $('#RecordListDiv').html(result.List_HTML);

                jQuery('#RecordList').dataTable({
                    'paging': true,
                    'lengthChange': true,
                    'searching': true,
                    'ordering': true,
                    'info': true,
                    'autoWidth': false
                });
            }

        },
        failure: function () {

        }
    });

}

function Load_ReservationByDate() {
    var StatusIDs = '' //$("#sel-02").val();//$("#sel-02").select2("val");

    $.each($("#sel-02").val(), function (index, value) {
        if (StatusIDs == '') {
            StatusIDs = value;
        } else {
            StatusIDs = StatusIDs + ',' + value
        }
    });

    var CountryID = $("#ddlCountry").select2("val");
    var DealID = $("#ddlDeals").select2("val");

    var startDate = $('#startdate').val();
    var endDate = $('#enddate').val();


}

