///Used for Show Success message after update database
function ShowSuccessMessage(MessageText) {
    if (typeof MessageText == 'undefined') {
        //adding a 'x' button if the user wants to close manually
        $("#result").html('<div class="alert alert-success"><button type="button" class="close">×</button> Record Successfully Updated.. </div>');
    }
    else {
        //adding a 'x' button if the user wants to close manually
        $("#result").html('<div class="alert alert-success"><button type="button" class="close">×</button>' + MessageText + '</div>');

    }

    //timing the alert box to close after 5 seconds
    window.setTimeout(function () {
        $(".alert").fadeTo(500, 0).slideUp(500, function () {
            $(this).remove();
        });
    }, 5000);

    //Adding a click event to the 'x' button to close immediately
    $('.alert .close').on("click", function (e) {
        $(this).parent().fadeTo(500, 0).slideUp(500);
    });
}


function ShowFailureMessage() {
    //adding a 'x' button if the user wants to close manually
    $("#result").html('<div class="alert alert-danger"><button type="button" class="close">×</button> Record Not Successfully Updated..</div>');

    //timing the alert box to close after 5 seconds
    window.setTimeout(function () {
        $(".alert").fadeTo(500, 0).slideUp(500, function () {
            $(this).remove();
        });
    }, 5000);

    //Adding a click event to the 'x' button to close immediately
    $('.alert .close').on("click", function (e) {
        $(this).parent().fadeTo(500, 0).slideUp(500);
    });
}


/////Use For Reset Input Form
function ResetFields() {
    ///reset form
    jQuery('#form1')[0].reset();
}



///Load Status Dropdown
function LoadStatusDDL(ControlID) {

    $.ajax({
        type: "POST",
        url: '/Application_Code/CommonServices/CommonWebService.aspx/LoadStatusDDL',
        dataType: "json",
        async: false,
        data: '',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var StatusObject = response.d;
            var result = '<option value=""></option>';
            //creating Options List and appending it
            for (var i = 0; i < StatusObject.length; i++) {
                result += '<option name="0" value="' + StatusObject[i].Id + '">' + StatusObject[i].Name + '</option>';
            }

            //If a page has more than one Dropdowns than sending all ids with comma separeted i.e. #Employee1,#Employee2
            if (ControlID.split(',').length > 1) {
                for (var i = 0; i < ControlID.split(',').length; i++) {
                    jQuery(ControlID.split(',')[i]).html('');
                    jQuery(ControlID.split(',')[i]).append(result);
                }
            } else {
                jQuery(ControlID).html('');
                $(ControlID).html(result);
            }

            //$(ControlID).select2();

            //var Status_json = new Array();
            //Status_json[0] = 1;
            //$(ControlID).select2('val', Status_json);

        },
        failure: function () {

        }
    });
}

function LoadRestaurantDealDDL(ControlID) {

    $.ajax({
        type: "POST",
        url: '/Application_Code/CommonServices/CommonWebService.aspx/LoadRestaurantDealDDL',
        dataType: "json",
        async: false,
        data: '',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var DealObject = response.d;
            var result = '<option value=""></option>';
            //creating Options List and appending it
            for (var i = 0; i < DealObject.length; i++) {
                result += '<option name="0" value="' + DealObject[i].Id + '">' + DealObject[i].Name + '</option>';
            }

            //If a page has more than one Dropdowns than sending all ids with comma separeted i.e. #Employee1,#Employee2
            if (ControlID.split(',').length > 1) {
                for (var i = 0; i < ControlID.split(',').length; i++) {
                    jQuery(ControlID.split(',')[i]).html('');
                    jQuery(ControlID.split(',')[i]).append(result);
                }
            } else {
                jQuery(ControlID).html('');
                $(ControlID).html(result);
            }

            //$(ControlID).select2();

            //var Status_json = new Array();
            //Status_json[0] = 1;
            //$(ControlID).select2('val', Status_json);

        },
        failure: function () {

        }
    });
}

function LoadCustomerDDL(ControlID) {

    $.ajax({
        type: "POST",
        url: '/Application_Code/CommonServices/CommonWebService.aspx/LoadCustomerDDL',
        dataType: "json",
        async: false,
        data: '',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var DealObject = response.d;
            var result = '<option value=""></option>';
            //creating Options List and appending it
            for (var i = 0; i < DealObject.length; i++) {
                result += '<option name="0" value="' + DealObject[i].Id + '">' + DealObject[i].Name + '</option>';
            }

            //If a page has more than one Dropdowns than sending all ids with comma separeted i.e. #Employee1,#Employee2
            if (ControlID.split(',').length > 1) {
                for (var i = 0; i < ControlID.split(',').length; i++) {
                    jQuery(ControlID.split(',')[i]).html('');
                    jQuery(ControlID.split(',')[i]).append(result);
                }
            } else {
                jQuery(ControlID).html('');
                $(ControlID).html(result);
            }

         

        },
        failure: function () {

        }
    });
}

function GetTopReservations() {

    $.ajax({
        type: "POST",
        url: '/Application_Code/Views/frmReservations.aspx/GetTopReservations',
        dataType: "json",
        async: false,
        data: '',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var result = response.d;

            if (result.List_HTML != '') {
                $('#ul_TopReservation').html(result.TopReservationList_HTML);
            }
        },
        failure: function () {

        }
    });
}

function LoadDishesDDL(ControlID) {

    $.ajax({
        type: "POST",
        url: '/Application_Code/CommonServices/CommonWebService.aspx/LoadDishesDDL',
        dataType: "json",
        async: false,
        data: '',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var DishObject = response.d;
            var result = '<option value=""></option>';
            //creating Options List and appending it
            for (var i = 0; i < DishObject.length; i++) {
                result += '<option name="0" value="' + DishObject[i].Id + '">' + DishObject[i].Name + '</option>';
            }

            //If a page has more than one Dropdowns than sending all ids with comma separeted i.e. #Employee1,#Employee2
            if (ControlID.split(',').length > 1) {
                for (var i = 0; i < ControlID.split(',').length; i++) {
                    jQuery(ControlID.split(',')[i]).html('');
                    jQuery(ControlID.split(',')[i]).append(result);
                }
            } else {
                jQuery(ControlID).html('');
                $(ControlID).html(result);
            }

            //$(ControlID).select2();

            //var Status_json = new Array();
            //Status_json[0] = 1;
            //$(ControlID).select2('val', Status_json);

        },
        failure: function () {

        }
    });
}

///Used for highlight currect selected menu 
function SetActiveMenuItem(id, parent) {
    $('#mainMenu li.active').removeClass('active');
    $(id).addClass(' active');

    if (parent != '')
        $(parent).addClass(' active');
}