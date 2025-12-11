$(document).ready(function () {
    //Command: toastr["info"]('Page Loaded!')


    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }



});


function IsPositiveNumber(val) {
   // debugger;
    if (((val - 0) > 0) && (!isNaN(val))) {
        return true;
    }
    return false;
}

var convArrToObj = function (array) {
    var thisEleObj = new Object();
    if (typeof array == "object") {
        for (var i in array) {
            var thisEle = convArrToObj(array[i]);
            thisEleObj[i] = thisEle;
        }
    } else {
        thisEleObj = array;
    }
    return thisEleObj;
}

var applySecurity = function () {

    $.ajax({
        url: "/SecurityModule/Account/GetActionPermission?url=" + window.location.pathname,
        cache: true,
        success: function (data) {
            console.log(window.location.pathname);
            //debugger;
            if (data !== "") {
                $(".pnlView").hide();
                $(".btnSave").hide();
                $(".btnEdit").hide();
                $(".txtTINView").hide();
                $(".txtRegView").hide();
                $(".btnLoad").hide();
                $(".btnScan").hide();
                $(".btnRemove").hide();
                $(".btnRotate").hide();
                $(".btnSearch").hide();
                $(".btnMakeVersion").hide();
                $(".btnDistribute").hide();
                $(".btnEmail").hide();
                //debugger;
                var strs = data.split("|");
                for (var i = 0; i < strs.length - 1; i++) {
                    if (strs[i] != null) {
                        $("." + strs[i]).show();
                    }
                }
            }
        }
    });

}


function GetCurrentDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }
    var today = dd + '/' + mm + '/' + yyyy;
    return today;

}

function CheckPositive(txtVendor) {
    //debugger;
    if (($("#" + txtVendor).val() == "") || (isNaN($("#" + txtVendor).val())))
    {
        return;
    }
    if (!IsPositiveNumber($("#" + txtVendor).val())) {
        if (isNaN($("#" + txtVendor).val())) {
            $("#" + txtVendor).val('');
            toastr.error("Number format is invalid");
        }
        else {
            toastr.error("Number should be grater than zero");
        }
        $("#" + txtVendor).val('');
        return;
    }
}

function FormatDigit(txtVendor,lmt) {
    if (!IsPositiveNumber($("#" + txtVendor).val())) {
        $("#" + txtVendor).val('');
    }
    else if (isNaN($("#" + txtVendor).val())) {
        $("#" + txtVendor).val('');
    }
    else {       
            var d = $("#" + txtVendor).val().split('.');
            if((d[0].length>(lmt-0)))
            {
                $("#" + txtVendor).val("");
                $("#btnSaveDoc").prop("disabled", true);
                return;
            }
            else
            {           
                $("#btnSaveDoc").prop("disabled", false);
                $("#" + txtVendor).val(($("#" + txtVendor).val() - 0).toFixed(2));
            }       
        }
        
}

function FormatDigitWithZero(txtVendor, lmt) {
    if (!IsPositiveNumber2($("#" + txtVendor).val())) {
        $("#" + txtVendor).val('');
    }
    else if (isNaN($("#" + txtVendor).val())) {
        $("#" + txtVendor).val('');
    }
    else {
            var d = $("#" + txtVendor).val().split('.');
            if ((d[0].length > (lmt - 0))) {
                $("#" + txtVendor).val("");
                $("#btnSaveDoc").prop("disabled", true);
                return;
            }
            else {
                $("#btnSaveDoc").prop("disabled", false);
                $("#" + txtVendor).val(($("#" + txtVendor).val() - 0).toFixed(2));
            }
          
    }
       
}

function IsPositiveNumber2(val) {
    
    if (((val - 0) >= 0) && (!isNaN(val))) {
        return true;
    }
    return false;
}

function CheckFutureDate() {

    var EnteredDate = $('#InvoiceDateID').val(); // For JQuery
    var date = EnteredDate.substring(0, 2);
    var month = EnteredDate.substring(3, 5);
    var year = EnteredDate.substring(6, 10);
    var myDate = new Date(year, month - 1, date);
    var today = new Date();
    if (myDate > today) {
        $('#InvoiceDateID').val('');
        $('.datepicker').hide();
        toastr.error("Invoice Date should not grater than system date.");
    }
}

function CurrencyFormatInTK(tk)
{
    var x = tk;
    x = x.toString();
    var lastThree = x.substring(x.length - 3);
    var otherNumbers = x.substring(0, x.length - 3);
    if (otherNumbers != '')
        lastThree = ',' + lastThree;
    var res = otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree;
    if(isNaN(res))
    {
        return 0;
    }
    return res;
}



