function SignUp() {
    let data = $('#signup').serialize();

    $.ajax({
        type: "POST",
        url: '/Home/SignUp',
        data: data,
        processData: false,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8', 
        success: function (response) {
            if (response.flag) {
                alert('Create account successfully');
                window.location.href('/Home/Login');
            }
            else {
                alert('Create account unsuccessfully');
                window.location.href('/Home/SignUp');
            }
        }
    })
}