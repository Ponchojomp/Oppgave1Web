
$(function () {
    hentAlleBestillinger();
    hentAlleRuter();
    hentAlleHoldeplasser();
});

function hentAlleRuter() {
    $.get("transport/hentAlleRuter", function (ruter) {
        console.log(ruter);
        formaterRuter(ruter);
    })
    .fail(function () {
        console.log("feil");
    })

}

function formaterRuter(ruter) {

    console.log(ruter);
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
            "<td><button onClick='endreRute(" + rute.id + ")'>Endre</button></td>" + 
            "<td><button class='btnSlett' onClick='slettRute(" + rute.id + ")'>Slett</button></td>" + 
            "</tr>";
    }
    ut += "</table>";
    $("#rutene").html(ut);
}

function slettRute(id) {

}

function hentAlleHoldeplasser() {
    $.get("transport/hentAlleHoldeplasser", function (holdeplasser) {
        formaterHoldeplasser(holdeplasser);
    })
    .fail(function () {
        console.log("feil");
    })
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
            "<td><button onClick='endreHoldeplass(" + holdeplass.id + ")'>Endre</button></td>" +
            "<td><button class='btnSlett' onClick='slettHoldeplass(" + holdeplass.id + ")'>Slett</button></td>" + 
            "</tr>";
    }
    ut += "</table>";
    $("#holdeplassene").html(ut);
}

function slettHoldeplass(id) {

}

function hentAlleBestillinger() {
    $.get("transport/hentAlleBestillinger", function (bestillinger) {
        formaterBestillinger(bestillinger);
    })
    .fail(function () {
        console.log("feil");
    })
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
            "<td><button class='btnSlett' onClick='slettBestilling(" + bestilling.id + ")'>Slett</button></td>" + 
            "</tr>";
    }
    ut += "</table>";
    $("#bestillinger").html(ut);
}

function slettBestilling() {

}


