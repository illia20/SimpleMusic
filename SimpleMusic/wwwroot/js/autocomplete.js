$(document).ready(() => {
    $("[data-autocomplete-source]").each(function () {
        var target = $(this);
        target.autocomplete({
            source: target.attr("data-autocomplete-source"),
            minLength: 3,
            delay: 750,
            focus: function (event, ui) {
                event.preventDefault();
                $("[data-autocomplete-source]").val(ui.item.label);
            },
            select: function (event, ui) {
                event.preventDefault();
                $("[data-autocomplete-source]").val(ui.item.label);
                $("#autocompleteId").val(ui.item.value);
            }
        });
    });
});