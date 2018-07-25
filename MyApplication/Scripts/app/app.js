var learnedQuotes=$.ajax({
        url: "/api/learneds",
        method: "GET",
        async: false
}).responseJSON;

var learningQuotes=$.ajax({
        url: "/api/learnings",
        method: "GET",
        async: false
    }).responseJSON;

function addToLearneds(quote) {

    var result = $.ajax({
        url: "/api/learneds/" + quote,
        method: "POST",
        async: false,
    }).done(function () {
        toastr.success("Quote successfully added to learned.");
    }).fail(function () {
        toastr.error("Quote is already on learning list");
    });

    if (result.statusText == "OK") {
        event.currentTarget.setAttribute("onchange", "deleteFromLearneds(" + quote + ")");
    }
    else {
        event.currentTarget.checked = false;
    }

}
function addToLearnings(quote) {

    var result = $.ajax({
        url: "/api/learnings/" + quote,
        method: "POST",
        async: false
    }).done(function () {
        toastr.success("Quote successfully added to learning.");
    }).fail(function () {
        toastr.error("Quote is already on learned list");
    });

    if (result.statusText == "OK") {
        event.currentTarget.setAttribute("onchange", "deleteFromLearnings(" + quote + ")");
    }
    else {
        event.currentTarget.checked = false;
    }
}

function deleteFromLearneds(quote) {
    $.ajax({
        url: "/api/learneds/" + quote,
        method: "DELETE"
    }).done(function () {
        toastr.warning("Quote successfully deleted form learned.");
    });
    event.currentTarget.setAttribute("onchange", "addToLearneds(" + quote + ")");
}
function deleteFromLearnings(quote) {
    $.ajax({
        url: "/api/learnings/" + quote,
        method: "DELETE"
    }).done(function () {
        toastr.warning("Quote successfully deleted from learning.");
    });
    event.currentTarget.setAttribute("onchange", "addToLearnings(" + quote + ")");
}