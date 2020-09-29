
$(function () {
    hentAlleKunder();
    console.log("Hei");
    hentAlleRuter();
    hentAlleHoldeplasser();
});

function hentAlleKunder() {
    $.get("kunde/hentAlle", function (kunder) {
        formaterKunder(kunder);
    });
}

function formaterKunder(kunder) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Navn</th><th>Adresse</th><th></th><th></th>" +
        "</tr>";
    for (let kunde of kunder) {
        ut += "<tr>" + 
            "<td>" + kunde.navn + "</td>" +
            "<td>" + kunde.adresse + "</td>" +
         "</tr>";
    }
    ut += "</table>";
    $("#kundene").html(ut);
}

function hentAlleRuter() {
    $.get("kunde/hentAlleRuter", function (ruter) {
        formaterRuter(ruter);
    });
}

function formaterRuter(ruter) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>ID</th><th>Rutenavn</th><th>RuteID</th><th>Startholdeplass</th>" +
        "<th>Sluttholdeplass</th></tr>";
    for (let rute of ruter) {
        ut += "<tr>" +
            "<td>" + rute.id + "</td>" +
            "<td>" + rute.Rutenavn + "</td>" +
            "<td>" + rute.Rutetid+ "</td>" +
            "<td>" + rute.Startholdeplass+ "</td>" +
            "<td>" + rute.Sluttholdeplass+ "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#rutene").html(ut);
}

function hentAlleHoldeplasser() {
    $.get("kunde/hentAlleHoldeplasser", function (holdeplasser) {
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