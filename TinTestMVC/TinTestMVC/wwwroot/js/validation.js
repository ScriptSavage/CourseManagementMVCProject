document.addEventListener('DOMContentLoaded', function () {
    const forms = document.querySelectorAll('.js-validate-form');

    forms.forEach(form => {

        form.addEventListener('submit', function (e) {
            let isValid = true;

            const errorMessages = form.querySelectorAll('.form-error');
            errorMessages.forEach(em => em.textContent = '');

            const titleInput = form.querySelector('input[name="Title"]');
            if (titleInput) {
                if (!titleInput.value.trim()) {
                    isValid = false;
                    showClientError(titleInput, "Pole 'Tytuł' jest wymagane.");
                }
            }

            const descriptionInput = form.querySelector('textarea[name="Description"]');
            if (descriptionInput) {
                if (!descriptionInput.value.trim()) {
                    isValid = false;
                    showClientError(descriptionInput, "Pole 'Opis' jest wymagane.");
                }
            }

            const priceInput = form.querySelector('input[name="Price"]');
            if (priceInput) {
                const priceValue = parseFloat(priceInput.value);
                if (isNaN(priceValue) || priceValue <= 0) {
                    isValid = false;
                    showClientError(priceInput, "Cena musi być liczbą większą od zera.");
                }
            }

            const startDateInput = form.querySelector('input[name="StartDate"]');
            const endDateInput = form.querySelector('input[name="EndDate"]');
            if (startDateInput && endDateInput) {
                const startDate = new Date(startDateInput.value);
                const endDate = new Date(endDateInput.value);
                if (isNaN(startDate) || isNaN(endDate)) {
                    isValid = false;
                    showClientError(startDateInput, "Obie daty muszą być poprawne.");
                } else if (startDate >= endDate) {
                    isValid = false;
                    showClientError(startDateInput, "Data rozpoczęcia musi być wcześniejsza niż data zakończenia.");
                    showClientError(endDateInput, "Data zakończenia musi być późniejsza niż data rozpoczęcia.");
                }
            }

            const numberOfStudentsInput = form.querySelector('input[name="NumberOfStudents"]');
            if (numberOfStudentsInput) {
                const numberOfStudents = parseInt(numberOfStudentsInput.value);
                if (isNaN(numberOfStudents) || numberOfStudents <= 0) {
                    isValid = false;
                    showClientError(numberOfStudentsInput, "Liczba studentów musi być liczbą większą od zera.");
                }
            }

            const passwordInput = form.querySelector('input[name="Password"]');
            const confirmPasswordInput = form.querySelector('input[name="ConfirmPassword"]');
            if (passwordInput && confirmPasswordInput) {
                if (passwordInput.value !== confirmPasswordInput.value) {
                    isValid = false;
                    showClientError(confirmPasswordInput, "Hasła muszą się zgadzać.");
                }
            }


            const maxNumberOfStudentsInput = form.querySelector('input[name="MaxNumberOfStudents"]');
            if (maxNumberOfStudentsInput) {
                const maxNumberOfStudents = parseInt(maxNumberOfStudentsInput.value);
                if (isNaN(maxNumberOfStudents) || maxNumberOfStudents <= 0) {
                    isValid = false;
                    showClientError(maxNumberOfStudentsInput, "Maksymalna liczba studentów musi być liczbą większą od zera.");
                } else {
                    const courseId = form.querySelector('input[name="id"]') ? form.querySelector('input[name="id"]').value : null;
                    if (courseId) {
                        try {
                            const response =  fetch(`/Enrollment/GetCurrentNumberOfStudents?courseId=${courseId}`);
                            if (response.ok) {
                                const data =  response.json();
                                const currentNumberOfStudents = data.currentNumberOfStudents;
                                if (currentNumberOfStudents >= maxNumberOfStudents) {
                                    isValid = false;
                                    showClientError(maxNumberOfStudentsInput, "Kurs osiągnął maksymalną liczbę studentów.");
                                }
                            } else {
                                console.error("Błąd pobierania liczby studentów.");
                            }
                        } catch (error) {
                            console.error("Błąd podczas pobierania liczby studentów:", error);
                        }
                    }
                }
            }

            if (!isValid) {
                e.preventDefault(); 
            }
        });

    });
});

function showClientError(inputEl, message) {
    const errorEl = inputEl.parentNode.querySelector('.form-error');
    if (errorEl) {
        errorEl.textContent = message;
    }
}

