
    function ajaxCustomCall(uri, type, dataValue, returnFunc)
    {
        $.ajax({
            url: uri,
            type: type,
            dataType: "json",
            contentType: 'application/json;',
            data: JSON.stringify(dataValue),
            success: function (val) {
                eval(returnFunc);
            },
            error: function (nothing) {
                
            }
        });
}

    function resultPopup(resultType, msg) {
        Swal.fire({
            position: 'top-end',
            icon: resultType,
            title: msg,
            showConfirmButton: false,
            timer: 1500
        })
    }


    function loginResponseParser(val) {
        $('#loginReqBtn').prop("disabled", false);
        //console.log(val);
        if (val.status) {
            $('#loginReqBtn').text("Giriş Başarılı!");
            window.location.href = '/Home';
        } else {
            $('#loginReqBtn').text("Giriş");
            resultPopup('error', val.message);
        }
        
    }


    $(document).ready(function () {
       
        // Login Requst
        $('#loginReqBtn').click(function () {
           
            var User = new Object();
            User.username = $('#username').val();
            User.password = $('#password').val();

            if (User.username == "" || User.password == "") { resultPopup('error', 'Zorunlu alanları doldurunuz!'); return; }

            $('#loginReqBtn').prop("disabled", true);
            $('#loginReqBtn').text("Giriş Yapılıyor...");

            ajaxCustomCall('/Login/checkUser', 'POST', User, 'loginResponseParser(val)');


        });
    });

