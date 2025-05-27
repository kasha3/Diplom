let allEmployees = [];
let allNews = [];
let allEvents = [];

function loadEmployees() {
    fetch("/api/v1/employees/web")
        .then(response => response.json())
        .then(data => {
            allEmployees = data;
            displayEmployees(data);
        });
}

function loadNews() {
    fetch("/api/v1/news")
        .then(response => response.json())
        .then(data => {
            allNews = data;
            displayNews(data);
        });
}

function loadEvents() {
    fetch("/api/v1/events")
        .then(response => response.json())
        .then(data => {
            allEvents = data;
            displayEvents(data);
        });
}

function displayEmployees(employees) {
    const container = document.getElementById("employees-container");
    container.innerHTML = "";

    if (employees.length === 0) {
        container.innerHTML = '<div class="no-results">Сотрудники не найдены</div>';
        return;
    }

    employees.forEach(employee => {
        const div = document.createElement("div");
        div.classList.add("employee-card");
        div.innerHTML = `<h3>${escapeHtml(employee.fullName)}</h3>
                        <p>${escapeHtml(employee.name)}</p>
                        <p>${escapeHtml(employee.email)}</p>
                        <p>${escapeHtml(employee.workPhone)}</p>
                        <p>${escapeHtml(employee.birthdate)}</p>
                        <button onclick="showQRCode('${escapeHtml(employee.fullName)}', 
                        '${escapeHtml(employee.email)}', '${escapeHtml(employee.workPhone)}', 
                        '${escapeHtml(employee.name)}', this)">💾</button>`;
        container.appendChild(div);
    });
}

function displayNews(newsItems) {
    const container = document.getElementById("news-container");
    container.innerHTML = "";

    if (newsItems.length === 0) {
        container.innerHTML = '<div class="no-results">Новости не найдены</div>';
        return;
    }

    newsItems.forEach(news => {
        container.appendChild(createNewsElement(news));
    });
}

function displayEvents(events) {
    const container = document.getElementById("events-container");
    container.innerHTML = "";
    if (events.length === 0) {
        container.innerHTML = '<div class="no-results">События не найдены</div>';
        return;
    }
    events.forEach(event => {
        const div = document.createElement("div");
        div.classList.add("event-item");
        div.innerHTML = `<h3>${escapeHtml(event.name)}</h3>
                        <p>${escapeHtml(event.description)}</p>
                        <p><strong>Дата:</strong> ${escapeHtml(event.date)}</p>
                        <p><strong>Автор:</strong> ${escapeHtml(event.authorName)}</p>
                        <button onclick="downloadCalendar(${event.id})">🗓️</button>`;
        container.appendChild(div);
    });
}

//Функция для экранирования HTML
function escapeHtml(unsafe) {
    if (!unsafe) return '';
    return unsafe.toString()
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#039;");
}

// Функция поиска
function performSearch(query) {
    const lowerQuery = query.toLowerCase().trim();
    if (!lowerQuery) {
        // Если запрос пустой, показываем все данные
        displayEmployees(allEmployees);
        displayNews(allNews);
        displayEvents(allEvents);
        return;
    }
    // Поиск сотрудников
    const filteredEmployees = allEmployees.filter(employee =>
        (employee.fullName && employee.fullName.toLowerCase().includes(lowerQuery)) ||
        (employee.name && employee.name.toLowerCase().includes(lowerQuery)) ||
        (employee.email && employee.email.toLowerCase().includes(lowerQuery)) ||
        (employee.workPhone && employee.workPhone.toLowerCase().includes(lowerQuery)) ||
        (employee.birthdate && employee.birthdate.toLowerCase().includes(lowerQuery))
    );
    displayEmployees(filteredEmployees);
    // Поиск новостей
    const filteredNews = allNews.filter(news =>
        (news.name && news.name.toLowerCase().includes(lowerQuery)) ||
        (news.description && news.description.toLowerCase().includes(lowerQuery)) ||
        (news.date && news.date.toLowerCase().includes(lowerQuery))
    );
    displayNews(filteredNews);
    // Поиск событий
    const filteredEvents = allEvents.filter(event =>
        (event.name && event.name.toLowerCase().includes(lowerQuery)) ||
        (event.description && event.description.toLowerCase().includes(lowerQuery)) ||
        (event.date && event.date.toLowerCase().includes(lowerQuery)) ||
        (event.authorName && event.authorName.toLowerCase().includes(lowerQuery))
    );
    displayEvents(filteredEvents);
}

