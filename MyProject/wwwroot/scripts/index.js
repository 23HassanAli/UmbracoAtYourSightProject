document.addEventListener('click', function handleClick(event) {
    console.log('user clicked: ', event.target);
    event.target.classList.add('activate');
}