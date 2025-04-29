const dropdowns = document.querySelectorAll('[data-type="dropdown"]')

document.addEventListener('click', function (event) {
    let clickedDropdown = null

    dropdowns.forEach(dropdown => {
        const targetId = dropdown.getAttribute('data-target')
        const targetElement = document.querySelector(targetId)

        if (dropdown.contains(event.target)) {
            clickedDropdown = targetElement

            document.querySelectorAll('.dropdown.dropdown-show').forEach(openDropdown => {
                if (openDropdown !== targetElement) {
                    openDropdown.classList.remove('dropdown-show')
                }
            })

            targetElement.classList.toggle('dropdown-show')
        }
    })

    if (!clickedDropdown && !event.target.closest('.dropdown')) {
        document.querySelectorAll('.dropdown.dropdown-show').forEach(openDropdown => {
            openDropdown.classList.remove('dropdown-show')
        })
    }
})








const clientInput = document.querySelector('#client-input');
const clientButton = document.querySelector('#client-btn');
const clientList = document.querySelector('#client-list');
const formSelect = document.querySelector('.form-select');
const selectedClientInput = document.querySelector('#selected-client');
const clientText = document.querySelector('.form-select-text');


clientButton.addEventListener('click', () => {
    formSelect.classList.toggle('open');
});


clientList.addEventListener('click', (event) => {
    if (event.target.classList.contains('form-select-option')) {
        const clientName = event.target.textContent;
        const clientValue = event.target.getAttribute('data-value');


        clientText.textContent = clientName;


        selectedClientInput.value = clientValue;


        formSelect.classList.remove('open');
    }
});


clientInput.addEventListener('input', () => {

    formSelect.classList.remove('open');
    clientButton.style.display = 'none';
});


window.addEventListener('click', (event) => {
    if (!formSelect.contains(event.target)) {
        formSelect.classList.remove('open');
    }
});











    document.querySelectorAll('.form-select').forEach(select => {
        const trigger = select.querySelector('.form-select-trigger');
        const triggerText = trigger.querySelector('.form-select-text');
        const options = select.querySelectorAll('.form-select-option');
        const hiddenInput = select.querySelector('input[type="hidden"]');
        const placeholder = select.dataset.placeholder || "Choose a client";

        const setValue = (value = "", text = placeholder) => {
            triggerText.textContent = text;
            hiddenInput.value = value;
            select.classList.toggle('has-placeholder', !value);
        };

        setValue();


        trigger.addEventListener('click', (e) => {
            e.stopPropagation();

            document.querySelectorAll('.form-select.open')
                .forEach(el => el !== select && el.classList.remove('open'));

            select.classList.toggle('open');
        });


        options.forEach(option => {
            option.addEventListener('click', () => {
                setValue(option.dataset.value, option.textContent);
                select.classList.remove('open');
            });
        });


        document.addEventListener('click', (e) => {
            if (!select.contains(e.target)) {
                select.classList.remove('open');
            }
        });
    });






//const modals = document.querySelectorAll('[data-type="modal"]');

//document.addEventListener('click', function (event) {
//    let clickedModal = null;

//    modals.forEach(modal => {
//        const targetId = modal.getAttribute('data-target');
//        const targetElement = document.querySelector(targetId);


//        if (modal.contains(event.target)) {
//            clickedModal = targetElement;


//            document.querySelectorAll('.modal.modal-show').forEach(openModal => {
//                if (openModal !== targetElement) {
//                    openModal.classList.remove('modal-show');
//                }
//            });


//            targetElement.classList.toggle('modal-show');
//        }
//    });


//    if (!clickedModal && !event.target.closest('.modal')) {
//        document.querySelectorAll('.modal.modal-show').forEach(openModal => {
//            openModal.classList.remove('modal-show');
//        });
//    }
//});