document.addEventListener("DOMContentLoaded", function () {
    loadEmployees();
    loadNews();
    loadEvents();
    generateCalendar(new Date());
    const searchInput = document.querySelector('input[type="text"]');
    let searchTimeout;
    searchInput.addEventListener('input', function () {
        clearTimeout(searchTimeout);
        searchTimeout = setTimeout(() => {
            performSearch(this.value);
        }, 300);
    });
    searchInput.addEventListener('keydown', function (e) {
        if (e.key === 'Escape') {
            this.value = '';
            performSearch('');
        }
    });
});

function createNewsElement(news) {
    const div = document.createElement("div");
    div.classList.add("news-tile");
    div.innerHTML = `
        <div class="newsimg"><img src="${news.image}"></div>
        <div class="news-content">
            <h3>${news.name}</h3>
            <p>${news.description}</p>
            <p class="news-date">${news.date}</p>
        </div>`;
    return div;
}
setInterval(loadNews, 15000);
function downloadCalendar(eventId) {
    window.location.href = `/api/v1/events/${eventId}/calendar`;
}

function showQRCode(name, email, phone, position, button) {
    const vCardData = `BEGIN:VCARD\nVERSION:3.0\nFN:${name}\nTITLE:${position}\nTEL;WORK;VOICE:${phone}\nEMAIL;WORK;INTERNET:${email}\nEND:VCARD`;
    const qrCodeDiv = document.createElement("div");
    qrCodeDiv.classList.add("qr-code");
    //кнопка закрытия QR-кода
    const closeButton = document.createElement("button");
    closeButton.textContent = "×";
    closeButton.style.top = "5px";
    closeButton.style.right = "5px";
    closeButton.style.background = "none";
    closeButton.style.border = "none";
    closeButton.style.fontSize = "20px";
    closeButton.style.cursor = "pointer";
    closeButton.onclick = () => qrCodeDiv.replaceWith(button);
    qrCodeDiv.appendChild(closeButton);
    QRCode.toDataURL(vCardData, {
        width: 200,
        height: 200,
        margin: 1,
        color: {
            dark: '#000000',
            light: '#ffffff'
        }
    }, (error, url) => {
        if (error) {
            console.error('QR generation error:', error);
            return;
        }
        const img = document.createElement("img");
        img.src = url;
        img.alt = "QR код визитки";
        qrCodeDiv.appendChild(img);
        button.replaceWith(qrCodeDiv);
    });
}

