var currentLocation = location.href;
var menuItem = document.querySelectorAll('a');
const menuLength = menuItem.length;
for (var i = 0; i < menuLength; i++) {
    if (menuItem[i].href === currentLocation) {
        menuItem[i].className = "active";
    }

}

                        