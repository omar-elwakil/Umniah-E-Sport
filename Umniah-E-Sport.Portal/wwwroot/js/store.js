const checkoutOverlay = document.querySelector(".checkout");
const checkoutLabel = checkoutOverlay.querySelector(".checkoutLabel");
const checkoutImg = checkoutOverlay.querySelector(".checkoutGameImg");
const checkoutPriceInput = checkoutOverlay.querySelector(".priceInput");
const checkoutPriceDiv = checkoutOverlay.querySelector(".totalPriceDiv");
const plusBtn = checkoutOverlay.querySelector(".plusBtn");
const minusBtn = checkoutOverlay.querySelector(".minusBtn");
const productAmount = checkoutOverlay.querySelector(".productAmount");
const productAmountDiv = checkoutOverlay.querySelector(".productAmountDiv");
const totalPriceDiv = checkoutOverlay.querySelector(".totalPriceDiv");
const totalPriceBtn = checkoutOverlay.querySelector(".totalPriceBtn");

let OriginalPrice;

const products = document.querySelectorAll(".product");

const storeBg = document.querySelector(".storeBg");
const navGames = document.querySelectorAll(".nav-link");

////////////////////////////

navGames.forEach((game) => {
	game.addEventListener("click", changeBG);
});

changeBG();

function changeBG() {
	if (this.classList) {
		const bgSrc = this.querySelector(".gameBgImg").src;
		// console.log(this.classList);
		// console.log(bgSrc);
		storeBg.src = bgSrc;
		// console.log(storeBg.src);
	} else {
		// console.log("kkkkkk");
		const bgSrc = document.querySelector(".gameBgImg").src;
		storeBg.src = bgSrc;
	}
}

products.forEach((product) => {
	product.addEventListener("click", checkout);
});

function checkout() {
	checkoutOverlay.classList.remove("d-none");

	const gamePoster = this.querySelector(".gamePoster").src;
	const productPrice = this.querySelector(".price .amount").innerText;
	const productLabel =
		this.querySelector(".label1").innerText +
		" " +
		this.querySelector(".label2").innerText;

	checkoutImg.src = gamePoster;
	checkoutLabel.innerHTML = productLabel;
	checkoutPriceInput.value = parseInt(productPrice);
	OriginalPrice = parseInt(productPrice);

	checkoutPriceDiv.innerHTML = productPrice;
	totalPriceBtn.innerHTML = productPrice + " EGP";
}

plusBtn.addEventListener("click", increment);
minusBtn.addEventListener("click", decrement);

function increment() {
	productAmount.value++;

	if (productAmount.value < 10) {
		productAmountDiv.innerHTML = "0" + productAmount.value;
	} else {
		productAmountDiv.innerHTML = productAmount.value;
	}

	let total = productAmount.value * OriginalPrice;
	checkoutPriceInput.value = total;
	checkoutPriceDiv.innerHTML = total.toFixed(2);
	totalPriceBtn.innerHTML = total.toFixed(2) + " EGP";
}

function decrement() {
	if (productAmount.value <= 1) {
		return;
	} else {
		productAmount.value--;
		if (productAmount.value < 10) {
			productAmountDiv.innerHTML = "0" + productAmount.value;
		} else {
			productAmountDiv.innerHTML = productAmount.value;
		}

		let total = productAmount.value * OriginalPrice;
		checkoutPriceInput.value = total;
		checkoutPriceDiv.innerHTML = total.toFixed(2);
		totalPriceBtn.innerHTML = total.toFixed(2) + " EGP";
	}
}
