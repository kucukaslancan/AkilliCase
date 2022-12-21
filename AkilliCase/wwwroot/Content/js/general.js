$(document).ready(function () {
  
    var table;
    $.ajax({
        type: 'GET',
        url: '/Product/getAllProduct',
        success: function (d) {
            table = $('#dataTable').DataTable({
                "data": d,
                "columns": [
                    { "data": "stockCode" },
                    { "data": "name" },
                    { "data": "price" },
                    { "data": "stock" } 
                ],
                columnDefs: [
                    {
                        targets: 4,
                        data: null,
                        defaultContent: '<button class="btn btn-info btn-icon-split"><span class="icon text-white-50"><i class="fas fa-info-circle"></i></span><span class="text">Ürün Detayı</span></button>',
                    },
                ]
            });
        }
    });

    $('#dataTable tbody').on('click', 'button', function () {
        var data = table.row($(this).parents('tr')).data();

        $('#detailModal').modal('show');
        $('#stockCode').val(data.stockCode);
        $('#stockName').val(data.name);
        $('#salesPrice').val(data.price);
        $('#stock').val(data.stock);
        $('#productName').html(data.name);
        
   
    });

});