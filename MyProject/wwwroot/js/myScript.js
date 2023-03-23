const apiUrl = '/Umbraco/Api/NewsArticles/GetAllArticles'

var navItems = document.querySelectorAll(".nav-item");
for (var i = 0; i < navItems.length; i++) {
    navItems[i].addEventListener("click", function () {
        this.classList.add("active");
    });


}

const seeMore = document.getElementById("seeMore");
if(seeMore != null) {
    seeMore.addEventListener("click", async function fetchJSON() {
        let response = await fetch(`${apiUrl}?skip=5&take=9`);

        if (response.ok) {

            let json = await response.json();
            console.log(json[0].publishedAt)
            let otherArticles = document.querySelector('.otherArticles');
            for (var i = 0; i < json.length; i++) {
                otherArticles.innerHTML += `
                            <div class="mb-5">
                            <div class="small text-muted">${json[i].publishedAt}</div>
                            <a class="link-dark" href="@item.Url"><h3>${json[i].title}</h3></a>
                            <img class="align-items-end" src="${json[i].urlToImage}" alt="${json[i].title}" style="width:200px;">
                        </div>`
            }
            if (json.length > 0) {
                document.getElementById("seeLess").style.display = 'block'
                document.getElementById("seeMore").style.display = 'none'
            }

        } else {
            alert("HTTP-Error: " + response.status);
        }
    });
}


const seeLess = document.getElementById("seeLess");
if (seeLess != null) {
    seeLess.addEventListener("click", function removeArticles() {
        console.log("seeLess")
        let element = document.getElementById('articles');
        while (element.hasChildNodes()) {
            element.removeChild(element.firstChild);
        }
        document.getElementById("seeLess").style.display = 'none'
        document.getElementById("seeMore").style.display = 'block'

    });
}

let links = document.getElementById('blog-post');

links.addEventListener('click', function handelClick(event) {
    console.log("with id click blog post" + event);
})

//links.forEach(link => {
//    link.addEventListener('click', function handelClick(event) {
//        console.log('link clickes' +  event);
//    });
//});

function handelClick(event) {
    console.log("function handle click" + event);
}
