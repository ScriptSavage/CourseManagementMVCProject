document.addEventListener('DOMContentLoaded', function () {
    const forms = document.querySelectorAll('.js-validate-form');

    forms.forEach(form => {

        form.addEventListener('submit', function (e) {
            let isValid = true;

            const errorMessages = form.querySelectorAll('.auth-validation-error');
            errorMessages.forEach(em => em.textContent = '');

            const firstNameInput = form.querySelector('input[name="FirstName"]');
            if (firstNameInput) {
                if (!firstNameInput.value.trim()) {
                    isValid = false;
                    showClientError(firstNameInput, "Imię jest wymagane.");
                }
            }

            const lastNameInput = form.querySelector('input[name="LastName"]');
            if (lastNameInput) {
                if (!lastNameInput.value.trim()) {
                    isValid = false;
                    showClientError(lastNameInput, "Nazwisko jest wymagane.");
                }
            }

            const emailInput = form.querySelector('input[name="Email"]');
            if (emailInput) {
                if (!validateEmail(emailInput.value.trim())) {
                    isValid = false;
                    showClientError(emailInput, "Wpisz poprawny adres e-mail.");
                }
            }

            const passwordInput = form.querySelector('input[name="Password"]');
            const confirmPasswordInput = form.querySelector('input[name="ConfirmPassword"]');
            if (passwordInput && confirmPasswordInput) {
                if (passwordInput.value !== confirmPasswordInput.value) {
                    isValid = false;
                    showClientError(confirmPasswordInput, "Hasła muszą się zgadzać.");
                }
                if (passwordInput.value.length < 6) {
                    isValid = false;
                    showClientError(passwordInput, "Hasło musi mieć min. 6 znaków");
                }
            }

            if (!isValid) {
                e.preventDefault();
            }
        });

    });
});

function showClientError(inputEl, message) {
    const errorEl = inputEl.parentNode.querySelector('.auth-validation-error');
    if (errorEl) {
        errorEl.textContent = message;
    }
}

function validateEmail(email) {
    const re = /\S+@\S+\.\S+/;
    return re.test(email);
}
