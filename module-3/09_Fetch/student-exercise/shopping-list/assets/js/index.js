let items = [];
const ul = document.querySelector('ul');

document.addEventListener('DOMContentLoaded', () => {
    const button = document.querySelector('.loadingButton');
    button.addEventListener('click', loadItems);

    button.addEventListener('click', () => {
        button.removeEventListener('click', loadItems);
    })
})

function loadItems() {
    fetch('https://techelevator-pgh-teams.azurewebsites.net/api/techelevator/shoppinglist')
    .then((headers) => {
        return headers.json();
    })
    .then((data) => {
        items = data;

        items.forEach((item) => {
            const liTemplate = document.getElementById('shopping-list-item-template').content.cloneNode(true);
            liTemplate.querySelector('li').childNodes[0].nodeValue = item.name;
            if (item.completed == true) {
                //liTemplate.querySelector('li').classList.add('completed');
                liTemplate.querySelector('i').classList.add('completed');
            }
            ul.appendChild(liTemplate);
        });
    
        
    })
    .catch((err) => {
        console.error(err);
    })
}