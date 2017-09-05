//Used For Insert /Update Record
function SaveUserInfoData() {
    if (IsvalidUserDetails()) {
        IsValidUserName();
    }
}

function SaveUpdateUserInfor() {
    $.ajax({
        type: "POST",
        url: '/Application_Code/Views/frmClient.aspx/SaveUserInfoData',
        dataType: "json",
        async: false,
        data: '{hdnID: "' + jQuery('#hdnUserID').val() + '",user_name: "' + $("#user_name").val() + '",email: "' + $("#email").val() + '",website: "' + $("#website").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            //ShowSuccessMessage();
            $('#UserProfileModal').modal('hide');

            jQuery('#header_user_name').html($("#user_name").val());
            jQuery('#header_detail_user_name').html($("#user_name").val());
        },
        failure: function () {

        }
    });
}

function ChangePassword() {

    if (IsvalidUserCredentials()) {
        $.ajax({
            type: "POST",
            url: '/Application_Code/Views/frmClient.aspx/ChangePassword',
            dataType: "json",
            async: false,
            data: '{hdnID: "' + jQuery('#hdnUserID').val() + '",confirm_password: "' + $("#confirm_password").val() + '"}',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
             //   ShowSuccessMessage();
                $('#UserProfileModal').modal('hide');
            },
            failure: function () {

            }
        });
    }
}


function GetLoginUserDetails() {
    jQuery.ajax({
        type: "POST",
        url: '/Application_Code/Views/frmClient.aspx/GetLoginUserDetails',
        dataType: "json",
        async: false,
        data: '',
        // json string to send as data to web method of web server
        contentType: "application/json; charset=utf-8",
        success: function (response) {        //On Succesful Completion of ajax request

            var result = response.d;
            if (result != '') {
                //  alert("sccuss");
                //getting Details from ajax response
                var UserInfo = response.d;


                ///Set Focus on First Field
                $('#client_name').focus();
                ///Hide Validation messages
                jQuery('#form1').validationEngine('hide');
                ////Set Detail Information
                jQuery('#hdnUserID').val(UserInfo.Id);
                jQuery('#hdnPassword').val(UserInfo.Password);
                
                jQuery('#user_name').val(UserInfo.Username);
                jQuery('#email').val(UserInfo.Email);
                jQuery('#website').val(UserInfo.Website);

                jQuery('#header_user_name').html(UserInfo.Username);
                jQuery('#header_detail_user_name').html(UserInfo.Username);
            
                                   
            }
        },
        failure: function () {
            alert('fail');
        }
    });
    return false;
}

///Validate user details
function IsvalidUserDetails() {
    var result = true;
    //validating Details
    $('#user_details').find('input[type=text],textarea,select').each(function () {
        if ($(this).validationEngine('validate', { promptPosition: 'topRight: -20', validateNonVisibleFields: true, autoPositionUpdate: true })) {
            result = false;
        }
    });
    return result;
}

function IsValidUserName() {

    $.ajax({
        type: "POST",
        url: '/Application_Code/Views/frmClient.aspx/IsValidUserName',
        dataType: "json",
        async: false,
        data: '{user_name: "' + jQuery('#user_name').val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            //ShowSuccessMessage();
            if (response.d == true) {
                $('#user_nameDiv').append(' <div class="selectValidityError parentFormform1 formError" style="opacity: 0.87; position: absolute; top: -5%; left: 57%; display: block;"><div class="formErrorContent">* user name already exist. <br></div><div class="formErrorArrow"><div class="line10"><!-- --></div><div class="line9"><!-- --></div><div class="line8"><!-- --></div><div class="line7"><!-- --></div><div class="line6"><!-- --></div><div class="line5"><!-- --></div><div class="line4"><!-- --></div><div class="line3"><!-- --></div><div class="line2"><!-- --></div><div class="line1"><!-- --></div></div></div>');
                return false;
            }
            else {
                jQuery('.selectValidityError').remove();
                SaveUpdateUserInfor();
            }
        },
        failure: function () {

        }
    });
}


///Validate user details
function IsvalidUserCredentials() {
    var result = true;

    //validating Details
    $('#user_credentials').find('input[type=password]').each(function () {
        if ($(this).validationEngine('validate', {  validateNonVisibleFields: true, autoPositionUpdate: true })) {
            result = false;
        }
    });

    if (result) {
        if (jQuery('#hdnPassword').val() != jQuery('#old_password').val()) {
            ///Show Message if not valid
            $('#oldPasswordDiv').append(' <div class="selectformError parentFormform1 formError" style="opacity: 0.87; position: absolute; top: 42px; left: 211px; margin-top: -50px; display: block;"><div class="formErrorContent">* invalid user password<br></div><div class="formErrorArrow"><div class="line10"><!-- --></div><div class="line9"><!-- --></div><div class="line8"><!-- --></div><div class="line7"><!-- --></div><div class="line6"><!-- --></div><div class="line5"><!-- --></div><div class="line4"><!-- --></div><div class="line3"><!-- --></div><div class="line2"><!-- --></div><div class="line1"><!-- --></div></div></div>');
            result = false;
        } else {
            ///Hide Document Name Validation messages if Document uploaded is given
            jQuery('.selectformError').remove();
        }       
    }

   
    return result;
}


function LogOutUser()
{
    $.ajax({
        type: "POST",
        url: '/Application_Code/Views/frmClient.aspx/LogOutUser',
        dataType: "json",
        async: false,
        data: '',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            //if logout Successful redirect to Login Page
            result = response.d;
            if (result) {
                window.location = "/Application_Code/Views/frmLogin.aspx";
            }
        },
        failure: function () {

        }
    });
}


