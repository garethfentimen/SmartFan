var xmlhttp = new XMLHttpRequest();
xmlhttp.open("GET", "api/team/", true);
//xmlhttp.setRequestHeader('NewOrbitManagementApiToken', '898F28BD-0513-4694-9A96-01469236499F');
xmlhttp.onreadystatechange = function () {
    if (xmlhttp.readyState != 4 || xmlhttp.status != 200) {
        $('#teams').text(xmlhttp.responseText);
    } else {
        console.log(xmlhttp.responseText);
        $('#teams').text(xmlhttp.responseText);
    }
};
xmlhttp.send();