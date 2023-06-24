const sideMenu = document.querySelector("aside");
const menuBtn = document.querySelector("#menu-btn");
const closeBtn = document.querySelector("#close-btn");
const themeToggler = document.querySelector(".theme-toggler");

menuBtn.addEventListener("click", () => {
    sideMenu.style.display = "block";
});

closeBtn.addEventListener("click", () => {
    sideMenu.style.display = "none";
});

themeToggler.addEventListener("click", () => {
    document.body.classList.toggle("dark-theme-variables");
    themeToggler.querySelector("span:nth-child(1)").classList.toggle("active");
    themeToggler.querySelector("span:nth-child(2)").classList.toggle("active");
});

const chart = document.querySelector("#chart").getContext("2d");

new Chart(chart, {
    type: "line",
    data: {
        labels: [
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7 ",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
        ],
        datasets: [
            {
                label: "Perfil Horário",
                data: [
                    10, 10, 10, 10, 10, 10, 30, 30, 30, 30, 30, 30, 10, 10, 10, 10, 30,
                    50, 70, 80, 100, 20, 30, 20,
                ],
                borderColor: "red",
                borderWidth: 2,
            },
        ],
    },
    options: {
        responsive: true,
    },
});

