
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


function SaveDealData() {
  
       
        $.ajax({
            type: "POST",
            url: '/Application_Code/Views/frmDeals.aspx/SaveDealData',
            dataType: "json",
            async: false,
            data: '{hdnID: "' + jQuery('#hdnID').val() + '",Name: "' + $("#txtName").val() + '",NoOfPerson: "' + $("#txtNoOfPerson").val() + '",DaysOfWeek: "' + $("#ddlDaysOfWeek").select2("val") + '",Dishs: "' + $("#ddlDish").select2("val") + '",Description: "' + jQuery('#txtDescription').val() + '",start_time1: "' + jQuery('#start_time1').val() + '",start_time2: "' + jQuery('#start_time2').val() + '",start_time3: "' + jQuery('#start_time3').val() + '",start_time4: "' + jQuery('#start_time4').val() + '",end_time1: "' + jQuery('#end_time1').val() + '",end_time2: "' + jQuery('#end_time2').val() + '",end_time3: "' + jQuery('#end_time3').val() + '",end_time4: "' + jQuery('#end_time4').val() + '",Discount1: "' + jQuery('#txtDiscount1').val() + '",Discount2: "' + jQuery('#txtDiscount2').val() + '",Discount3: "' + jQuery('#txtDiscount3').val() + '",Discount4: "' + jQuery('#txtDiscount4').val() + '"}',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                ShowSuccessMessage();
                RefreshForm();

            },
            failure: function () {

            }
        });
    
}


///Refresh Form
function RefreshForm() {

    ///Reset Input Form
    document.getElementById("form1").reset();  
    $(".js-example-basic-multiple").val('').trigger("change");
    $(".timepickerControl").val('').trigger("change");
   
}

function UploadDocument(uploader) {
    ///Check uploader whether or not it contain some file or not
    if (uploader.value != '') {
       // $('#uploadValue').val(uploader.value);

        //getting files list user select to upload
        var uploadedfiles = $('#importImages').prop('files');;
        ///Declare FormData object to get Files data
        var fromdata = new FormData();
        for (var i = 0; i < uploadedfiles.length; i++) {
            ///getting Files data in FormData object 
            fromdata.append(uploadedfiles[i].name, uploadedfiles[i]);
        }
        var choice = {};
        choice.url = "/Application_Code/Handler/UploadFileHandler.ashx";  ///Call for render Documnet File
        choice.type = "POST";
        choice.data = fromdata;
        choice.contentType = false;
        choice.processData = false;


        //choice.complete = function () {
        //    ///Hide processing loader after completing Processing
        //    $('#form1').waitMe('hide');
        //};
        choice.success = function (result) {
            // alert('file Uploaded');
        };
        choice.error = function (err) {
            ///Show error message if file not upload successfully
            //alert(err);

        };
        $.ajax(choice);
    }
}