
$(function () {
    hentAlleBestillinger();
});

function hentAlleRuter() {
    $.get("transport/hentAlleRuter", function (ruter) {
        formaterRuter(ruter);
    });
}

function formaterRuter(ruter) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>ID</th><th>Rutenavn</th><th>Varighet</th><th>Startholdeplass</th>" +
        "<th>Sluttholdeplass</th></tr>";
    for (let rute of ruter) {
        ut += "<tr>" +
            "<td>" + rute.id + "</td>" +
            "<td>" + rute.rutenavn + "</td>" +
            "<td>" + rute.varighet + "</td>" +
            "<td>" + rute.startholdeplass + "</td>" +
            "<td>" + rute.sluttholdeplass + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#rutene").html(ut);
}

function hentAlleHoldeplasser() {
    $.get("transport/hentAlleHoldeplasser", function (holdeplasser) {
        formaterHoldeplasser(holdeplasser);
    });
}

function formaterHoldeplasser(holdeplasser) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>ID</th><th>Holdeplass</th><th></th><th></th>" +
        "</tr>";
    for (let holdeplass of holdeplasser) {
        ut += "<tr>" +
            "<td>" + holdeplass.id + "</td>" +
            "<td>" + holdeplass.navn + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#holdeplassene").html(ut);
}

function hentAlleBestillinger() {
    $.get("transport/hentAlleBestillinger", function (bestillinger) {
        formaterBestillinger(bestillinger);
    });
}

function formaterBestillinger(bestillinger) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>ID</th><th>Navn</th><th>Telefonnummer</th><th>Avgang</th>" +
        "</tr>";
    for (let bestilling of bestillinger) {
        ut += "<tr>" +
            "<td>" + bestilling.id + "</td>" +
            "<td>" + bestilling.navn + "</td>" +
            "<td>" + bestilling.telefonnummer + "</td>" +
            "<td>" + bestilling.avgang + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#bestillinger").html(ut);
}
function hentAlleAvganger() {
    $.get("transport/hentAlleAvganger", function (Avganger) {
        formaterAvganger(Avganger);
    });
}

function formaterAvganger(Avganger) {

    console.log(Avganger);
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>ID</th><th>Tid</th><th>Rute</th><th>Avgang</th>" +
        "</tr>";

    for (let avgang of Avganger) {
        ut += "<tr>" +
            "<td>" + avgang.id + "</td>" +
            "<td>" + avgang.tid + "</td>" +
            "<td>" + avgang.rute + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#avganger").html(ut);
}

function hentAlleKunder() {
    $.get("kudne/hentAlle", function (Kunder) {
        formaterKunder(Kunder);
    });
}

function formaterKunder(Kunder) {

    console.log(Kunder);
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>ID</th><th>navn</th><th>telefonnummer</th><th>postnr</th><th>poststed</th>" +
        "</tr>";

    for (let kunde of Kunder) {
        ut += "<tr>" +
            "<td>" + kunde.id + "</td>" +
            "<td>" + kunde.navn + "</td>" +
            "<td>" + kunde.telefonnummer + "</td>" +
            "<td>" + kunde.postnr+ "</td>" +
            "<td>" + kunde.poststed + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#kunder").html(ut);
}

