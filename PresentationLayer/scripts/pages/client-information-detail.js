var ApiUrl = "https://localhost:44302";
var url = new URL(window.location.href);
var key = url.searchParams.get("Key");

$(document).ready(function () {
 
   // alert(key);

    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            ClientInformationID: key
        }),
        async: false,
        url: ApiUrl + '/api/ClientInformation/GetClientInformation',
        success: function (data) {
           

            var dob = new Date(data.DateOfBirth);

            var day = ("0" + dob.getDate()).slice(-2);
            var month = ("0" + (dob.getMonth() + 1)).slice(-2);

            var formattedDob = dob.getFullYear() + "-" + (month) + "-" + (day);

           

            $("#title").val(data.Title);
            $("#name").val(data.Name);
            $("#middlename").val(data.MiddleName);
            $("#surname").val(data.Surname);
            $("#gender").val(data.Gender);
            $("#dob").val(formattedDob);
            $("#idnumber").val(data.IDNumber);
            $("#cell").val(data.Cell);
            $("#tellhome").val(data.TelHome);
            $("#tellwork").val(data.TelWork);
            $("#email").val(data.Email);
            $("#streetNameandnumber").val(data.StreetNameAndNumber);
            $("#suburb").val(data.Suburb);
            $("#city").val(data.City);
            $("#postalcode").val(data.PostalCode);

        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert("Sorry, something went wrong. Please see the console for more info.");
            console.log(textStatus);
            console.log(errorThrown);
        }
    });

});

$('#clientform').submit(function (e) {
    e.preventDefault();
    $('.btn-primary').html("processing");
    $('.btn-primary').prop('disabled', true);

    var ClientInformation = JSON.stringify({
        Title: $("#title").val(),
        Name: $("#name").val(),
        MiddleName: $("#middlename").val(),
        Surname: $("#surname").val(),
        Gender: $("#gender").val(),
        DateOfBirth: $("#dob").val(),
        IDNumber: $("#idnumber").val(),
        Cell: $("#cell").val(),
        TelHome: $("#tellhome").val(),
        TelWork: $("#tellwork").val(),
        Email: $("#email").val(),
        StreetNameAndNumber: $("#streetNameandnumber").val(),
        Suburb: $("#suburb").val(),
        City: $("#city").val(),
        PostalCode: $("#postalcode").val(),
        ClientInformationID: key
    });

    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        data: ClientInformation,
        async: false,
        url: ApiUrl + '/api/ClientInformation/UpdateClientInformation',
        success: function (data) {
            alert("Client information has been updated successfully.");
            $('.btn-primary').prop('disabled', false);
            $('.btn-primary').html("Update");
            window.location.assign("/index.html");
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert("Sorry, something went wrong. Please see the console for more info.");
            console.log(textStatus);
            console.log(errorThrown);
            $('.btn-primary').html("Update");

        }
    });
});

