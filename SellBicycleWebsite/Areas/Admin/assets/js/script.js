/*var width = $(window).width(), height = $(window).height();
alert('width : ' +width + 'height : ' + height);*/
"use strict";
$(document).ready(function() {

    // checkbox / start $('.selected_all').on('click', function(){     var
    // checkBoxes = $("input[type='checkbox']");     checkBoxes.attr("checked",
    // !checkBoxes.attr("checked")); }) checkbox / end

    // stop collapse when click status
    $(document)
        .on('click', '[data-toggle=collapse] .disable-arr', function(e) {
            e.stopPropagation();
        });

    // autoNumeric/ start
    var contenTbody = $('.detail-list .table tbody');
    $('.box-pro').on('click', function() {
        var input = $("#searchmother");
        $('.list-find').removeClass('list-show');

        var textSearch = $(this).find('.title').text();
        input.val(textSearch);
        num++;
        contenTbody.append('<tr>' +
            '<td>' +
            textSearch +
            '</td>' +
            '<td class="num"><input type="text" class="form-control" placeholder="Giá bán"></td>' +
            '<td><input type="text" class="form-control" placeholder="Số lượng"></td>' +
            '<td class="num"><input type="text" class="form-control" placeholder="Tổng giá"></td><td>' +
            '<a class="delete-item" href="#"><i class="ti-trash"></i></a></td>' +
            '</tr>');
        var options = {
            aSep: '.',
            aDec: ',',
            aSign: '',
            mDec: 0,
            vMin: '0',
            wEmpty: 'zero',
            lZero: 'deny',
        }
        $('.num input').autoNumeric('init', options);
    })
    var options = {
        aSep: '.',
        aDec: ',',
        aSign: '',
        mDec: 0,
        vMin: '0',
        wEmpty: 'zero',
        lZero: 'deny',
    }
    $('.num input').autoNumeric('init', options);
    // autoNumeric/ end

    $('#mobile-collapse').on('click', function() {
        $('.pcoded-navbar').toggleClass('show-menu');
        $('.pcoded').toggleClass('expanded');
        $('.pcoded-content').toggleClass('expanded');
        $('.pcoded-navbar').toggleClass('expanded');
    });

    function hideImage() {
        $('#load').show();
        $('.modal-dialog').css("display", "none");

        setTimeout(function() {
            $('#load').hide();
        }, 1000);

        setTimeout(function() {
            $('.modal-dialog').css("display", "block");
        }, 1100);
    }
    // thực hiện lọc loại khách hàng click out to close search form / end. Sự kiện
    // radio button cho công ty và cá nhân.
    $('.hidden_com').hide();
    $('.type_cu input[type="radio"]').on('click', function() {
        if ($(this).val() === "personal") {
            $('.hidden_com').hide();
        } else if ($(this).val() === "company") {
            $('.hidden_com').show();
        }
    });

    // end thêm form vị trí
    var contenForm = $('.storage');
    var num = 0;
    var arraysFrom = [];
    var index = 0;
    var contentAdd = '<div class="form-group"> <label for="">Nhập khu vực</label><div class="input-gro' +
        'up padding_">	<span class="input-group-icon"><i class="fa fa-map-marker"></i></s' +
        'pan>	<input type="search" id="search1" name="search1" placeholder="Nhập khu vực"' +
        ' class="form-control"><span class="input-group-icon right-icon"><i class="fa fa-' +
        'trash"></i></span></div></div>';

    $('.add-posi').on('click', function() {
        index++;
        var add_item_index = 0;
        arraysFrom.push(contentAdd);
        for (let i = 0; i < arraysFrom.length; i++) {

            add_item_index = arraysFrom.length - 1;
        }

        if (add_item_index > 0) {

            contenForm.append(arraysFrom[add_item_index]);
            console.log('123');

        } else {
            contenForm.append(contentAdd);
            console.log('321');
        }

        var deleteButton = $('.remove-click');
        var danhsachxoa = document.querySelectorAll('.remove-click');
        var listDanhSachXoa = danhsachxoa.length;
        console.log(danhsachxoa);

        for (let i = 0; i < listDanhSachXoa; i++) {

            danhsachxoa[i]
                .addEventListener('click', function() {
                    console.log(danhsachxoa[i]);
                })
        }

    });
    // end
    var menu = $('.list-find'),
        menu_02 = $('.list-find_02'),
        menu_03 = $('.list-find_03');
    $(document).mouseup(function(e) {
        if (!menu.is(e.target) && menu.has(e.target).length === 0) {
            menu.removeClass('list-show');
            menu_02.removeClass('list-show');
            menu_03.removeClass('list-show');
        }
    });
    // hiển thị modal thêm vị  trí chi nhánh
    $('a.showmodal').on('click', function(event) {
            event.preventDefault();
            $('#storeModal').modal('show');
        })
        // hiển thị modal thêm vị  trí chi nhánh
    $('a.showmodal-password').on('click', function(event) {
        event.preventDefault();
        $('#passChange').modal('show');
    })

    $("#searchmother_02").on("click", function() {
        $('.list-find_02').addClass('list-show');
    });

    // complete name input / start
    var danhsach = document.querySelectorAll('.list-find ul li'),
        danhsach_02 = document.querySelectorAll('.list-find_02 ul li'),
        danhsach_level = document.querySelectorAll('.list-find_02.list_level ul li > ul li');
    var listLeght = danhsach.length,
        listLeght_02 = danhsach_02.length,
        listLeght_level = danhsach_level.length,
        textInner = '',
        textChild = '';

    // list 02
    for (let i = 0; i < listLeght; i++) {
        danhsach[i]
            .addEventListener('click', function() {
                textInner = $(this)
                    .find('.title')
                    .text();
                document
                    .getElementById("searchmother")
                    .value = textInner;
                $('.list-find').removeClass('list-show');
            })
    }
    for (let i = 0; i < listLeght_level; i++) {
        danhsach_level[i]
            .addEventListener('click', function() {
                var text_child = '';
                text_child = $(this)
                    .text()
                    .trim();
                textChild = ' / ' + text_child;
                $('.list-find_02').removeClass('list-show');
            })
    }
    for (let i = 0; i < listLeght_02; i++) {
        danhsach_02[i]
            .addEventListener('click', function() {
                textInner = $(this)
                    .find('.title')
                    .text();
                console.log(textInner + textChild);
                document
                    .getElementById("searchmother_02")
                    .value = textInner + textChild;
                $('.list-find_02').removeClass('list-show');
            })

    }

    var danhsach3 = document.querySelectorAll('.list-find ul li'),
        danhsach_03 = document.querySelectorAll('.list-find_03 ul li'),
        danhsach_level3 = document.querySelectorAll('.list-find_03.list_level ul li > ul li');

    var listLeght3 = danhsach3.length,
        listLeght_03 = danhsach_03.length,
        listLeght_level3 = danhsach_level3.length,
        textInner3 = '',
        textChild3 = '';

    $("#searchmother_03").on("click", function() {
        $('.list-find_03').addClass('list-show');
    });
    // end
    $("#searchmother_03").on("input", function() {
        var input = $(this);
        var val = input.val();
        if (val != '') {
            input.data("lastval", val);
            $('.list-find_03').addClass('list-show');
        } else {
            $('.list-find_03').removeClass('list-show');
        }
    });
    // list 03
    for (let i = 0; i < listLeght3; i++) {
        danhsach3[i]
            .addEventListener('click', function() {
                textInner3 = $(this)
                    .find('.title')
                    .text();
                document
                    .getElementById("searchmother")
                    .value = textInner3;
                $('.list-find').removeClass('list-show');
            })
    }
    for (let i = 0; i < listLeght_level3; i++) {
        danhsach_level3[i]
            .addEventListener('click', function() {
                var text_child3 = '';
                text_child3 = $(this)
                    .text()
                    .trim();
                textChild3 = ' / ' + text_child3;
                $('.list-find_03').removeClass('list-show');
            })
    }
    for (let i = 0; i < listLeght_03; i++) {
        danhsach_03[i]
            .addEventListener('click', function() {
                textInner3 = $(this)
                    .find('.title')
                    .text();
                console.log(textInner3 + textChild3);
                document
                    .getElementById("searchmother_03")
                    .value = textInner3 + textChild3;
                $('.list-find_03').removeClass('list-show');
            })

    }

    // datetimepicker / start
    var container = "body";
    var options = {
        format: 'DD/MM/YYYY HH:ss',
        locale: 'vi'
    };

    $(function() {
        $('#datepicker').datetimepicker(options);
        $('#datepicker_end').datetimepicker(options);
        $('#datepicker_01').datetimepicker(options);
        $('#datepicker_02').datetimepicker(options);
    });

    // datetimepicker / end

    var $window = $(window);
    //add id to main menu for mobile menu start
    var getBody = $("body");
    var bodyClass = getBody[0].className;
    $(".main-menu").attr('id', bodyClass);
    //add id to main menu for mobile menu end card js start
    $(".card-header-right .close-card").on('click', function() {
        var $this = $(this);
        $this
            .parents('.card')
            .animate({ 'opacity': '0', '-webkit-transform': 'scale3d(.3, .3, .3)', 'transform': 'scale3d(.3, .3, .3)' });

        setTimeout(function() {
            $this
                .parents('.card')
                .remove();
        }, 800);
    });
    $(".card-header-right .reload-card").on('click', function() {
        var $this = $(this);
        $this
            .parents('.card')
            .addClass("card-load");
        $this
            .parents('.card')
            .append('<div class="card-loader"><i class="icofont icofont-refresh rotate-refresh"></div' +
                '>');
        setTimeout(function() {
            $this
                .parents('.card')
                .children(".card-loader")
                .remove();
            $this
                .parents('.card')
                .removeClass("card-load");
        }, 3000);
    });
    $(".card-header-right .card-option .icofont-simple-left").on('click', function() {
        var $this = $(this);
        if ($this.hasClass('icofont-simple-right')) {
            $this
                .parents('.card-option')
                .animate({ 'width': '35px' });
        } else {
            $this
                .parents('.card-option')
                .animate({ 'width': '180px' });
        }
        $(this)
            .toggleClass("icofont-simple-right")
            .fadeIn('slow');
        // $this.children("li .icofont-simple-left").toggleClass("");
    });

    $(".card-header-right .minimize-card").on('click', function() {
        var $this = $(this);
        var port = $($this.parents('.card'));
        var card = $(port)
            .children('.card-block')
            .slideToggle();
        $(this)
            .toggleClass("icofont-plus")
            .fadeIn('slow');
    });
    $(".card-header-right .full-card").on('click', function() {
        var $this = $(this);
        var port = $($this.parents('.card'));
        port.toggleClass("full-card");
        $(this).toggleClass("icofont-resize");
    });

    $(".card-header-right .icofont-spinner-alt-5").on('mouseenter mouseleave', function() {
        $(this)
            .toggleClass("rotate-refresh")
            .fadeIn('slow');
    });
    $("#more-details").on('click', function() {
        $(".more-details").slideToggle(500);
    });
    $(".mobile-options").on('click', function() {
        $(".navbar-container .nav-right").slideToggle('slow');
    });
    $(".main-search").on('click', function() {
        $("#morphsearch").addClass('open');
    });
    $(".morphsearch-close").on('click', function() {
        $("#morphsearch").removeClass('open');
    });
    // card js end
    $.mCustomScrollbar.defaults.axis = "yx";
    $("#styleSelector .style-cont").mCustomScrollbar({ setTop: "10px", setHeight: "calc(100% - 200px)" });
    $(".main-menu").mCustomScrollbar({ setTop: "10px", setHeight: "calc(100% - 80px)" });
});
$(document).ready(function() {
    $(function() {
        $('[data-toggle="tooltip"]').tooltip()
    })
    $('.theme-loader').fadeOut('slow', function() {
        $(this).remove();
    });
});

// toggle full screen
function toggleFullScreen() {
    var a = $(window).height() - 10;

    if (!document.fullscreenElement && // alternative standard method
        !document.mozFullScreenElement && !document.webkitFullscreenElement) { // current working methods
        if (document.documentElement.requestFullscreen) {
            document
                .documentElement
                .requestFullscreen();
        } else if (document.documentElement.mozRequestFullScreen) {
            document
                .documentElement
                .mozRequestFullScreen();
        } else if (document.documentElement.webkitRequestFullscreen) {
            document
                .documentElement
                .webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT);
        }
    } else {
        if (document.cancelFullScreen) {
            document.cancelFullScreen();
        } else if (document.mozCancelFullScreen) {
            document.mozCancelFullScreen();
        } else if (document.webkitCancelFullScreen) {
            document.webkitCancelFullScreen();
        }
    }
}

//light box
$(document)
    .on('click', '[data-toggle="lightbox"]', function(event) {
        event.preventDefault();
        $(this).ekkoLightbox();
    });

// Upgrade Button
var $window = $(window);
var nav = $('.fixed-button');
$window.scroll(function() {
    if ($window.scrollTop() >= 200) {
        nav.addClass('active');
    } else {
        nav.removeClass('active');
    }
});