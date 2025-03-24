function agregar() {
	const items = document.querySelectorAll("#lista li");
	let number = items.length + 1;
	const ul = document.getElementById("lista");
	let newLi = document.createElement("li");
	newLi.textContent = `Elemento ${number}`;
	ul.appendChild(newLi);
}

function borrar() {
	const items = document.querySelectorAll("#lista li");
	const ul = document.getElementById("lista");
	if (items.length > 0) {
		ul.removeChild(items[items.length-1]);
	}
}

function cambiarFondo() {
	const body = document.querySelector("body");
	if (body.style.backgroundColor === "rgb(255, 255, 255)") {
		body.style.backgroundColor = "#05b";
	}
	else {
		body.style.backgroundColor = "#FFF";
	}
}