let currentDate = new Date();
function generateCalendar(date) {
    const container = document.getElementById("calendar-days");
    const monthYear = document.getElementById("calendar-month-year");
    const monthNames = ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"];
    monthYear.textContent = `${monthNames[date.getMonth()]} ${date.getFullYear()}`;
    container.innerHTML = "";
    let firstDay = new Date(date.getFullYear(), date.getMonth(), 1).getDay();
    let lastDate = new Date(date.getFullYear(), date.getMonth() + 1, 0).getDate();
    Promise.all([
        fetch("/api/v1/events").then(res => res.json()),
        fetch("/api/v1/employees/desktop").then(res => res.json()) // решить проблему с парсингом даты рождения!
    ]).then(([events, employees]) => {
        console.log("Events dates:", events.slice(0, 3).map(e => e.date));
        console.log("Birthdates:", employees.slice(0, 3).map(e => e.birthdate));
        // Универсальная функция для парсинга дат
        const parseDate = (dateString) => {
            if (!dateString) return null;
            try {
                // Если дата в формате ISO с временем (YYYY-MM-DDTHH:mm:ss)
                if (dateString.includes('T')) {
                    return new Date(dateString);
                }
                // Если дата в формате YYYY-MM-DD
                else if (dateString.includes('-') && dateString.split('-')[0].length === 4) {
                    const parts = dateString.split('-');
                    return new Date(parts[0], parts[1] - 1, parts[2]);
                }
                // Если дата в формате MM-DD-YYYY
                else if (dateString.includes('-')) {
                    const parts = dateString.split('-');
                    return new Date(parts[2], parts[0] - 1, parts[1]);
                }
                // Если дата в формате DD.MM.YYYY
                else if (dateString.includes('.')) {
                    const [day, month, year] = dateString.split('.').map(Number);
                    return new Date(year, month - 1, day);
                }
                // Пробуем распарсить как есть
                else {
                    return new Date(dateString);
                }
            } catch (e) {
                console.error("Error parsing date:", dateString, e);
                return null;
            }
        };
        //обработка событий
        const eventsByDate = {};
        events.forEach(event => {
            if (!event.date) return;
            const eventDate = parseDate(event.date);
            if (!eventDate || isNaN(eventDate.getTime())) {
                console.warn("Invalid event date:", event.date);
                return;
            }
            //проверка, что событие в текущем месяце
            if (eventDate.getFullYear() === date.getFullYear() &&
                eventDate.getMonth() === date.getMonth()) {
                const dateKey = `${date.getFullYear()}-${String(date.getMonth() + 1).
                    padStart(2, '0')}-${String(eventDate.getDate()).padStart(2, '0')}`;
                if (!eventsByDate[dateKey]) {
                    eventsByDate[dateKey] = [];
                }
                eventsByDate[dateKey].push(event);
            }
        });
        //обработка дней рождения
        const birthdaysByDate = {};
        employees.forEach(employee => {
            if (!employee.birthDate) return;
            const birthDate = parseDate(employee.birthDate);
            if (!birthDate || isNaN(birthDate.getTime())) {
                console.warn("Invalid birthdate:", employee.birthDate);
                return;
            }
            //проверка, что день рождения в текущем месяце (год не учитываем)
            if (birthDate.getMonth() + 1 === date.getMonth() + 1) {
                const dateKey = `${date.getFullYear()}-${String(date.getMonth() + 1).
                    padStart(2, '0')}-${String(birthDate.getDate()).padStart(2, '0')}`;
                if (!birthdaysByDate[dateKey]) {
                    birthdaysByDate[dateKey] = [];
                }
                birthdaysByDate[dateKey].push(employee.fullName);
            }
        });
        //генерация календаря
        for (let i = 0; i < (firstDay === 0 ? 6 : firstDay - 1); i++) {
            let emptyDiv = document.createElement("div");
            emptyDiv.classList.add("calendar-empty");
            container.appendChild(emptyDiv);
        }
        for (let day = 1; day <= lastDate; day++) {
            let dayDiv = document.createElement("div");
            dayDiv.classList.add("calendar-day");
            const dayNumber = document.createElement("div");
            dayNumber.textContent = day;
            dayNumber.classList.add("day-number");
            dayDiv.appendChild(dayNumber);
            const dateKey = `${date.getFullYear()}-${String(date.getMonth() + 1).
                padStart(2, '0')}-${String(day).padStart(2, '0')}`;
            const today = new Date();
            const todayKey = `${today.getFullYear()}-${String(today.getMonth() + 1).
                padStart(2, '0')}-${String(today.getDate()).padStart(2, '0')}`;
            if (dateKey === todayKey) {
                dayDiv.classList.add("today");
                dayNumber.classList.add("today-circle");
            }
            if (eventsByDate[dateKey]) {
                const eventCount = eventsByDate[dateKey].length;
                if (eventCount >= 5) {
                    dayDiv.style.backgroundColor = "#FC4343";
                } else if (eventCount < 2) {
                    dayDiv.style.backgroundColor = "#89FC43";
                } else {
                    dayDiv.style.backgroundColor = "#F8FC43";
                }
                dayDiv.title = `События: ${eventsByDate[dateKey].map(e => e.name || 'Без названия').join(", ")}`;
            }
            if (birthdaysByDate[dateKey]) {
                const birthdayIcon = document.createElement("div");
                birthdayIcon.classList.add("birthday-icon");
                birthdayIcon.innerHTML = "🎂";
                const tooltip = document.createElement("div");
                tooltip.classList.add("birthday-tooltip");
                tooltip.textContent = `Дни рождения: ${birthdaysByDate[dateKey].join(", ")}`;
                birthdayIcon.appendChild(tooltip);
                dayDiv.appendChild(birthdayIcon);
            }
            container.appendChild(dayDiv);
        }
    }).catch(error => {
        console.error("Error loading calendar data:", error);
    });
}

function prevMonth() {
    currentDate.setMonth(currentDate.getMonth() - 1);
    generateCalendar(currentDate);
}

function nextMonth() {
    currentDate.setMonth(currentDate.getMonth() + 1);
    generateCalendar(currentDate);
}
