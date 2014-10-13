var Food = Food || {};

Food.MenuDetails = (function () {

    var self = function () {

        var init = function () {
            addEvents();
        },

        addEvents = function() {
            $("#MenuId").onchange(function () {

            });
        }
        return {
            Init: init
        }

    }
    return self();
})();