$(document).ready(function() {

    var walletCount = $('.wallet-overlay').data('walletcount');

    if(walletCount < 1) {
        console.log(walletCount)
        $('.wallet-overlay').show();
    }

    $('#SelectCurrency').on('click', function(e) {
        $('.currency-overlay').show();
    });

    $('.currency-items>.row>.hover-item').on('click', function(e) {
        var countryVal = $(this).find('.country-id').val();
        var currencyName = $(this).find('.currency-name').text();

        $('#CurrencyId').val(countryVal).trigger('change');;
        $('#SelectCurrency').find('.currency-name').text(currencyName);
        $(this).closest('.overlay').hide();
    });
});