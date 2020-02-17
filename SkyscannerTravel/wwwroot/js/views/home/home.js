$("#btnSearch").click((e) => {
    let selectedOriginalPlace = $("#selectOriginalPlace").val();
    let selectedDestinationPlace = $("#selectDestinationCity").val();

    getResponse(`/BrowseQuotes?orininalPlace=${selectedOriginalPlace}&destinationPlace=${selectedDestinationPlace}`, "html").done((response) => {
        $(".list-of-quotes-container").html(response);
    }).fail((jqXHR, textStatus) => {
        console.log(textStatus);
    });
});

$('#selectDestinationCountry').on('select2:select', function (e) {
    let selectedCountry = $(this).val();
    $("#btnSearch").prop("disabled", true);

    getResponse(`/Cities/${selectedCountry}`, "json").done((response) => {
        SetNewOptionsFor('#selectDestinationCity', response);
        let selectedCity = $("#selectDestinationCity").val();
        if (selectedCity) {
            $("#btnSearch").prop("disabled", false);
        }
    }).fail((jqXHR, textStatus) => {
        console.log(textStatus);
    });
});

$('#selectDestinationCity').on('select2:select', function (e) {
    let selectedCity = $(this).val();
    if (selectedCity) {
        $("#btnSearch").prop("disabled", false);
        return;
    }
});

function RemoveOptionsFor(select) {
    $(select).html(`<option value="">Select</option>`).trigger('change');
}

function SetNewOptionsFor(select, options) {
    let newOptions = []
    Array.from(options).forEach((value) => {
        newOptions.push(new Option(value.text, value.value, false, false));
    });

    $(select).html(newOptions).trigger('change');
}

$("#selectDestinationCity").select2();
$("#selectDestinationCountry").select2();

$("#selectOriginalPlace").select2({
    minimumResultsForSearch: Infinity,
    placeholder: "Select",
});