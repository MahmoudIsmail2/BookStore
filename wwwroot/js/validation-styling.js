// jQuery unobtrusive validation defaults

$.validator.setDefaults({
    errorClass: "",
    validClass: "",

    highlight: function (element, errorClass, validClass) {
        $(element).addClass("invalid-feedback").removeClass("is-valid");
        $(element.form).find("[data-valmsg-for=" + element.id + "]").addClass("invalid-feedback");
    },

    unhighlight: function (element, errorClass, validClass) {
        $(element).addClass("valid-feedback").removeClass("is-invalid");
        $(element.form).find("[data-valmsg-for=" + element.id + "]").removeClass("invalid-feedback");
    },
});