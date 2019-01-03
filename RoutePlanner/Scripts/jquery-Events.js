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
    $(function () {
        $("#destination_list_label").tooltip({
            position: {
                my: "center bottom",
                at: "right",
                using: function (position, feedback) {
                    $(this).css(position);
                    $("<div>")
                        .addClass("arrow")
                        .addClass(feedback.vertical)
                        .addClass(feedback.horizontal)
                        .appendTo(this);
                }
            }
        });
    });
});