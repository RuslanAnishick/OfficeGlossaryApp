const apiUrl = "/api/Terms";

async function loadTerms() {
    const response = await fetch(apiUrl);
    const terms = await response.json();
    renderTerms(terms);
}

async function searchTerms() {
    const query = document.getElementById("searchInput").value;
    const response = await fetch(`${apiUrl}/search?query=${encodeURIComponent(query)}`);
    const terms = await response.json();
    renderTerms(terms);
}

function renderTerms(terms) {
    const container = document.getElementById("termsContainer");
    container.innerHTML = "";

    if (terms.length === 0) {
        container.innerHTML = "<p>Термины не найдены.</p>";
        return;
    }

    terms.forEach(term => {
        const card = document.createElement("div");
        card.className = "term-card";

        card.innerHTML = `
            <h2>${term.title}</h2>
            <div class="category">${term.category}</div>
            <p>${term.description}</p>
            <div class="example">Пример: ${term.example}</div>
        `;

        container.appendChild(card);
    });
}

loadTerms();
