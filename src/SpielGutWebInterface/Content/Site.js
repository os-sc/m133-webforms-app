function ExtendRental(rid) {
    console.log("Extending Rental: " + rid);
    $.ajax({
        type: "POST",
        url: "/api/ExtendRental?rid=" + rid
    }).error(function() {
        showToast("An error occured and the rental could not be extended.");
    }).success(function() {
        window.location.reload(true);
    });
}

function showToast(msg) {
    var notification = document.querySelector(".mdl-js-snackbar");
    notification.MaterialSnackbar.showSnackbar(
        {
            message: msg
        }
    );
}