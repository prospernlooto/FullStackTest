var ApiUrl = "https://localhost:44302";

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
        PostalCode: $("#postalcode").val()
    });

    $.ajax({
      type: 'POST',
      contentType: 'application/json',
      data: ClientInformation,
      async: false,
        url: ApiUrl + '/api/ClientInformation/AddClientInformation',
        success: function (data) {
            alert("Client has been added successfully.");
            $('.btn-primary').prop('disabled', false);
            $('.btn-primary').html("Save");
            window.location.assign("/index.html");
      },
        error: function (jqXhr, textStatus, errorThrown) {
          alert("Sorry, something went wrong. Please see the console for more info.");
          console.log(textStatus);
            console.log(errorThrown);
            $('.btn-primary').html("Save");

      }
    });
});