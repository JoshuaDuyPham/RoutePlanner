$(document).ready(function () {
    $(function () {
        $("#DestinationList").sortable();
        $("#DestinationList").disableSelection();
    });
    $(function () {
        $("#DestinationList li").draggable();
        $("#TrashCan").droppable({
            drop: function (event, ui) {
                ui.draggable.remove();
            }
        });
    });
});