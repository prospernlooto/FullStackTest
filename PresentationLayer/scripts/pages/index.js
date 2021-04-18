var ApiUrl = "https://localhost:44302";

$(document).ready(function () {

    $('#txt_data').html('Loading');

    $.ajax({
        type: 'GET',
        contentType: 'application/json',
        data: null,
        async: false,
        url: ApiUrl + '/api/ClientInformation/GetAllClientInformation',
        success: function (data) {
          
            console.log(data);

            if (data.length === 0) {
                $('#txt_data').html('No data found');
            }
            else
            {
                $('#tbl_clientinfo').html('');

                $.each(data, function (key, value) {

                    var dob = new Date(value.DateOfBirth);

                    var formattedDate = dob.toLocaleDateString('en-GB');

                    var detailLink = "/client-information-detail.html?Key=" + value.ClientInformationID;

                    $('#tbl_clientinfo').append(`<tr><td>${value.Title}</td><td>${value.Name} ${value.MiddleName} ${value.Surname}</td><td>
                        ${formattedDate}</td><td>${value.Cell}</td><td>${value.Email}</td><td>
                        ${value.StreetNameAndNumber}</td><td><a href="${detailLink}" class="btn btn-light btn-small">view more</a></td></tr>`
                    );
                }); 
            }

        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert("Sorry, something went wrong. Please see the console for more info.");
            console.log(textStatus);
            console.log(errorThrown);
        }
    });
});