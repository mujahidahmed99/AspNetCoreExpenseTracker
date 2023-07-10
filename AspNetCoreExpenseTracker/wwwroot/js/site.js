// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function() {

    $('.close-popup').on('click', function(e) {
        $(this).closest('.overlay').hide();
    });

    $('.form-validation').find('.validate-input').on('change', function(e) {
        var allFilled = true;
        $('.form-validation').find('.validate-input').each(function(e) {
            if ($(this).val() === '') {
                console.log($(this));
                console.log($(this).val());
                allFilled = false;
                return false;
            }
        });

        if (allFilled) {
            $('.submit-form').prop('disabled', false);
        } else {
            $('.submit-form').prop('disabled', true);
        }
    });

    $('.amount-input').focus(function() {
        if ($(this).val() === '0') {
          $(this).val('');
        }
      });

    $('.amount-input').blur(function() {
    if ($(this).val() === '') {
        $(this).val('0');
    }
    });
});

