


alert("alert" + document.querySelectorAll('.link').item);

document.querySelectorAll('.link').forEach(item => {
    item.addEventListener('click', () => {
        var current = document.getElementsByClassName("nav-link");
        console.log(item.className);
        // If there's no active class
        if (current.length > 0) {
            current[0].className = current[0].className.replace(" active", "");
        }

        // Add the active class to the current/clicked button
        this.className += " active";
    })
})




