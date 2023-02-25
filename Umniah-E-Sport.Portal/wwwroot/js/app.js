const body = document.querySelector("body");
const mainElement = document.querySelector("main");
const menu = document.querySelector(".side-menu");
const menuIcon = document.querySelector(".menu-icon");
const closeMenuIcon = document.querySelector(".close-menu");
const scrollTabs = document.querySelectorAll(".custom-nav-link");
const navLink = document.querySelectorAll(".nav-link");

window.addEventListener("load", () => {
	body.classList.remove("preload");
});

function goBack() {
	window.history.back();
}

// menu code //
//////////////

if (menuIcon) {
	menuIcon.addEventListener("click", openMenu);
	window.addEventListener("scroll", () => {
		document.documentElement.style.setProperty(
			"--scroll-y",
			`${window.scrollY}px`
		);
	});
}
if (closeMenuIcon) {
	closeMenuIcon.addEventListener("click", closeMenu);
}
function closeMenu() {
	const scrollY = body.style.top;
	body.classList.remove("fixed-body");
	body.style.top = "";
	window.scrollTo(0, parseInt(scrollY || "0") * -1);
	menu.classList.remove("show");
}
function openMenu() {
	const mobWidth = document.querySelector(".mobile-view").offsetWidth + "px";
	menu.style.width = mobWidth;
	menu.classList.add("show");
	const scrollY = document.documentElement.style.getPropertyValue("--scroll-y");
	body.style.top = `-${scrollY}`;
	body.classList.add("fixed-body");
}
///////////////////////

// scrolling wrapper code //
///////////////////////////
scrollTabs.forEach((tab) => {
	tab.addEventListener("click", () => {
		scrollTabs.forEach((tab) => {
			tab.classList.remove("active");
		});
		tab.classList.add("active");
	});
});
//////////////////////////

// timer countdown //
////////////////////
const launchBtn = document.querySelector(".launch-btn");
const timerCards = document.querySelectorAll(".timer");

timerCards.forEach((card) => {
	const days = card.querySelector(".days");
	const hours = card.querySelector(".hours");
	const mins = card.querySelector(".minutes");
	const seconds = card.querySelector(".seconds");

	if (countdown(card) > 0) {
		var interval = setInterval(() => {
			if (countdown(card) <= 3) {
				launchBtn.disabled = false;
			}
		}, 1000);
	} else {
		launchBtn.disabled = false;
	}

	function changeTimer(d, h, m, s) {
		days.textContent = d < 10 ? "0" + d : d;
		hours.textContent = h < 10 ? "0" + h : h;
		mins.textContent = m < 10 ? "0" + m : m;
		if (seconds) {
			seconds.textContent = s < 10 ? "0" + s : s;
		}
	}

	function countdown(timer) {
		const timeStamp = parseInt(timer.getAttribute("data-time"));
		const currentTime = Math.floor(new Date().getTime() / 1000); //time in seconds
		const timeDifference = timeStamp - currentTime;

		const minsRemain = Math.floor(timeDifference / 60) % 60;
		const hoursRemain = Math.floor(timeDifference / 60 / 60) % 24;
		const daysRemain = Math.floor(timeDifference / 60 / 60 / 24);
		const secondsRemain = Math.floor(timeDifference) % 60;

		if (timeDifference >= 0) {
			changeTimer(daysRemain, hoursRemain, minsRemain, secondsRemain);
		} else {
			clearInterval(interval);
		}

		return timeDifference;
	}
});

///// Search Bar /////

const searchBar = document.querySelector(".search-bar");
const searchIcon = document.querySelector(".searchIcon");
const searchItems = document.querySelectorAll(".searchable");

if (searchIcon) {
	searchIcon.addEventListener("click", () => {
		searchBar.classList.toggle("active");
	});
}
if (searchBar) {
	searchBar.addEventListener("keyup", (e) => {
		const searchString = e.target.value.toLowerCase();
		searchItems.forEach((item) => {
			const gameName = item.querySelector(".gameName");
			if (!gameName.textContent.toLowerCase().includes(searchString)) {
				item.classList.add("d-none");
			} else {
				item.classList.remove("d-none");
				// item.click()
			}
		});
	});
}
