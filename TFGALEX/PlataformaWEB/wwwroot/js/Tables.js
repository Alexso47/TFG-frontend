$(document).ready(function () {
    
    $('#dataTable').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ resultados",
            "infoEmpty": "Mostrando 0 to 0 of 0 resultados",
            "infoFiltered": "(Filtrado de _MAX_ total resultados)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": ": ordenar columna de forma ascendiente",
                "sortDescending": ": ordenar columna de forma descendiente"
            }
        }
    });
    $('.dataTables_length').addClass('bs-select');   
});