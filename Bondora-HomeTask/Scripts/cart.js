function checkout() {
    if (document.cookie == "") {
        swal("Warning", "There is no product in your cart!", "error");
    }
    else {
        window.location = "Checkout";
    }
}
function deleteCookies() {
    document.cookie = "Id" + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
}
function deleteProduct(number) {

    var cookies = document.cookie;

    console.log(cookies);
    console.log(number);

    var items = cookies.split('|');

    items.splice(number, 1);

    if (items.length == 1) {
        document.cookie = "Id" + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
    }
    else {
        var newCookie = items.toString();
        newCookie = newCookie.replace(/,/g, '|');

        console.log(newCookie);

        document.cookie = newCookie;        
    }
    location.reload();
}