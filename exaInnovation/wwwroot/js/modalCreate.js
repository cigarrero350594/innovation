(function ($) {
    function Index() {
        var $this = this;
        function initialize() {
            console.log('Inicializa');
            $(".popup").on('click', function (e) {
                modelPopup(this);
            });

            function modelPopup(reff) {
                var url = $(reff).data('url');
                var id = $(reff).attr('data-id');
                console.log('Inicializar 1');
                console.log(id);
                if (id != null) {
                    $.get(url + '/' + id).done(function (data) {

                        console.log('Inicializa2');
                        $('#modal-create-meta').find(".modal-dialog").html(data);
                        $('#modal-create-meta > .modal', data).modal("show");
                    });
                }
                else {
                    $.get(url).done(function (data) {

                        console.log('Inicializa3');
                        $('#modal-create-meta').find(".modal-dialog").html(data);
                        $('#modal-create-meta > .modal', data).modal("show");
                    });
                }
                

            }
        }

        $this.init = function () {
            initialize();
        };
    }
    $(function () {
        var self = new Index();
        self.init();
    });
}(jQuery));  