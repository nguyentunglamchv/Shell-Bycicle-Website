/*********************************************** Context Menu Function Only ********************************/
function clickInsideElement(e, className) {
    var el = e.srcElement || e.target;
    if (el.classList.contains(className)) {
        return el;
    } else {
        while (el = el.parentNode) {
            if (el.classList && el.classList.contains(className)) {
                return el;
            }
        }
    }
    return false;
}

function getPosition(e) {
    var posx = 0,
        posy = 0;
    if (!e)
        var e = window.event;
    if (e.pageX || e.pageY) {
        posx = e.pageX;
        posy = e.pageY;
    } else if (e.clientX || e.clientY) {
        posx = e.clientX + document.body.scrollLeft + document.documentElement.scrollLeft;
        posy = e.clientY + document.body.scrollTop + document.documentElement.scrollTop;
    }
    return { x: posx, y: posy }
}

// Your Menu Class Name
var taskItemClassName = "thumb";
var contextMenuClassName = "context-menu",
    contextMenuItemClassName = "context-menu__item",
    contextMenuLinkClassName = "context-menu__link",
    contextMenuActive = "context-menu--active";
var taskItemInContext,
    clickCoords,
    clickCoordsX,
    clickCoordsY,
    menu = document.querySelector("#context-menu"),
    menuItems = menu.querySelectorAll(".context-menu__item");
var menuState = 0,
    menuWidth,
    menuHeight,
    menuPosition,
    menuPositionX,
    menuPositionY,
    windowWidth,
    windowHeight;

function initMenuFunction() {
    contextListener();
    clickListener();
    keyupListener();
    resizeListener();
}

/**
 * Listens for contextmenu events.
 */
function contextListener() {
    document
        .addEventListener("contextmenu", function (e) {
            taskItemInContext = clickInsideElement(e, taskItemClassName);

            if (taskItemInContext) {
                e.preventDefault();
                toggleMenuOn();
                positionMenu(e);
            } else {
                taskItemInContext = null;
                toggleMenuOff();
            }
        });
}

/**
 * Listens for click events.
 */
function clickListener() {
    document
        .addEventListener("click", function (e) {
            var clickeElIsLink = clickInsideElement(e, contextMenuLinkClassName);

            if (clickeElIsLink) {
                e.preventDefault();
                menuItemListener(clickeElIsLink);
            } else {
                var button = e.which || e.button;
                if (button === 1) {
                    toggleMenuOff();
                }
            }
        });
}

/**
 * Listens for keyup events.
 */
function keyupListener() {
    window.onkeyup = function (e) {
        if (e.keyCode === 27) {
            toggleMenuOff();
        }
    }
}

/**
 * Window resize event listener
 */
function resizeListener() {
    window.onresize = function (e) {
        toggleMenuOff();
    };
}

/**
 * Turns the custom context menu on.
 */
function toggleMenuOn() {
    if (menuState !== 1) {
        menuState = 1;
        menu
            .classList
            .add(contextMenuActive);
    }
}

/**
 * Turns the custom context menu off.
 */
function toggleMenuOff() {
    if (menuState !== 0) {
        menuState = 0;
        menu
            .classList
            .remove(contextMenuActive);
    }
}

function positionMenu(e) {
    clickCoords = getPosition(e);
    clickCoordsX = clickCoords.x;
    clickCoordsY = clickCoords.y;
    menuWidth = menu.offsetWidth + 4;
    menuHeight = menu.offsetHeight + 4;

    windowWidth = window.innerWidth;
    windowHeight = window.innerHeight;

    if ((windowWidth - clickCoordsX) < menuWidth) {
        menu.style.left = (windowWidth - menuWidth) - 0 + "px";
    } else {
        menu.style.left = clickCoordsX - 0 + "px";
    }

    // menu.style.top = clickCoordsY + "px";

    if (Math.abs(windowHeight - clickCoordsY) < menuHeight) {
        menu.style.top = (windowHeight - menuHeight) - 0 + "px";
    } else {
        menu.style.top = clickCoordsY - 0 + "px";
    }
}

function menuItemListener(link) {
    var menuSelectedPhotoId = taskItemInContext.getAttribute("data-id");
    console.log('Your Selected Photo: ' + menuSelectedPhotoId)
    var moveToAlbumSelectedId = link.getAttribute("data-action");
    if (moveToAlbumSelectedId == 'remove') {
        console.log('You Clicked the remove button')
    } else if (moveToAlbumSelectedId && moveToAlbumSelectedId.length > 7) {
        console.log('Clicked Album Name: ' + moveToAlbumSelectedId);
    }
    toggleMenuOff();
}
initMenuFunction();