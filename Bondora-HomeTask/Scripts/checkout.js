var checkedRadioButton;

function checkedRadio(isChecked) {
    checkedRadioButton = isChecked;
}

function makeInvoice() {
    var name = document.getElementById("checkout_name").value;
    var last_name = document.getElementById("checkout_last_name").value;
    var country = document.getElementById("checkout_country").value;
    var address = document.getElementById("checkout_address").value;
    var zipcode = document.getElementById("checkout_zipcode").value;
    var city = document.getElementById("checkout_city").value;
    var province = document.getElementById("checkout_province").value;
    var phone = document.getElementById("checkout_phone").value;
    var email = document.getElementById("checkout_email").value;
    var invoice;

    if (checkedRadioButton == true) {
        invoice = "true";
    }
    else {
        invoice = "false";
    }

    window.location = "Invoice?name=" + name + "&" + "last_name=" + last_name + "&" + "country=" + country + "&" + "address=" + address + "&" +
        "zipcode=" + zipcode + "&" + "city=" + city + "&" + "province=" + province + "&" + "phone=" + phone + "&" + "email=" + email + "&" + "invoice=" + invoice;
}