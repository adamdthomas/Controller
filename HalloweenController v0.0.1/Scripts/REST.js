function SendPost(URI) {

    var PostResponse = "FAILED";
    var req = new XMLHttpRequest();
    req.open("POST", URI, true);
    req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");


    req.onreadystatechange = function () {
        if (req.readyState == 4) {
            PostResponse = "PASSED";
        }
    }

    req.send(null);

    return(PostResponse);
 }

function GetAlertType(URI) {
 var PR = SendPost(URI);
    
    var AlertType = "ButtonFailure";

    
    if (PR == "FAILED") {

       
        AlertType = 'ButtonFailure';
        setTimeout(function () { showDiv('ButtonFailure') }, 50);
        setTimeout(function () { hideDiv('ButtonFailure') }, 15000);
      
    }
    return AlertType
}

function Respond(Response, Timeout, ID, URI) {
    var req = new XMLHttpRequest();
    req.open("POST", URI, true);
    req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    req.onreadystatechange = function () {
        //if (req.readyState == 4) {
            //if (req.status.toString() == 200) {
      
            //} else {
                //AlertType = 'ButtonFailure';
                //setTimeout(function () { showDiv('ButtonFailure') }, 50);
                //setTimeout(function () { hideDiv('ButtonFailure') }, 15000);
           // }
        }
    
    req.send(null);
    setTimeout(function () { showDivWithMessage('ButtonSuccess') }, 50);
    setTimeout(function () { hideDiv('ButtonSuccess') }, 5000);

    switch (Response.toLowerCase()) {
        case "lockbutton":
            setTimeout(function () { hideDiv(ID) }, 5);
            setTimeout(function () { showDiv(ID) }, (parseInt(Timeout) * 1000));
            break;
        case "lockall":
            setTimeout(function () { hideDiv("buttonholder") }, 5);
            setTimeout(function () { showDiv("buttonholder") }, (parseInt(Timeout) * 1000));
            break;
        case "locknone":
            break;
}
}


function hideDiv(divid) {

    if (document.getElementById) { // DOM3 = IE5, NS6 
        $("#" + divid).hide(1200);
        
    }
    else {
        if (document.layers) { // Netscape 4 
            $("#" + divid).hide(1200);
            document.hideShow.visibility = 'hidden';
        }
        else { // IE 4 
            $("#" + divid).hide(1200);
            document.all.hideShow.style.visibility = 'hidden';
        }
    }
}


function hideDivFAST(divid) {

    if (document.getElementById) { // DOM3 = IE5, NS6 
        $("#" + divid).hide(0);

    }
    else {
        if (document.layers) { // Netscape 4 
            $("#" + divid).hide(0);
            document.hideShow.visibility = 'hidden';
        }
        else { // IE 4 
            $("#" + divid).hide(0);
            document.all.hideShow.style.visibility = 'hidden';
        }
    }
}

function showDivWithMessage(divid) {
    if (document.getElementById) { // DOM3 = IE5, NS6 
        document.getElementById('funnies').innerHTML = getRandomFunnies();
        $("#" + divid).show(250);
    }
    else {
        if (document.layers) { // Netscape 4 
            document.getElementById('funnies').innerHTML = getRandomFunnies();
            $("#" + divid).show(250);
            document.hideShow.visibility = 'visible';
        }
        else { // IE 4 
            document.getElementById('funnies').innerHTML = getRandomFunnies();
            $("#" + divid).show(250);
            document.all.hideShow.style.visibility = 'visible';
        }
    }

}

function showDiv(divid) {
    if (document.getElementById) { // DOM3 = IE5, NS6 
        
        $("#" + divid).show(250);
    }
    else {
        if (document.layers) { // Netscape 4 
         
            $("#" + divid).show(250);
            document.hideShow.visibility = 'visible';
        }
        else { // IE 4 
           
            $("#" + divid).show(250);
            document.all.hideShow.style.visibility = 'visible';
        }
    }

}


function getRandomFunnies()
{
    var items = ["Bam!",
        "I think we are going to have to hose the sidewalk off...",
        "Stare at the dark too long and you will eventually see what isn’t there.",
        "I see years of therapy in that childs future.",
        "And boom goes the dynamite...",
        "Pow!",
        "Scared for life!",
        "Poor kiddo :(",
        "Boo!",
        "Holy Cow!",
        "Eat, drink and be scary.",
        "There are nights when the wolves are silent and only the moon howls.",
        "Sometimes the things you see in the shadows are more than just shadows.",
        "Taily bone, taily bone... I'll get my taily bone",
        "It's behind me... isnt it?",
        "Bazingaa!"];
    var item = items[Math.floor(Math.random() * items.length)];
    return item;

}



