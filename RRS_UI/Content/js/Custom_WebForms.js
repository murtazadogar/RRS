/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////Generic Function which are used in different places for different purpose//////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

///Used for attatch bootstrap validation
$(function () {
    ///Attatch validation with requird controls
    $("#form1").validationEngine('attach', {
        ///set Validationmessage POsition
        promptPosition: "topRight: -20",
        ///Set Max count for validation messages at a time
        maxErrorsPerField: 1,
        ///Enable Validation on disable fields
        validateNonVisibleFields: true,
        autoPositionUpdate: true
    });
});


/////Use Check Content in Text Editer
function CheckContent(field, rules, i, options) {
    ///Get Contents from Text Editer
    var text = tinyMCE.activeEditor.getContent({
        format: 'text'
    });
    ///Remove extra spaces from text
    text = $.trim(text);
    ///Check Lenght of text
    if (text.length == 0) {
        $("#Area_Text").val('');
    }
    else {
        ///Show text in control
        $("#Area_Text").val(text);
    }
}

/////Use Check Charecters only
function CheckCharecters(field, rules, i, options) {
    ///Assign a Reguler experassion in a variable
    var regex = /^\D+$/;
    ///Match Reguler expression with user input data
    if (!regex.test(field.val())) {
        ///Show Message if Invalid Information
        return "Please Enter Charecters Only."
    }
}

/////Use Check Numbers only
function CheckNumbers(field, rules, i, options) {
    ///Assign Reguler experassion in a variable
    var regex = /^[0-9]+$/;
    //Match Reguler expression with user input data
    if (!regex.test(field.val())) {
        ///Show Message if Invalid Information
        return "Please Enter Numbers Only."
    }
}

///Use for Check URL 
function checkUrl(field, rules, i, options) {
    //regular expression for URL
    var regex = /([\d\w]+?:\/\/)?([\w\d\.\-]+)(\.\w+)(:\d{1,5})?(\/\S*)?/;
    //Match Reguler expression with user input data
    if (!regex.test(field.val())) {
        ///Show Message if Invalid Information
        return "Please Enter Valid URL."
    }
}


////Use for Check Float Type Data
function CheckFloatDataType(field, rules, i, options) {
    ///Assign a Reguler experassion in a variable
    var regex = /([\d\w]+?:\/\/)?([\w\d\.\-]+)(\.\w+)(:\d{1,5})?(\/\S*)?/;
    //Match Reguler expression with user input data
    if (!regex.test(field.val())) {
        ///Show Message if Invalid Information
        return "Please Enter Numbers Only."
    }
}

//////Use for Check Form Validation on click
function IsvalidForm() {
    ///Apply Bootstrap validation with Requird Controls in Input Form
    var result = jQuery('#InputForm').validationEngine('validate', { promptPosition: 'topRight: -20', validateNonVisibleFields: true, autoPositionUpdate: true });
    ///If all requird Information is Given
    if (result) {
        ///If all requird Information is Given then return true
        return true;
    }
    ///If all requird Information is Given then return false
    return false;
}

/////Use For Reset Input Form
function ResetFields() {
    ///reset form
    jQuery('#form1')[0].reset();
}

