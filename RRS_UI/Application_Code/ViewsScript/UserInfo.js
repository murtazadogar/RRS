var captcha;
$(function () {
    $('input').iCheck({
        checkboxClass: 'icheckbox_square-blue',
        radioClass: 'iradio_square-blue',
        increaseArea: '20%' // optional
    });

         captcha = new $.Captcha({ //initialize captcha  
        selector: "#captcha",
        text: null,
        randomText: true,
        randomColours: false,
        width: 244,
        height: 163,
        colour1: '#99d5cf',
        colour2: '#ff9494',
        font: 'normal 40px "Comic Sans MS", cursive, sans-serif',
        onFailure: function () {
            //alert("In Correct ...");
            $('#isCaptchaValidate').val('-1');
            $("#captichaSuccessImg").attr("src", "../../Content/images/cross-icon.png");
            $("#captichaSuccessImg").css("visibility", "visible");
        },
        onSuccess: function () {
           // alert("Correct ...");
            $("#captichaSuccessImg").attr("src", "../../Content/images/tick-icon.jpg");
            $("#captichaSuccessImg").css("visibility", "visible");
            $('#isCaptchaValidate').val('1');

        }
    });

         captcha.generate();
});



//Used For Insert /Update Record
function SaveUserInfoData() {
    if (IsvalidUserDetails()) {
        IsValidUser();
    }
}

function SaveUpdateUserInfor() {
    $.ajax({
        type: "POST",
        url: '/Application_Code/Views/frmSignUp.aspx/SaveUserInfoData',
        dataType: "json",
        async: false,
        data: '{hdnID: "' + jQuery('#hdnUserID').val() + '",user_name: "' + $("#user_name").val() + '",email: "' + $("#email").val() + '",password: "' + $("#password").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            ShowSuccessMessage('Record successfully Updated....');
            ///reset form
            jQuery('#form1')[0].reset();
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
    $('#input_form').find('input[type=text],input[type=password],textarea,select').each(function () {
        if ($(this).validationEngine('validate', {
            autoHidePrompt: true,
                prettySelect: true,
                    maxErrorsPerField: 1,
                        showOneMessage: true
         
        })) {
            result = false;
        }
    });

if (result) {
        if ($('#isCaptchaValidate').val() != '1') {
            $('#captcha_txt').val('');
            result = false;

            $('#captcha_txt').validationEngine('validate', {
                autoHidePrompt: true,
                prettySelect: true,
                maxErrorsPerField: 1,
                showOneMessage: true

            });
        }
    }

    return result;
}

function IsValidUser() {

    $.ajax({
        type: "POST",
        url: '/Application_Code/Views/frmSignUp.aspx/IsValidUser',
        dataType: "json",
        async: false,
        data: '{email: "' + jQuery('#email').val() + '"}',
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
        if ($(this).validationEngine('validate', { validateNonVisibleFields: true, autoPositionUpdate: true })) {
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


function LogOutUser() {
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


