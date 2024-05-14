
const btnToggler = window.document.querySelector(".navbar-toggler"); 
const inputSearch = window.document.querySelector(".navbar-search"); 
const iconSearch = window.document.querySelector("#icon-search");
const navbar = window.document.querySelector(".navbar");


btnToggler.addEventListener('click', () => {
    navbar.classList.toggle('active'); 
});

