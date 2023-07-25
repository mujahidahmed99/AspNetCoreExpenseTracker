$(document).ready(function(){

    $("#datepicker").datepicker("setDate", new Date())
        .on('changeDate', function(ev) {
            var selectedDate = $(this).datepicker('getDate').toLocaleDateString('en-GB');
            $('#DateField').val(selectedDate);
            $('.display-date').text(selectedDate);
            $('.select-date-overlay').hide();
        });
    
    $("#datepicker")
        .append("<div class='row'>" +
                "<div class='col text-end'>" +
                "<button class='btn text-success date-cancel hover-item'>Cancel</button>" +
                "</div>" +
                "</div>");
    
    $('.btn-transaction').on('click', function(e) {
        $('.transaction-overlay').show();
    });

    $('.category-filter>.hover-item').on('click', function(e) {
        $('.category-filter>.hover-item').removeClass('text-success');

        $(this).addClass('text-success');
        var tabValue = $(this).data('tab');
        displayTab(tabValue);
    });


    $('#SelectCategory').on('click', function(e) {
        $('.select-category-overlay').show();
    });

    $('#SelectWallet').on('click', function(e) {
        $('.select-wallet-overlay').show();
    });

    $('#SelectDate').on('click', function(e) {
        $('.select-date-overlay').show();
    });

    $('.category-items>.hover-item').on('click', function(e) {
        var categoryVal = $(this).find('.category-id').val();
        var categoryName = $(this).find('.category-name').text();

        $('#CategoryId').val(categoryVal).trigger('change');;
        $('#SelectCategory').find('.category-name').text(categoryName);
        $(this).closest('.overlay').hide();
    });

    $('.wallet-items>.hover-item').on('click', function(e) {
        var walletVal = $(this).find('.wallet-id').val();
        var walletName = $(this).find('.wallet-name').text();

        $('#WalletId').val(walletVal).trigger('change');;
        $('#SelectWallet').find('.wallet-name').text(walletName);
        $(this).closest('.overlay').hide();
    });

    $('.date-cancel').on('click', function(e) {
        $('.select-date-overlay').hide();
    });

    $('#TransactionForm').submit(function(e)
    {
        e.preventDefault();
        var formData = $(this).serialize();
        console.log(formData);

        $.ajax({
            type: "POST",
            url: "home/AddTransaction",
            data: formData,
            success: function (response) {
                $('.transaction-overlay').hide();
                getAllTransactions();
            },
            error: function(xhr, status, error) {
                console.error(error);
            }
        });
    });
});

function displayTab(tabValue) {
    var queryTabValue = tabValue;
    console.log(queryTabValue);
    var containers  = document.querySelectorAll('.category-items');
    $(containers).hide();

    var container = document.querySelector(`.category-items[data-tab="${queryTabValue}"]`);
    if(container) {
        $(container).show();
    }
}

function getAllTransactions() {
    $.ajax({
        type: "GET",
        url: "home/GetAllTransactions",
        success: function(data) {
            var html = '';
            for(var i = 0; i < data.length; i++) {
                var group = data[i];
                console.log(group);
                html += '<div class="d-flex flex-column mt-4 bg-white py-2">';
                html += '<ul class="list-group">';
                html += '<li class="list-group-item border-0 d-flex justify-content-between border-bottom px-4">';
                html += '<div class="d-flex flex-column">';
                html += '<span class="fs-5">' + group.categoryName + '</span>';
                html += '<span>' + group.transactions.length + ' transactions' + '</span>';
                html += '</div>';
                var totalAmount = group.totalAmount >= 0 ? '+' + group.totalAmount.toLocaleString(undefined, { style: 'currency', currency: 'GBP' }) :
                                    group.totalAmount.toLocaleString(undefined, { style: 'currency', currency: 'GBP' });
                html += '<span style="align-self: center;" class="amount">' + totalAmount + '</span>';
                html += '</li>';
                for(var j = 0; j < group.transactions.length; j++)
                {
                    var transaction = group.transactions[j];
                    html += '<li class="list-group-item border-0 d-flex justify-content-between py-3 px-4">';
                    html += '<span>' + moment(transaction.date).format("DD dddd, MMMM YYYY") + '</span>';
                    var amount = transaction.amount >= 0 ? '+' + transaction.amount.toLocaleString(undefined, { style: 'currency', currency: 'GBP' }) : 
                                    transaction.amount.toLocaleString(undefined, { style: 'currency', currency: 'GBP' });
                    html += '<span class="amount">' + amount + '</span>';
                    html += '</li>';
                }
            html += '</ul>';
            html += '</div>';

            $('#TransactionContainer').html(html);
            }
        }
    });
}