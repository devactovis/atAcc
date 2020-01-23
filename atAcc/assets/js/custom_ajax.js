
$("#inventorybtn").click(function (e) {
    var product_details = {};
    product_details.filtertype = $("#filtertype").val();
    product_details.datefrom = $("#datefrom").val();
    product_details.dateto = $("#dateto").val();
    product_details.productname = $("#productname").val();
    product_details.productgroup = $("#productgroup").val();
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "Sample_ajax",
        data: { "filter": product_details },
        success: function (data) {
            $("#inventorytbl").html(null);
            var i = 1;
            $.each(data, function (i, product) {
                i++;
                var rows = "<tr>" +
                    "<td>" + i + "</td>" +
                    "<td>" + product.product_code + "</td>" +
                    "<td>" + product.product_name + "</td>" +
                    "<td>" + product.product_group + "</td>" +
                    "<td>" + product.product_color + "</td>" +
                    "<td>" + product.base_unit + "</td>" +
                    "<td>" + product.hsn_code + "</td>" +
                    "<td>" + product.purchase_rate + "</td>" +
                    "<td>" + product.sales_rate + "</td>" +
                    "<td>" + product.sales_percent + "</td>" +
                    "<td>" + product.mrp + "</td>" +
                            "</tr>";
                $('#inventorytbl').append(rows);
            });
            //LoadData();
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
});

$("#rack_id").change(function (event) {
    var rack_id = $("#rack_id").val();
    var quantity = $("#quantity").val();
    $.ajax({
        url: "CheckQuantity",
        type: "POST",
        dataType: "json",
        data: { rack_id: rack_id, quantity: quantity },
        success: function (data) {
            $.each(data, function (i, product) {
                i++;
                var max_quantity = product.remaining;
                if (max_quantity > quantity) {

                }
                else {
                    alert("Maximum quantity remaining for this rack is " + max_quantity);
                    $('#quantity').val('');
                    $("#rack_id").val('');
                }
            });
            //LoadData();
        },
    });
});

function Emp_delete(value) {
    //$.ajax({
    //  url : "Delete_employee",
    //  type : "post",
    //   dataType : "json",
    //   data :{ id : value}
    //});
    //request.done( function ( data ) {
    //    location.reload(true);
    //});
    //request.fail( function ( jqXHR, textStatus) {
    //    console.log( 'Sorry: ' + textStatus );
    //});
}

function Confirmation(value) {
    var Val = confirm("Do you want to continue ?");
    if (Val == true) {
        Emp_delete(value);
    }
    else {
        document.write("NOT CONTINUED!");
        return false;
    }
}

function clear() {
    alert("hello");
    $('#myform')[0].reset();
}

function saveAccountGroup() {
    var groupname = $("#groupname").val();
    var under = $("#under").val();
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "AccountGroup",
        data: { groupname: groupname, under: under },
        success: function (data) {
            if (data == "success") {
                location.reload();
            }
            else {
                alert("failed");
            }
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
}

function SaveLedger() {
        
    }



function saveMoreDtls() {
    var valdata = $("#ledgerDtls").serialize();
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "SaveLedger",
        data: valdata,
        success: function (data) {
            if (data == "failed") {
                alert("failed");
            }
            else {

                //$('#accountledger a[href="#moredetails"]').tab('show')
                $('#AccountMoreDtls_ledger_id').val(data);
            }
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
    var valdata = $("#ledgerMoreDetails").serialize();
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "ledgerMoreDetails",
        data: valdata,
        success: function (data) {
            if (data == "success") {
                location.reload();
            }
            else {
                alert("failed");
            }
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
}

function checkPayment()
{
    var selected = $('#cashpartyacc').val();
    if(selected=="Credit")
    {
        $('#selectdate').show();
    }
}

function checkDate()
{
    var selected = $('#cashDueDate').val();
    if (selected == "custome") {
        $('.cashpartyacca').show();
        $('#cashDueDate').hide();
        $('#customeLabel').html("Enter Custome Date");
    }
}
