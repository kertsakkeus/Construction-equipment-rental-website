function checkout() {
    console.log(document.cookie);
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