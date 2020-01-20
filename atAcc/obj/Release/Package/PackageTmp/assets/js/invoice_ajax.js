$("#purchase_save").click(function (e) {
    var invoice_basic = {};

    invoice_basic.tot_qty = $("#net_total_quantity").text();
    invoice_basic.tot_gross = $("#net_total").text();
    invoice_basic.tot_net = $("#grand_total").text();
    invoice_basic.voucher = $("#voucher").val(); 
    invoice_basic.voucherArabic = $("#voucherArabic").val();
    invoice_basic.depot_loc = $("#depotlocation").val();
    invoice_basic.cash_party_acc = $("#cashpartyacc").val();
    invoice_basic.purchase_acc = $("#purchaseacc").val();
    invoice_basic.type = $("#type").val();
    invoice_basic.remarks = $("#remarks").val();
    invoice_basic.date = $("#date").val();
    invoice_basic.dateArabic = $("#dateArabic").val();
    invoice_basic.acc_id = $("#accid").val();
    invoice_basic.party_vno = $("#partyvno").val();
    var data = $("#accid").val();
    var invoice_id = $("#voucher").val();
    if (data == 'custom')
    {
        invoice_basic.party_name = $("#partyname").val();
        invoice_basic.party_namearabic = $("#partynamearabic").val();
    }
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "getInvoice",
        data: { "obj": invoice_basic },
        success: function (data) {
            if (data != "failed") {
                var rowCount = $('#productstable tr').length;
                rowCount = rowCount - 1;
                for (var i = 1; i <= rowCount; i++) {
                    var invoice_data = {};
                    invoice_data.id = data;
                    invoice_data.code = $("#product_code" + i).val();
                    invoice_data.product_name = $("#product_name" + i).val();
                    invoice_data.quantity = $("#quantity" + i).val();
                    invoice_data.rateamount = $("#amount" + i).val();
                    invoice_data.spl_per = $("#spl_discpercent" + i).val();
                    invoice_data.spl_disc = $("#spl_disc" + i).val();
                    invoice_data.addl_disc = $("#add_disc" + i).val();
                    invoice_data.total_tax = $("#total_tax" + i).val();
                    invoice_data.net_amt = $("#net_amt" + i).val();
                    invoice_data.gst_per = $("#gst_percent" + i).val();
                    invoice_data.discount = $("#discount" + i).val();
                    invoice_data.gst = $("#gst" + i).val();
                    invoice_data.mrp = $("#mrp" + i).val();
                    invoice_data.imeno = $("#imeno" + i).val();
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        url: "getInvoiceDetails",
                        data: { "obj": invoice_data },
                        success: function (data) {
                            location.href = "Print?id=" + invoice_id;
                        },
                        error: function (xhr, status, error) {
                            var err = eval("(" + xhr.responseText + ")");
                            alert(err.Message);
                        }
                    });
                }
            }

            else {
                alert("Something went wrong");
                location.reload();
            }
        },
        error: function (xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
        }
    });
});
