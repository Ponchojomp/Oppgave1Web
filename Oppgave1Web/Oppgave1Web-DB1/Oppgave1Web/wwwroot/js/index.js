var byer = [];
var autocompleteOptions = document.getElementById("autocompleteOptions");
var autocomplete = document.getElementById("autocomplete");
var byInput = document.getElementById("byInput");
var input = "";
var avreiseSet = document.getElementById("avreiseSet");
var ankomstSet = document.getElementById("ankomstSet");
var datoTidSet = document.getElementById("datoTidSet");

hentReiseRute();
hentAlleHoldeplasser();

selectDateAndTime();


function generateAutocompleteItems() {
    setTimeout(function () {
        var options = 0;
        autocompleteOptions.innerHTML = "";
        for (var i = 0; i < byer.length; i++) {
            if (byer[i][0].toLowerCase().startsWith(byInput.value.toLowerCase())) {
                autocompleteOptions.innerHTML = autocompleteOptions.innerHTML + '<div class="autocompleteItem" value="' + byer[i][1] + '" tabindex="0" onClick="byClicked(this)">' + byer[i][0] + '</div>';
                input = byInput.value;
                options++;
            }
        }

        if (options == 0) {
            autocompleteOptions.innerHTML = '<div class="autocompleteError">Ingen stoppesteder funnet</div>';
        } else if (options == 1) {
            var childs = autocompleteOptions.childNodes;
            var child = childs[0];
            if (child.innerHTML.toLowerCase() === byInput.value.toLowerCase()) {
                child.style.backgroundColor = "#dddddd";
            }
        }
    }, 1);
}

document.addEventListener('focusin', function () {

    if (document.activeElement.className === "autocompleteItem") {
        byInput.value = document.activeElement.innerHTML;
    }

    if (document.activeElement.parentElement.parentElement !== autocomplete && document.activeElement.parentElement !== autocomplete) {
        closeAutocomplete();
    }
}, true);

document.addEventListener("click", function () {
    if (document.activeElement.parentElement.parentElement !== autocomplete && document.activeElement.parentElement !== autocomplete) {
        closeAutocomplete();
    }
})

function selectDateAndTime() {
    var date = new Date();
    var hour = date.getHours();
    if (hour >= 23) {
        var tomorrow = new Date(date)
        date.setDate(tomorrow.getDate() + 1);
    }

    switch (hour) {
        case 0, 1, 2, 3, 4, 5, 23, 24:
            document.getElementById("time6").selected = true;
            break;
        case 6:
            document.getElementById("time7").selected = true;
            break;
        case 7:
            document.getElementById("time8").selected = true;
            break;
        case 8:
            document.getElementById("time9").selected = true;
            break;
        case 9:
            document.getElementById("time10").selected = true;
            break;
        case 10:
            document.getElementById("time11").selected = true;
            break;
        case 11:
            document.getElementById("time12").selected = true;
            break;
        case 12:
            document.getElementById("time13").selected = true;
            break;
        case 13:
            document.getElementById("time14").selected = true;
            break;
        case 14:
            document.getElementById("time15").selected = true;
            break;
        case 15:
            document.getElementById("time16").selected = true;
            break;
        case 16:
            document.getElementById("time17").selected = true;
            break;
        case 17:
            document.getElementById("time18").selected = true;
            break;
        case 18:
            document.getElementById("time19").selected = true;
            break;
        case 19:
            document.getElementById("time20").selected = true;
            break;
        case 20:
            document.getElementById("time21").selected = true;
            break;
        case 21:
            document.getElementById("time22").selected = true;
            break;
        case 22:
            document.getElementById("time23").selected = true;
            break;
    }


    var day = date.getDate();
    if (day < 10) {
        day = "0" + day;
    }
    var month = date.getMonth() + 1;
    if (month < 10) {
        month = "0" + month;
    }
    var year = date.getFullYear();
    var dateFormatted = year + "-" + month + "-" + day;
    document.getElementById("dato").value = dateFormatted;
}

function openAutocomplete() {

    autocompleteOptions.style.display = "block";

}

function closeAutocomplete() {

    autocompleteOptions.style.display = "none";

}

document.onkeydown = function (e) {

    switch (e.keyCode) {
        case 13:
            if (document.activeElement === byInput) {
                leggTilBy(byInput.value);
            } else if (document.activeElement.className == "autocompleteItem") {
                leggTilBy(document.activeElement.innerHTML);
            }
        case 9:
            return;
            break;
        case 40:
            e.preventDefault();
            nextChild();
            return;
            break;
        case 38:
            prevChild();
            e.preventDefault();
            return;
            break;
        default:
            byInput.focus();
            break;
    }

    if (document.activeElement === byInput) {
        generateAutocompleteItems(byInput.value);
    }

}

function nextChild() {
    var childs = autocompleteOptions.children;
    if (document.activeElement == byInput) {
        childs[0].focus();
        return;
    }
    for (var i = 0; i < childs.length - 1; i++) {
        if (document.activeElement == childs[i]) {
            childs[i + 1].focus();
            return;
        }
    }
};

function prevChild() {
    var childs = autocompleteOptions.children;
    for (var i = 0; i < childs.length; i++) {
        if (document.activeElement == childs[i]) {
            if (i == 0) {
                byInput.focus();
                byInput.value = input;
            } else {
                childs[i - 1].focus();
            }
            return;
        }
    }
};

function byClicked(by) {
    leggTilBy(by.innerHTML);
}


function leggTilBy(by) {

    for (var i = 0; i < byer.length; i++) {
        if (byer[i].toLowerCase() == by.toLowerCase()) {
            if (avreiseSet.style.display !== "block") {
                avreiseSet.style.display = "block";
                avreiseSet.innerHTML = '<h3>Fra:</h3>' + by + '<a href="\webtest.html">Endre</a>';
                byInput.value = "";
                generateAutocompleteItems();
                byInput.placeholder = "Hvor vil du reise til?";
                byInput.focus();
                autocompleteOptions.scrollTo(0, 0);
            } else {
                ankomstSet.style.display = "block";
                ankomstSet.innerHTML = '<h3>Til:</h3>' + by + '<a href="#" onclick="resetAnkomstBy()">Endre</a>';
                autocomplete.style.display = "none";
                datoTidSet.style.display = "block";
            }

            break;
        }
    }

}

function resetAnkomstBy() {
    ankomstSet.style.display = "none";
    autocomplete.style.display = "block";
    byInput.value = "";
    datoTidSet.style.display = "none";
    generateAutocompleteItems();
    byInput.placeholder = "Hvor vil du reise til?";
    byInput.focus();
    autocompleteOptions.scrollTo(0, 0);
}

function consoleLog() {
    console.log("endre dato og tid");
}

function hentAlleHoldeplasser() {
    $.get("transport/hentAlleHoldeplasser", function (holdeplasser) {
        formaterHoldeplasser(holdeplasser);
    });
}

function formaterHoldeplasser(holdeplasser) {
    for (let holdeplass of holdeplasser) {
        console.log(holdeplass.id);
        byer.push([holdeplass.navn, holdeplass.id]);     
    }
    generateAutocompleteItems("");
    
}


function hentReiseRute() {
    const reise = {
        startholdeplass: "Fredrikstad",
    }
    $.get("transport/hentReise", reise, function (reiserute) {
        console.log(reiserute);
    });

}
    