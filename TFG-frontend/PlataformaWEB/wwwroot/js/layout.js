
function dropd(classname) {
    
    var dropdowns = ['dropdown-container-user', 'dropdown-container-admin', 'dropdown-container-manag', 'dropdown-container-op', 'dropdown-container-rep', 'dropdown-container-mon']
    
    for (d of dropdowns) {
        
        var dropdown = $("." + d);
        var b = d.replace("-container", "");

        if (classname.localeCompare(d) != 0 ) {
            dropdown.slideUp();
            $("." + b).css("font-weight", "normal");
            $("." + b).css("color", "#777777");
        }
        if (classname.localeCompare(d) == 0 && dropdown.css("display") == "none") {
            dropdown.slideDown();    
            $("." + b).css("font-weight", "bold");
            $("." + b).css("color", "black");
        }
        else if (classname.localeCompare(d) == 0 && dropdown.css("display") == "block") {
            dropdown.slideUp();
            $("." + b).css("font-weight", "normal");
            $("." + b).css("color", "#777777");
        }
    }
}

function lang_select(lang) {
    if (lang.localeCompare('#esp_lang') == 0) {
        $("#esp_lang").css("background-color", "#BF84AE");
        $("#esp_lang").css("font-weight", "bold");
        $("#esp_lang").css("color", "black");
        $("#eng_lang").css("background-color", "#E890D0");
        $("#eng_lang").css("font-weight", "normal");
        $("#eng_lang").css("color", "white");
    }
    else {
        $("#eng_lang").css("background-color", "#BF84AE");
        $("#eng_lang").css("font-weight", "bold");
        $("#eng_lang").css("color", "black");
        $("#esp_lang").css("background-color", "#E890D0");
        $("#esp_lang").css("font-weight", "normal");
        $("#esp_lang").css("color", "white");
    }
    
}        