$(document).ready(function () {

    SetDataTable()
    SetSelect2()
});

function SetDataTable() {

    var table = $('.data_table')

    if (table.length == 0)
        return;

    table.DataTable({
        dom: 'Bfrtlip',
        buttons: [
            'copy', 'excel', 'pdf'
        ]
    })

    new $.fn.dataTable.Responsive(table, {
        responsive: {
            details: {
                display: $.fn.dataTable.Responsive.display.childRow
            }
        },
    });
}

function SetSelect2() {

    const select2 = $('.select_2')

    if (select2.length == 0)
        return;

    select2.each(function () {

        const modal = $(this).closest('.modal')

        if (modal.length != 0) {
            $(this).select2({
                dropdownParent: modal
            })
        }
        else {
            $(this).select2();
        }
    })
}